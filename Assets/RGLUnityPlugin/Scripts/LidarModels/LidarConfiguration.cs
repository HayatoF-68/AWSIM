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
using UnityEngine;
using System.Linq;


namespace RGLUnityPlugin
{
    [Serializable]
    public struct LidarConfiguration
    {
        public enum RayGenerateMethod
        {
            // Rays are generated for rotating lidar with equal range for all of the lasers
            RotatingLidarEqualRange,
            // Rays are generated for rotating lidar with different ranges for the lasers
            RotatingLidarDifferentLaserRanges,
            // Rays are generated in specific way to HesaiAT128 lidar
            HesaiAT128,
            // Rays are generated in specific way to HesaiQT128C2X lidar
            HesaiQT128C2X,
        }

        [Tooltip("Method that rays are generated")]
        public RayGenerateMethod rayGenerateMethod;

        [Tooltip("Geometry description of lidar array")]
        public LaserArray laserArray;

        [Tooltip("The horizontal resolution of laser array firings (in degrees)")]
        [Min(0)] public float horizontalResolution;

        [Tooltip("Min horizontal angle (left)")]
        [Range(-360.0f, 360.0f)] public float minHAngle;

        [Tooltip("Max horizontal angle (right)")]
        [Range(-360.0f, 360.0f)] public float maxHAngle;

        [Tooltip("Minimum range of the sensor")]
        [DrawIf("rayGenerateMethod", RayGenerateMethod.RotatingLidarEqualRange)] [Min(0)] public float minRange;

        [Tooltip("Maximum range of the sensor")]
        [DrawIf("rayGenerateMethod", RayGenerateMethod.RotatingLidarEqualRange)] [Min(0)] public float maxRange;

        [Tooltip("Time between two consecutive firings of the whole laser array (in milliseconds). Usually, it consists of firing time for all the lasers and recharge time.")]
        [Min(0)] public float laserArrayCycleTime;

        [Tooltip("Represents the deviation of photons from a single beam emitted by a LiDAR sensor (in degrees). Used for simulating snow only (private feature).")]
        [Range(0.0f, 360.0f)] public float beamDivergence;

        [Tooltip("Lidar noise parameters")]
        public LidarNoiseParams noiseParams;

        public int HorizontalSteps => Math.Max((int)Math.Round(((maxHAngle - minHAngle) / horizontalResolution)), 1);
        public int PointCloudSize => laserArray.lasers.Length * HorizontalSteps;

        public Matrix4x4[] GetRayPoses()
        {
            // Config validation
            if (!(minHAngle <= maxHAngle))
            {
                throw new ArgumentOutOfRangeException(nameof(minHAngle),
                    "Minimum angle must be lower or equal to maximum angle");
            }

            if (maxHAngle - minHAngle > 360.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(maxHAngle),
                    "Horizontal range must be lower than 360 degrees");
            }

            if (!(horizontalResolution > 0.0f))
            {
                throw new ArgumentOutOfRangeException(nameof(horizontalResolution),
                    "Horizontal resolution must be positive");
            }

