// Copyright 2022 Robotec.ai.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Object = System.Object;

namespace RGLUnityPlugin
{
    /// <summary>
    /// Encapsulates all non-ROS components of a RGL-based Lidar.
    /// </summary>
    [RequireComponent(typeof(PointCloudVisualization))]
    public class LidarSensor : MonoBehaviour
    {
        /// <summary>
        /// Sensor processing and callbacks are automatically called in this hz.
        /// </summary>
        [FormerlySerializedAs("OutputHz")]
        [Range(0, 50)] public int AutomaticCaptureHz = 10;

        /// <summary>
        /// Delegate used in callbacks.
        /// </summary>
        /// <param name="outputData">Data output for each hz</param>
        public delegate void OnNewDataDelegate();

        /// <summary>
        /// Called when new data is generated via automatic capture.
        /// </summary>
        public OnNewDataDelegate onNewData;

        /// <summary>
        /// Called when lidar model configuration has changed.
        /// </summary>
        public OnNewDataDelegate onLidarModelChange;

        /// <summary>
        /// Allows to select one of built-in LiDAR models.
        /// Defaults to a range meter to ensure the choice is conscious.
        /// </summary>
        public LidarModel modelPreset = LidarModel.RangeMeter;

        /// <summary>
        /// Allows to quickly enable/disable distance gaussian noise.
        /// </summary>
        public bool applyDistanceGaussianNoise = true;

        /// <summary>
        /// Allows to quickly enable/disable angular gaussian noise.
        /// </summary>
        public bool applyAngularGaussianNoise = true;

        /// <summary>
        /// Allows to quickly enable/disable velocity distortion
        /// </summary>
        public bool applyVelocityDistortion = true;

        /// <summary>
        /// Encapsulates description of a point cloud generated by a LiDAR and allows for fine-tuning.
        /// </summary>
        public LidarConfiguration configuration = LidarConfigurationLibrary.ByModel[LidarModel.RangeMeter];

        private RGLNodeSequence rglGraphLidar;
        private RGLNodeSequence rglSubgraphCompact;
        private RGLNodeSequence rglSubgraphToLidarFrame;
        private RGLNodeSequence rglSubgraphVisualizationOutput;
        private SceneManager sceneManager;

        private readonly string lidarRaysNodeId = "LIDAR_RAYS";
        private readonly string lidarRangeNodeId = "LIDAR_RANGE";
        private readonly string lidarRingsNodeId = "LIDAR_RINGS";
        private readonly string lidarTimeOffsetsNodeId = "LIDAR_OFFSETS";
        private readonly string lidarVelocityDistortionNodeId = "LIDAR_DISTORT";
        private readonly string lidarPoseNodeId = "LIDAR_POSE";
        private readonly string noiseLidarRayNodeId = "NOISE_LIDAR_RAY";
        private readonly string lidarRaytraceNodeId = "LIDAR_RAYTRACE";
        private readonly string noiseHitpointNodeId = "NOISE_HITPOINT";
        private readonly string noiseDistanceNodeId = "NOISE_DISTANCE";
        private readonly string pointsCompactNodeId = "POINTS_COMPACT";
        private readonly string toLidarFrameNodeId = "TO_LIDAR_FRAME";
        private readonly string visualizationOutputNodeId = "OUT_VISUALIZATION";

        private LidarModel? validatedPreset;
        private float timer;

        private Matrix4x4 lastTransform;

        public void Awake()
        {
            rglGraphLidar = new RGLNodeSequence()
                .AddNodeRaysFromMat3x4f(lidarRaysNodeId, new Matrix4x4[1] {Matrix4x4.identity})
                .AddNodeRaysSetRange(lidarRangeNodeId, new Vector2[1] {new Vector2(0.0f, Mathf.Infinity)})
                .AddNodeRaysSetRingIds(lidarRingsNodeId, new int[1] {0})
                .AddNodeRaysSetTimeOffsets(lidarTimeOffsetsNodeId, new float[1] {0})
                .AddNodeRaysVelocityDistortion(lidarVelocityDistortionNodeId, Vector3.zero, Vector3.zero)
                .AddNodeRaysTransform(lidarPoseNodeId, Matrix4x4.identity)
                .AddNodeGaussianNoiseAngularRay(noiseLidarRayNodeId, 0, 0)
                .AddNodeRaytrace(lidarRaytraceNodeId)
                .AddNodeGaussianNoiseAngularHitpoint(noiseHitpointNodeId, 0, 0)
                .AddNodeGaussianNoiseDistance(noiseDistanceNodeId, 0, 0, 0);

            rglSubgraphCompact = new RGLNodeSequence()
                .AddNodePointsCompact(pointsCompactNodeId);

            rglSubgraphToLidarFrame = new RGLNodeSequence()
                .AddNodePointsTransform(toLidarFrameNodeId, Matrix4x4.identity);

            rglSubgraphVisualizationOutput = new RGLNodeSequence()
                .AddNodePointsYield(visualizationOutputNodeId, RGLField.XYZ_F32);

            RGLNodeSequence.Connect(rglGraphLidar, rglSubgraphCompact);
            RGLNodeSequence.Connect(rglSubgraphCompact, rglSubgraphToLidarFrame);
            RGLNodeSequence.Connect(rglSubgraphCompact, rglSubgraphVisualizationOutput);
        }

        public void Start()
        {
            sceneManager = FindObjectOfType<SceneManager>();
            if (sceneManager == null)
            {
                // TODO(prybicki): this is too tedious, implement automatic instantiation of RGL Scene Manager
                Debug.LogError($"RGL Scene Manager is not present on the scene. Destroying {name}.");
                Destroy(this);
            }
            OnValidate();
        }