            return rayGenerateMethod switch
            {
                RayGenerateMethod.RotatingLidarEqualRange => GetRayPosesCommonLidar(),
                RayGenerateMethod.RotatingLidarDifferentLaserRanges => GetRayPosesCommonLidar(),
                RayGenerateMethod.HesaiAT128 => GetRayPosesCommonLidar(),
                RayGenerateMethod.HesaiQT128C2X => GetRayPosesHesaiQT128C2X(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public Vector2[] GetRayRanges()
        {
            return rayGenerateMethod switch
            {
                RayGenerateMethod.RotatingLidarEqualRange => new Vector2[1] {new Vector2(minRange, maxRange)},
                RayGenerateMethod.RotatingLidarDifferentLaserRanges => GetRayRangesFromLasers(),
                RayGenerateMethod.HesaiAT128 => GetRayRangesHesaiAT128(),
                RayGenerateMethod.HesaiQT128C2X => GetRayRangesFromLasers(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private Vector2[] GetRayRangesFromLasers()
        {
            Vector2[] rayRanges = new Vector2[PointCloudSize];
            Vector2[] laserRanges = laserArray.GetLaserRanges();
            for (int i = 0; i < HorizontalSteps; i++)
            {
                Array.Copy(laserRanges, 0, rayRanges, i * laserRanges.Length, laserRanges.Length);
            }
            return rayRanges;
        }

        public float[] GetRayTimeOffsets()
        {
            float[] rayTimeOffsets = new float[PointCloudSize];
            for (int hStep = 0; hStep < HorizontalSteps; hStep++)
            {
                for (int laserId = 0; laserId < laserArray.lasers.Length; laserId++)
                {
                    int idx = laserId + hStep * laserArray.lasers.Length;
                    rayTimeOffsets[idx] = laserArray.lasers[laserId].timeOffset + laserArrayCycleTime * hStep;
                }
            }
            return rayTimeOffsets;
        }

        /// <summary>
        /// Returns transform from the attached game object to the LiDAR origin.
        /// </summary>
        public Matrix4x4 GetLidarOriginTransfrom()
        {
            return Matrix4x4.Translate(laserArray.centerOfMeasurementLinearOffsetMm / 1000.0f);
        }

        public static LidarNoiseParams TypicalNoiseParams => new LidarNoiseParams
        {
            angularNoiseType = AngularNoiseType.RayBased,
            angularNoiseMean = Mathf.Rad2Deg * 0.0f,
            angularNoiseStDev = Mathf.Rad2Deg * 0.001f,
            distanceNoiseStDevBase = 0.02f,
            distanceNoiseStDevRisePerMeter = 0.0f,
            distanceNoiseMean = 0.0f,
        };

        public static LidarNoiseParams ZeroNoiseParams => new LidarNoiseParams
        {
            angularNoiseType = AngularNoiseType.RayBased,
            angularNoiseStDev = 0.0f,
            distanceNoiseStDevBase = 0.0f,
            distanceNoiseStDevRisePerMeter = 0.0f,
            angularNoiseMean = 0.0f,
            distanceNoiseMean = 0.0f,
        };

        public Matrix4x4[] GetRayPosesCommonLidar()
        {
            Matrix4x4[] rayPoses = new Matrix4x4[PointCloudSize];

            Matrix4x4[] laserPoses = laserArray.GetLaserPoses();
            for (int hStep = 0; hStep < HorizontalSteps; hStep++)
            {
                for (int laserId = 0; laserId < laserPoses.Length; laserId++)
                {
                    int idx = laserId + hStep * laserPoses.Length;
                    float azimuth = minHAngle + hStep * horizontalResolution;
                    rayPoses[idx] = Matrix4x4.Rotate(Quaternion.Euler(0.0f, azimuth, 0.0f)) * laserPoses[laserId];
                }
            }

            return rayPoses;
        }

        /// HesaiAT128
        private Vector2[] GetRayRangesHesaiAT128()
        {
            // All channels fire laser pulses that measure the far field (＞ 7.2 m)
            // Additionally, the NF-enabled channels also fire laser pulses that measure only the near field (0.5 to 7.2 m), at a time other
            // than these channels' far field firings.
            // NF-enabled channels are marked with minRange set to NEAR_FIELD_MIN_RANGE.
            const float NEAR_FIELD_MIN_RANGE = 0.5f;
            const float FAR_FIELD_MIN_RANGE = 7.2f;

            Vector2[] rayRanges = new Vector2[PointCloudSize];
            Vector2[] laserRanges = laserArray.GetLaserRanges();
            for (int i = 0; i < PointCloudSize; i++)
            {
                rayRanges[i] = laserRanges[i % laserRanges.Length];
                // The horizontal resolution for the near field is 2 times greater than for the far field.
                // To simulate it, every second minimum range of the ray will be set for the far field.
                if (rayRanges[i].x == NEAR_FIELD_MIN_RANGE && (i / laserRanges.Length) % 2 == 1)
                {
                    rayRanges[i].x = FAR_FIELD_MIN_RANGE;
                }
            }
            return rayRanges;
        }

        /// HesaiQT128C2X
        private static int hesaiQT128LasersBankLength = 32;
        private Matrix4x4[] GetRayPosesHesaiQT128C2X()
        {
            Matrix4x4[] rayPoses = new Matrix4x4[PointCloudSize];

            Matrix4x4[] laserPoses = laserArray.GetLaserPoses();
            for (int hStep = 0; hStep < HorizontalSteps; hStep++)
            {
                for (int laserId = 0; laserId < laserPoses.Length; laserId++)
                {
                    int idx = laserId + hStep * laserPoses.Length;
                    float highResolutionAddition = 0.0f;
                    if (laserId > 3 * hesaiQT128LasersBankLength - 1)
                    {
                        highResolutionAddition = horizontalResolution / 2;
                    }
                    float azimuth = minHAngle + hStep * horizontalResolution + highResolutionAddition;
                    rayPoses[idx] = Matrix4x4.Rotate(Quaternion.Euler(0.0f, azimuth, 0.0f)) * laserPoses[laserId];
                }
            }

            return rayPoses;
        }
    }
}