        public void OnValidate()
        {
            // This tricky code ensures that configuring from a preset dropdown
            // in Unity Inspector works well in prefab edit mode and regular edit mode. 
            bool presetChanged = validatedPreset != modelPreset;
            bool firstValidation = validatedPreset == null;
            if (!firstValidation && presetChanged)
            {
                configuration = LidarConfigurationLibrary.ByModel[modelPreset];
            }
            ApplyConfiguration(configuration);
            validatedPreset = modelPreset;
        }

        private void ApplyConfiguration(LidarConfiguration newConfig)
        {
            if (rglGraphLidar == null)
            {
                return;
            }

            if (onLidarModelChange != null)
            {
                onLidarModelChange.Invoke();
            }

            rglGraphLidar.UpdateNodeRaysFromMat3x4f(lidarRaysNodeId, newConfig.GetRayPoses())
                         .UpdateNodeRaysSetRange(lidarRangeNodeId, newConfig.GetRayRanges())
                         .UpdateNodeRaysSetRingIds(lidarRingsNodeId, newConfig.laserArray.GetLaserRingIds())
                         .UpdateNodeRaysTimeOffsets(lidarTimeOffsetsNodeId, newConfig.GetRayTimeOffsets())
                         .UpdateNodeGaussianNoiseAngularRay(noiseLidarRayNodeId,
                             newConfig.noiseParams.angularNoiseMean * Mathf.Deg2Rad,
                             newConfig.noiseParams.angularNoiseStDev * Mathf.Deg2Rad)
                         .UpdateNodeGaussianNoiseAngularHitpoint(noiseHitpointNodeId,
                             newConfig.noiseParams.angularNoiseMean * Mathf.Deg2Rad,
                             newConfig.noiseParams.angularNoiseStDev * Mathf.Deg2Rad)
                         .UpdateNodeGaussianNoiseDistance(noiseDistanceNodeId, newConfig.noiseParams.distanceNoiseMean,
                             newConfig.noiseParams.distanceNoiseStDevBase, newConfig.noiseParams.distanceNoiseStDevRisePerMeter);

            rglGraphLidar.SetActive(noiseDistanceNodeId, applyDistanceGaussianNoise);
            var angularNoiseType = newConfig.noiseParams.angularNoiseType;
            rglGraphLidar.SetActive(noiseLidarRayNodeId, applyAngularGaussianNoise && angularNoiseType == AngularNoiseType.RayBased);
            rglGraphLidar.SetActive(noiseHitpointNodeId, applyAngularGaussianNoise && angularNoiseType == AngularNoiseType.HitpointBased);
        }

        public void FixedUpdate()
        {
            if (AutomaticCaptureHz == 0.0f)
            {
                return;
            }
            
            timer += Time.deltaTime;

            var interval = 1.0f / AutomaticCaptureHz;
            if (timer + 0.00001f < interval)
                return;
            timer = 0;

            Capture();
            if (onNewData != null)
            {
                onNewData.Invoke();
            }
        }

        /// <summary>
        /// Connect to point cloud in world coordinate frame.
        /// </summary>
        public void ConnectToWorldFrame(RGLNodeSequence nodeSequence, bool compacted = true)
        {
            if (compacted)
            {
                RGLNodeSequence.Connect(rglSubgraphCompact, nodeSequence);
            }
            else
            {
                RGLNodeSequence.Connect(rglGraphLidar, nodeSequence);
            }
        }

        /// <summary>
        /// Connect to compacted point cloud in lidar coordinate frame.
        /// </summary>
        public void ConnectToLidarFrame(RGLNodeSequence nodeSequence)
        {
            RGLNodeSequence.Connect(rglSubgraphToLidarFrame, nodeSequence);
        }

        public void Capture()
        {
            sceneManager.DoUpdate();

            //Calculate delta transform of lidar.
            Matrix4x4 currentTransform = gameObject.transform.localToWorldMatrix * configuration.GetLidarOriginTransfrom();
            Vector3 deltaTranslation = (lastTransform.GetColumn(3) - (currentTransform).GetColumn(3)) * 0.001f;

            Vector3 deltaRotation = Quaternion.LookRotation(lastTransform.GetColumn(2), lastTransform.GetColumn(1)).eulerAngles
                                    - Quaternion.LookRotation(currentTransform.GetColumn(2), currentTransform.GetColumn(1)).eulerAngles;

            deltaRotation *= Mathf.Deg2Rad;

            // Update last known transform of lidar.
            lastTransform = gameObject.transform.localToWorldMatrix * configuration.GetLidarOriginTransfrom();

            // Set lidar pose
            Matrix4x4 lidarPose = gameObject.transform.localToWorldMatrix * configuration.GetLidarOriginTransfrom();
            rglGraphLidar.UpdateNodeRaysTransform(lidarPoseNodeId, lidarPose);
            rglSubgraphToLidarFrame.UpdateNodePointsTransform(toLidarFrameNodeId, lidarPose.inverse);

            // Set lidar velocity
            rglGraphLidar.UpdateNodeRaysVelocityDistortion(lidarVelocityDistortionNodeId, deltaTranslation, deltaRotation);

            rglGraphLidar.Run();

            // Could be moved to PointCloudVisualization
            if (GetComponent<PointCloudVisualization>().isActiveAndEnabled)
            {
                Vector3[] onlyHits = new Vector3[0];
                rglSubgraphVisualizationOutput.GetResultData<Vector3>(ref onlyHits);
                GetComponent<PointCloudVisualization>().SetPoints(onlyHits);
            }
        }
    }
}
