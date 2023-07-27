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

using UnityEngine;
using System.Collections.Generic;

namespace RGLUnityPlugin
{
    public static class LaserArrayLibrary
    {
        public static readonly Dictionary<LidarModel, LaserArray> ByModel =
            new Dictionary<LidarModel, LaserArray>
            {
                {LidarModel.HesaiPandar40P, HesaiPandar40P},
                {LidarModel.HesaiPandarQT, HesaiPandarQT},
                {LidarModel.VelodyneVLP16, VelodyneVLP16},
                {LidarModel.VelodyneVLP32C, VelodyneVLP32C},
                {LidarModel.VelodyneVLS128, VelodyneVLS128},
                {LidarModel.OusterOS1_64, OusterOS1_64},
                {LidarModel.HesaiAT128E2X, HesaiAT128E2X},
            };

        // https://web2019.blob.core.windows.net/uploads/Pandar40P_User_Manual_402-en-211010.pdf
        public static LaserArray HesaiPandar40P => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(0.0f, 47.7f, 0.0f),
            focalDistanceMm = 0.0f,
            lasers = new[]
            {
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +25.0f, ringId = 1},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +19.0f, ringId = 2},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +14.0f, ringId = 3},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +13.0f, ringId = 4},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +12.0f, ringId = 5},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +11.0f, ringId = 6},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +10.0f, ringId = 7},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +9.0f, ringId = 8},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +8.0f, ringId = 9},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +7.0f, ringId = 10},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +6.0f, ringId = 11},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = +5.67f, ringId = 12},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = +5.33f, ringId = 13},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +5.0f, ringId = 14},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = +4.67f, ringId = 15},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = +4.33f, ringId = 16},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +4.0f, ringId = 17},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = +3.67f, ringId = 18},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = +3.33f, ringId = 19},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +3.0f, ringId = 20},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = +2.67f, ringId = 21},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = +2.33f, ringId = 22},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +2.0f, ringId = 23},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = +1.67f, ringId = 24},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = +1.33f, ringId = 25},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = +1.0f, ringId = 26},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = +0.67f, ringId = 27},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = +0.33f, ringId = 28},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -0.0f, ringId = 29},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = -0.33f, ringId = 30},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = -0.67f, ringId = 31},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -1.0f, ringId = 32},
                new Laser {horizontalAngularOffsetDeg = -5.208f, verticalAngularOffsetDeg = -1.33f, ringId = 33},
                new Laser {horizontalAngularOffsetDeg = 3.125f, verticalAngularOffsetDeg = -1.67f, ringId = 34},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -2.0f, ringId = 35},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -3.0f, ringId = 36},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -5.0f, ringId = 37},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -8.0f, ringId = 38},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -11.0f, ringId = 39},
                new Laser {horizontalAngularOffsetDeg = -1.042f, verticalAngularOffsetDeg = -15.0f, ringId = 40}
            }
        };

        // https://web2019.blob.core.windows.net/uploads/PandarQT_User_Manual_Q01-en-210910.pdf
        public static LaserArray HesaiPandarQT => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(0.0f, 50.4f, 0.0f),
            focalDistanceMm = 29.8f,
            lasers = new[]
            {
                new Laser {horizontalAngularOffsetDeg = 8.736f, verticalAngularOffsetDeg = +52.121f, ringId = 1},
                new Laser {horizontalAngularOffsetDeg = 8.314f, verticalAngularOffsetDeg = +49.785f, ringId = 2},
                new Laser {horizontalAngularOffsetDeg = 7.964f, verticalAngularOffsetDeg = +47.577f, ringId = 3},
                new Laser {horizontalAngularOffsetDeg = 7.669f, verticalAngularOffsetDeg = +45.477f, ringId = 4},
                new Laser {horizontalAngularOffsetDeg = 7.417f, verticalAngularOffsetDeg = +43.465f, ringId = 5},
                new Laser {horizontalAngularOffsetDeg = 7.198f, verticalAngularOffsetDeg = +41.528f, ringId = 6},
                new Laser {horizontalAngularOffsetDeg = 7.007f, verticalAngularOffsetDeg = +39.653f, ringId = 7},
                new Laser {horizontalAngularOffsetDeg = 6.838f, verticalAngularOffsetDeg = +37.831f, ringId = 8},
                new Laser {horizontalAngularOffsetDeg = 6.688f, verticalAngularOffsetDeg = +36.055f, ringId = 9},
                new Laser {horizontalAngularOffsetDeg = 6.554f, verticalAngularOffsetDeg = +34.32f, ringId = 10},
                new Laser {horizontalAngularOffsetDeg = 6.434f, verticalAngularOffsetDeg = +32.619f, ringId = 11},
                new Laser {horizontalAngularOffsetDeg = 6.326f, verticalAngularOffsetDeg = +30.95f, ringId = 12},
                new Laser {horizontalAngularOffsetDeg = 6.228f, verticalAngularOffsetDeg = +29.308f, ringId = 13},
                new Laser {horizontalAngularOffsetDeg = 6.14f, verticalAngularOffsetDeg = +27.69f, ringId = 14},
                new Laser {horizontalAngularOffsetDeg = 6.059f, verticalAngularOffsetDeg = +26.094f, ringId = 15},
                new Laser {horizontalAngularOffsetDeg = 5.987f, verticalAngularOffsetDeg = +24.517f, ringId = 16},
                new Laser {horizontalAngularOffsetDeg = -5.27f, verticalAngularOffsetDeg = +22.964f, ringId = 17},
                new Laser {horizontalAngularOffsetDeg = -5.216f, verticalAngularOffsetDeg = +21.42f, ringId = 18},
                new Laser {horizontalAngularOffsetDeg = -5.167f, verticalAngularOffsetDeg = +19.889f, ringId = 19},
                new Laser {horizontalAngularOffsetDeg = -5.123f, verticalAngularOffsetDeg = +18.372f, ringId = 20},
                new Laser {horizontalAngularOffsetDeg = -5.083f, verticalAngularOffsetDeg = +16.865f, ringId = 21},
                new Laser {horizontalAngularOffsetDeg = -5.047f, verticalAngularOffsetDeg = +15.368f, ringId = 22},
                new Laser {horizontalAngularOffsetDeg = -5.016f, verticalAngularOffsetDeg = +13.88f, ringId = 23},
                new Laser {horizontalAngularOffsetDeg = -4.988f, verticalAngularOffsetDeg = +12.399f, ringId = 24},
                new Laser {horizontalAngularOffsetDeg = -4.963f, verticalAngularOffsetDeg = +10.925f, ringId = 25},
                new Laser {horizontalAngularOffsetDeg = -4.942f, verticalAngularOffsetDeg = +9.457f, ringId = 26},
                new Laser {horizontalAngularOffsetDeg = -4.924f, verticalAngularOffsetDeg = +7.994f, ringId = 27},
                new Laser {horizontalAngularOffsetDeg = -4.91f, verticalAngularOffsetDeg = +6.535f, ringId = 28},
                new Laser {horizontalAngularOffsetDeg = -4.898f, verticalAngularOffsetDeg = +5.079f, ringId = 29},
                new Laser {horizontalAngularOffsetDeg = -4.889f, verticalAngularOffsetDeg = +3.626f, ringId = 30},
                new Laser {horizontalAngularOffsetDeg = -4.884f, verticalAngularOffsetDeg = +2.175f, ringId = 31},
                new Laser {horizontalAngularOffsetDeg = -4.881f, verticalAngularOffsetDeg = +0.725f, ringId = 32},
                new Laser {horizontalAngularOffsetDeg = 5.493f, verticalAngularOffsetDeg = -0.725f, ringId = 33},
                new Laser {horizontalAngularOffsetDeg = 5.496f, verticalAngularOffsetDeg = -2.175f, ringId = 34},
                new Laser {horizontalAngularOffsetDeg = 5.502f, verticalAngularOffsetDeg = -3.626f, ringId = 35},
                new Laser {horizontalAngularOffsetDeg = 5.512f, verticalAngularOffsetDeg = -5.079f, ringId = 36},
                new Laser {horizontalAngularOffsetDeg = 5.525f, verticalAngularOffsetDeg = -6.534f, ringId = 37},
                new Laser {horizontalAngularOffsetDeg = 5.541f, verticalAngularOffsetDeg = -7.993f, ringId = 38},
                new Laser {horizontalAngularOffsetDeg = 5.561f, verticalAngularOffsetDeg = -9.456f, ringId = 39},
                new Laser {horizontalAngularOffsetDeg = 5.584f, verticalAngularOffsetDeg = -10.923f, ringId = 40},
                new Laser {horizontalAngularOffsetDeg = 5.611f, verticalAngularOffsetDeg = -12.397f, ringId = 41},
                new Laser {horizontalAngularOffsetDeg = 5.642f, verticalAngularOffsetDeg = -13.877f, ringId = 42},
                new Laser {horizontalAngularOffsetDeg = 5.676f, verticalAngularOffsetDeg = -15.365f, ringId = 43},
                new Laser {horizontalAngularOffsetDeg = 5.716f, verticalAngularOffsetDeg = -16.861f, ringId = 44},
                new Laser {horizontalAngularOffsetDeg = 5.759f, verticalAngularOffsetDeg = -18.368f, ringId = 45},
                new Laser {horizontalAngularOffsetDeg = 5.808f, verticalAngularOffsetDeg = -19.885f, ringId = 46},
                new Laser {horizontalAngularOffsetDeg = 5.862f, verticalAngularOffsetDeg = -21.415f, ringId = 47},
                new Laser {horizontalAngularOffsetDeg = 5.921f, verticalAngularOffsetDeg = -22.959f, ringId = 48},
                new Laser {horizontalAngularOffsetDeg = -5.33f, verticalAngularOffsetDeg = -24.524f, ringId = 49},
                new Laser {horizontalAngularOffsetDeg = -5.396f, verticalAngularOffsetDeg = -26.101f, ringId = 50},
                new Laser {horizontalAngularOffsetDeg = -5.469f, verticalAngularOffsetDeg = -27.697f, ringId = 51},
                new Laser {horizontalAngularOffsetDeg = -5.55f, verticalAngularOffsetDeg = -29.315f, ringId = 52},
                new Laser {horizontalAngularOffsetDeg = -5.64f, verticalAngularOffsetDeg = -30.957f, ringId = 53},
                new Laser {horizontalAngularOffsetDeg = -5.74f, verticalAngularOffsetDeg = -32.627f, ringId = 54},
                new Laser {horizontalAngularOffsetDeg = -5.85f, verticalAngularOffsetDeg = -34.328f, ringId = 55},
                new Laser {horizontalAngularOffsetDeg = -5.974f, verticalAngularOffsetDeg = -36.064f, ringId = 56},
                new Laser {horizontalAngularOffsetDeg = -6.113f, verticalAngularOffsetDeg = -37.84f, ringId = 57},
                new Laser {horizontalAngularOffsetDeg = -6.269f, verticalAngularOffsetDeg = -39.662f, ringId = 58},
                new Laser {horizontalAngularOffsetDeg = -6.447f, verticalAngularOffsetDeg = -41.537f, ringId = 59},
                new Laser {horizontalAngularOffsetDeg = -6.651f, verticalAngularOffsetDeg = -43.475f, ringId = 60},
                new Laser {horizontalAngularOffsetDeg = -6.887f, verticalAngularOffsetDeg = -45.487f, ringId = 61},
                new Laser {horizontalAngularOffsetDeg = -7.163f, verticalAngularOffsetDeg = -47.587f, ringId = 62},
                new Laser {horizontalAngularOffsetDeg = -7.493f, verticalAngularOffsetDeg = -49.795f, ringId = 63},
                new Laser {horizontalAngularOffsetDeg = -7.892f, verticalAngularOffsetDeg = -52.133f, ringId = 64},
            }
        };

        // https://velodynelidar.com/wp-content/uploads/2019/12/63-9243-Rev-E-VLP-16-User-Manual.pdf
        public static LaserArray VelodyneVLP16 => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(0.0f, 37.7f, 0.0f),
            focalDistanceMm = 0.0f,
            lasers = new[]
            {
                new Laser {verticalAngularOffsetDeg = +15.0f, verticalLinearOffsetMm = +11.2f, ringId = 1, timeOffset = 0.0f },
                new Laser {verticalAngularOffsetDeg = -1.0f, verticalLinearOffsetMm = -0.7f, ringId = 9, timeOffset = 0.002304f },
                new Laser {verticalAngularOffsetDeg = +13.0f, verticalLinearOffsetMm = +9.7f, ringId = 2, timeOffset = 0.004608f },
                new Laser {verticalAngularOffsetDeg = -3.0f, verticalLinearOffsetMm = -2.2f, ringId = 10, timeOffset = 0.006912f },
                new Laser {verticalAngularOffsetDeg = +11.0f, verticalLinearOffsetMm = +8.1f, ringId = 3, timeOffset = 0.009216f },
                new Laser {verticalAngularOffsetDeg = -5.0f, verticalLinearOffsetMm = -3.7f, ringId = 11, timeOffset = 0.011520f },
                new Laser {verticalAngularOffsetDeg = +9.0f, verticalLinearOffsetMm = +6.6f, ringId = 4, timeOffset = 0.013824f },
                new Laser {verticalAngularOffsetDeg = -7.0f, verticalLinearOffsetMm = -5.1f, ringId = 12, timeOffset = 0.016128f },
                new Laser {verticalAngularOffsetDeg = +7.0f, verticalLinearOffsetMm = +5.1f, ringId = 5, timeOffset = 0.018432f },
                new Laser {verticalAngularOffsetDeg = -9.0f, verticalLinearOffsetMm = -6.6f, ringId = 13, timeOffset = 0.020736f },
                new Laser {verticalAngularOffsetDeg = +5.0f, verticalLinearOffsetMm = +3.7f, ringId = 6, timeOffset = 0.023040f },
                new Laser {verticalAngularOffsetDeg = -11.0f, verticalLinearOffsetMm = -8.1f, ringId = 14, timeOffset = 0.025344f },
                new Laser {verticalAngularOffsetDeg = +3.0f, verticalLinearOffsetMm = +2.2f, ringId = 7, timeOffset = 0.027648f },
                new Laser {verticalAngularOffsetDeg = -13.0f, verticalLinearOffsetMm = -9.7f, ringId = 15, timeOffset = 0.029952f },
                new Laser {verticalAngularOffsetDeg = +1.0f, verticalLinearOffsetMm = +0.7f, ringId = 8, timeOffset = 0.032256f },
                new Laser {verticalAngularOffsetDeg = -15.0f, verticalLinearOffsetMm = -11.2f, ringId = 16, timeOffset = 0.034560f },
            }
        };

        // https://icave2.cse.buffalo.edu/resources/sensor-modeling/VLP32CManual.pdf
        public static LaserArray VelodyneVLP32C => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(0.0f, 37.34f, 0.0f),
            focalDistanceMm = 42.4f,
            lasers = new[]
            {
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 25f, ringId = 1, timeOffset = 0.027648f}, //LaserID = 0
                new Laser {horizontalAngularOffsetDeg = -4.2f, verticalAngularOffsetDeg = 1f, ringId = 2, timeOffset = 0.002304f}, //LaserID = 1
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 1.667f, ringId = 3, timeOffset = 0.018432f}, //LaserID = 2
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 15.639f, ringId = 4, timeOffset = 0.006912f}, //LaserID = 3
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 11.31f, ringId = 5, timeOffset = 0.032256f}, //LaserID = 4
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 0f, ringId = 6, timeOffset = 0.011520f}, //LaserID = 5
                new Laser {horizontalAngularOffsetDeg = 4.2f, verticalAngularOffsetDeg = 0.667f, ringId = 7, timeOffset = 0.023040f}, //LaserID = 6
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 8.843f, ringId = 8, timeOffset = 0.016128f}, //LaserID = 7
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 7.254f, ringId = 9, timeOffset = 0.013824f }, //LaserID = 8
                new Laser {horizontalAngularOffsetDeg = -4.2f, verticalAngularOffsetDeg = -0.333f, ringId = 10, timeOffset = 0.004608f}, //LaserID = 9
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 0.333f, ringId = 11, timeOffset = 0.020736f}, //LaserID = 10
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 6.148f, ringId = 12, timeOffset = 0.025344f}, //LaserID = 11
                new Laser {horizontalAngularOffsetDeg = 4.2f, verticalAngularOffsetDeg = 5.333f, ringId = 13, timeOffset = 0.009216f}, //LaserID = 12
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = -1.333f, ringId = 14, timeOffset = 0.0f}, //LaserID = 13
                new Laser {horizontalAngularOffsetDeg = 4.2f, verticalAngularOffsetDeg = -0.667f, ringId = 15, timeOffset = 0.029952f}, //LaserID = 14
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 4f, ringId = 16, timeOffset = 0.034560f}, //LaserID = 15
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 4.667f, ringId = 17, timeOffset = 0.011520f}, //LaserID = 16
                new Laser {horizontalAngularOffsetDeg = -4.2f, verticalAngularOffsetDeg = -1.667f, ringId = 18, timeOffset = 0.002304f}, //LaserID = 17
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = -1f, ringId = 19, timeOffset = 0.027648f}, //LaserID = 18
                new Laser {horizontalAngularOffsetDeg = -4.2f, verticalAngularOffsetDeg = 3.667f, ringId = 20, timeOffset = 0.032256f}, //LaserID = 19
                new Laser {horizontalAngularOffsetDeg = 4.2f, verticalAngularOffsetDeg = 3.333f, ringId = 21, timeOffset = 0.016128f}, //LaserID = 20
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = -3.333f, ringId = 22, timeOffset = 0.006912f}, //LaserID = 21
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = -2.333f, ringId = 23, timeOffset = 0.018432f}, //LaserID = 22
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 2.667f, ringId = 24, timeOffset = 0.023040f}, //LaserID = 23
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = 3f, ringId = 25, timeOffset = 0.025344f}, //LaserID = 24
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = -7f, ringId = 26, timeOffset = 0.013824f}, //LaserID = 25
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = -4.667f, ringId = 27, timeOffset = 0.034560f}, //LaserID = 26
                new Laser {horizontalAngularOffsetDeg = -4.2f, verticalAngularOffsetDeg = 2.333f, ringId = 28, timeOffset = 0.009216f}, //LaserID = 27
                new Laser {horizontalAngularOffsetDeg = 4.2f, verticalAngularOffsetDeg = 2f, ringId = 29, timeOffset = 0.020736f}, //LaserID = 28
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = -15f, ringId = 30, timeOffset = 0.004608f}, //LaserID = 29
                new Laser {horizontalAngularOffsetDeg = 1.4f, verticalAngularOffsetDeg = -10.333f, ringId = 31, timeOffset = 0.029952f}, //LaserID = 30
                new Laser {horizontalAngularOffsetDeg = -1.4f, verticalAngularOffsetDeg = 1.333f, ringId = 32, timeOffset = 0.0f}, //LaserID = 31
            }
        };

        // https://gpsolution.oss-cn-beijing.aliyuncs.com/manual/LiDAR/MANUAL%2CUSERS%2CVLP-128.pdf
        public static LaserArray VelodyneVLS128 => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(0.0f, 66.11f, 0.0f),
            focalDistanceMm = 58.63f,
            lasers = new[]
            {
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +11.742f, ringId = 5},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +1.99f, ringId = 54},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -3.4f, ringId = 103},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +5.29f, ringId = 24},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +0.78f, ringId = 65},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -4.61f, ringId = 114},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +4.08f, ringId = 35},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -1.31f, ringId = 84},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +6.5f, ringId = 13},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +1.11f, ringId = 62},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -4.28f, ringId = 111},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +4.41f, ringId = 32},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -0.1f, ringId = 73},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -6.48f, ringId = 122},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +3.2f, ringId = 43},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -2.19f, ringId = 92},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +3.86f, ringId = 37},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -1.53f, ringId = 86},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +9.244f, ringId = 7},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +1.77f, ringId = 56},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -2.74f, ringId = 97},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +5.95f, ringId = 18},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +0.56f, ringId = 67},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -4.83f, ringId = 116},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +2.98f, ringId = 45},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -2.41f, ringId = 94},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +6.28f, ringId = 15},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +0.89f, ringId = 64},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -3.62f, ringId = 105},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +5.07f, ringId = 26},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -0.32f, ringId = 75},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -7.58f, ringId = 124},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +0.34f, ringId = 69},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -5.18f, ringId = 118},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +3.64f, ringId = 39},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -1.75f, ringId = 88},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +25f, ringId = 1},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +2.43f, ringId = 50},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -2.96f, ringId = 99},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +5.73f, ringId = 20},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -0.54f, ringId = 77},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -9.7f, ringId = 126},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +2.76f, ringId = 47},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -2.63f, ringId = 96},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +7.65f, ringId = 9},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +1.55f, ringId = 58},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -3.84f, ringId = 107},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +4.85f, ringId = 28},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -3.18f, ringId = 101},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +5.51f, ringId = 22},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +0.12f, ringId = 71},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -5.73f, ringId = 120},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +4.3f, ringId = 33},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -1.09f, ringId = 82},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +16.042f, ringId = 3},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +2.21f, ringId = 52},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -4.06f, ringId = 109},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +4.63f, ringId = 30},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -0.76f, ringId = 79},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -15f, ringId = 128},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +3.42f, ringId = 41},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -1.97f, ringId = 90},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +6.85f, ringId = 11},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +1.33f, ringId = 60},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +5.62f, ringId = 21},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +0.23f, ringId = 70},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -5.43f, ringId = 119},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +3.53f, ringId = 40},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -0.98f, ringId = 81},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +19.582f, ringId = 2},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +2.32f, ringId = 51},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -3.07f, ringId = 100},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +4.74f, ringId = 29},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -0.65f, ringId = 78},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -11.75f, ringId = 127},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +2.65f, ringId = 48},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -1.86f, ringId = 89},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +7.15f, ringId = 10},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +1.44f, ringId = 59},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -3.95f, ringId = 108},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +2.1f, ringId = 53},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -3.29f, ringId = 102},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +5.4f, ringId = 23},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +0.01f, ringId = 72},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -4.5f, ringId = 113},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +4.19f, ringId = 34},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -1.2f, ringId = 83},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +13.565f, ringId = 4},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = +1.22f, ringId = 61},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = -4.17f, ringId = 110},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +4.52f, ringId = 31},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -0.87f, ringId = 80},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = -6.08f, ringId = 121},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +3.31f, ringId = 42},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -2.008f, ringId = 91},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +6.65f, ringId = 12},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -1.42f, ringId = 85},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +10.346f, ringId = 6},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +1.88f, ringId = 55},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -3.51f, ringId = 104},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +6.06f, ringId = 17},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = +0.67f, ringId = 66},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -4.72f, ringId = 115},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +3.97f, ringId = 36},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -2.3f, ringId = 93},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +6.39f, ringId = 14},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = +1f, ringId = 63},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = -4.39f, ringId = 112},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +5.18f, ringId = 25},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -0.21f, ringId = 74},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = -6.98f, ringId = 123},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +3.09f, ringId = 44},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -4.98f, ringId = 117},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +3.75f, ringId = 38},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -1.64f, ringId = 87},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +8.352f, ringId = 8},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +2.54f, ringId = 49},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -2.85f, ringId = 98},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +5.84f, ringId = 19},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = +0.45f, ringId = 68},
                new Laser {horizontalAngularOffsetDeg = +6.354f, verticalAngularOffsetDeg = -8.43f, ringId = 125},
                new Laser {horizontalAngularOffsetDeg = +4.548f, verticalAngularOffsetDeg = +2.87f, ringId = 46},
                new Laser {horizontalAngularOffsetDeg = +2.732f, verticalAngularOffsetDeg = -2.52f, ringId = 95},
                new Laser {horizontalAngularOffsetDeg = +0.911f, verticalAngularOffsetDeg = +6.17f, ringId = 16},
                new Laser {horizontalAngularOffsetDeg = -0.911f, verticalAngularOffsetDeg = +1.66f, ringId = 57},
                new Laser {horizontalAngularOffsetDeg = -2.732f, verticalAngularOffsetDeg = -3.73f, ringId = 106},
                new Laser {horizontalAngularOffsetDeg = -4.548f, verticalAngularOffsetDeg = +4.96f, ringId = 27},
                new Laser {horizontalAngularOffsetDeg = -6.354f, verticalAngularOffsetDeg = -0.43f, ringId = 76},
            }
        };

        // Data can be get by Ouster TCP API in get_beam_intrinsics, get_lidar_intrinsics fields
        // https://static.ouster.dev/sensor-docs/image_route1/image_route2/common_sections/API/tcp-api.html
        // Data are taken from TOP lidar in a file located in
        // Assets/RGLUnityPlugin/RawData/ouster_status.txt
        public static LaserArray OusterOS1_64 => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(0.0f, 36.18f, 0.0f),
            focalDistanceMm = 12.163f,
            lasers = new[]
            {
                new Laser {horizontalAngularOffsetDeg = 3.057f, verticalAngularOffsetDeg = -16.352f, ringId = 1},
                new Laser {horizontalAngularOffsetDeg = 0.921f, verticalAngularOffsetDeg = -15.772f, ringId = 2},
                new Laser {horizontalAngularOffsetDeg = -1.188f, verticalAngularOffsetDeg = -15.219f, ringId = 3},
                new Laser {horizontalAngularOffsetDeg = -3.313f, verticalAngularOffsetDeg = -14.685f, ringId = 4},
                new Laser {horizontalAngularOffsetDeg = 3.051f, verticalAngularOffsetDeg = -14.191f, ringId = 5},
                new Laser {horizontalAngularOffsetDeg = 0.928f, verticalAngularOffsetDeg = -13.622f, ringId = 6},
                new Laser {horizontalAngularOffsetDeg = -1.152f, verticalAngularOffsetDeg = -13.079f, ringId = 7},
                new Laser {horizontalAngularOffsetDeg = -3.256f, verticalAngularOffsetDeg = -12.564f, ringId = 8},
                new Laser {horizontalAngularOffsetDeg = 3.044f, verticalAngularOffsetDeg = -12.072f, ringId = 9},
                new Laser {horizontalAngularOffsetDeg = 0.953f, verticalAngularOffsetDeg = -11.518f, ringId = 10},
                new Laser {horizontalAngularOffsetDeg = -1.131f, verticalAngularOffsetDeg = -10.984f, ringId = 11},
                new Laser {horizontalAngularOffsetDeg = -3.204f, verticalAngularOffsetDeg = -10.468f, ringId = 12},
                new Laser {horizontalAngularOffsetDeg = 3.042f, verticalAngularOffsetDeg = -9.982f, ringId = 13},
                new Laser {horizontalAngularOffsetDeg = 0.954f, verticalAngularOffsetDeg = -9.435f, ringId = 14},
                new Laser {horizontalAngularOffsetDeg = -1.105f, verticalAngularOffsetDeg = -8.896f, ringId = 15},
                new Laser {horizontalAngularOffsetDeg = -3.168f, verticalAngularOffsetDeg = -8.380f, ringId = 16},
                new Laser {horizontalAngularOffsetDeg = 3.044f, verticalAngularOffsetDeg = -7.903f, ringId = 17},
                new Laser {horizontalAngularOffsetDeg = 0.986f, verticalAngularOffsetDeg = -7.368f, ringId = 18},
                new Laser {horizontalAngularOffsetDeg = -1.082f, verticalAngularOffsetDeg = -6.845f, ringId = 19},
                new Laser {horizontalAngularOffsetDeg = -3.135f, verticalAngularOffsetDeg = -6.312f, ringId = 20},
                new Laser {horizontalAngularOffsetDeg = 3.047f, verticalAngularOffsetDeg = -5.840f, ringId = 21},
                new Laser {horizontalAngularOffsetDeg = 0.995f, verticalAngularOffsetDeg = -5.306f, ringId = 22},
                new Laser {horizontalAngularOffsetDeg = -1.064f, verticalAngularOffsetDeg = -4.771f, ringId = 23},
                new Laser {horizontalAngularOffsetDeg = -3.106f, verticalAngularOffsetDeg = -4.251f, ringId = 24},
                new Laser {horizontalAngularOffsetDeg = 3.071f, verticalAngularOffsetDeg = -3.779f, ringId = 25},
                new Laser {horizontalAngularOffsetDeg = 1.013f, verticalAngularOffsetDeg = -3.240f, ringId = 26},
                new Laser {horizontalAngularOffsetDeg = -1.036f, verticalAngularOffsetDeg = -2.714f, ringId = 27},
                new Laser {horizontalAngularOffsetDeg = -3.082f, verticalAngularOffsetDeg = -2.189f, ringId = 28},
                new Laser {horizontalAngularOffsetDeg = 3.080f, verticalAngularOffsetDeg = -1.717f, ringId = 29},
                new Laser {horizontalAngularOffsetDeg = 1.031f, verticalAngularOffsetDeg = -1.187f, ringId = 30},
                new Laser {horizontalAngularOffsetDeg = -1.016f, verticalAngularOffsetDeg = -0.650f, ringId = 31},
                new Laser {horizontalAngularOffsetDeg = -3.076f, verticalAngularOffsetDeg = -0.125f, ringId = 32},
                new Laser {horizontalAngularOffsetDeg = 3.103f, verticalAngularOffsetDeg = 0.347f, ringId = 33},
                new Laser {horizontalAngularOffsetDeg = 1.048f, verticalAngularOffsetDeg = 0.874f, ringId = 34},
                new Laser {horizontalAngularOffsetDeg = -1.008f, verticalAngularOffsetDeg = 1.405f, ringId = 35},
                new Laser {horizontalAngularOffsetDeg = -3.062f, verticalAngularOffsetDeg = 1.936f, ringId = 36},
                new Laser {horizontalAngularOffsetDeg = 3.114f, verticalAngularOffsetDeg = 2.406f, ringId = 37},
                new Laser {horizontalAngularOffsetDeg = 1.066f, verticalAngularOffsetDeg = 2.937f, ringId = 38},
                new Laser {horizontalAngularOffsetDeg = -0.995f, verticalAngularOffsetDeg = 3.466f, ringId = 39},
                new Laser {horizontalAngularOffsetDeg = -3.055f, verticalAngularOffsetDeg = 4.002f, ringId = 40},
                new Laser {horizontalAngularOffsetDeg = 3.134f, verticalAngularOffsetDeg = 4.472f, ringId = 41},
                new Laser {horizontalAngularOffsetDeg = 1.076f, verticalAngularOffsetDeg = 4.999f, ringId = 42},
                new Laser {horizontalAngularOffsetDeg = -0.980f, verticalAngularOffsetDeg = 5.530f, ringId = 43},
                new Laser {horizontalAngularOffsetDeg = -3.052f, verticalAngularOffsetDeg = 6.066f, ringId = 44},
                new Laser {horizontalAngularOffsetDeg = 3.156f, verticalAngularOffsetDeg = 6.538f, ringId = 45},
                new Laser {horizontalAngularOffsetDeg = 1.099f, verticalAngularOffsetDeg = 7.063f, ringId = 46},
                new Laser {horizontalAngularOffsetDeg = -0.972f, verticalAngularOffsetDeg = 7.597f, ringId = 47},
                new Laser {horizontalAngularOffsetDeg = -3.031f, verticalAngularOffsetDeg = 8.144f, ringId = 48},
                new Laser {horizontalAngularOffsetDeg = 3.175f, verticalAngularOffsetDeg = 8.612f, ringId = 49},
                new Laser {horizontalAngularOffsetDeg = 1.110f, verticalAngularOffsetDeg = 9.137f, ringId = 50},
                new Laser {horizontalAngularOffsetDeg = -0.959f, verticalAngularOffsetDeg = 9.672f, ringId = 51},
                new Laser {horizontalAngularOffsetDeg = -3.034f, verticalAngularOffsetDeg = 10.218f, ringId = 52},
                new Laser {horizontalAngularOffsetDeg = 3.204f, verticalAngularOffsetDeg = 10.695f, ringId = 53},
                new Laser {horizontalAngularOffsetDeg = 1.132f, verticalAngularOffsetDeg = 11.215f, ringId = 54},
                new Laser {horizontalAngularOffsetDeg = -0.964f, verticalAngularOffsetDeg = 11.757f, ringId = 55},
                new Laser {horizontalAngularOffsetDeg = -3.065f, verticalAngularOffsetDeg = 12.316f, ringId = 56},
                new Laser {horizontalAngularOffsetDeg = 3.244f, verticalAngularOffsetDeg = 12.791f, ringId = 57},
                new Laser {horizontalAngularOffsetDeg = 1.140f, verticalAngularOffsetDeg = 13.321f, ringId = 58},
                new Laser {horizontalAngularOffsetDeg = -0.963f, verticalAngularOffsetDeg = 13.860f, ringId = 59},
                new Laser {horizontalAngularOffsetDeg = -3.066f, verticalAngularOffsetDeg = 14.423f, ringId = 60},
                new Laser {horizontalAngularOffsetDeg = 3.282f, verticalAngularOffsetDeg = 14.925f, ringId = 61},
                new Laser {horizontalAngularOffsetDeg = 1.169f, verticalAngularOffsetDeg = 15.458f, ringId = 62},
                new Laser {horizontalAngularOffsetDeg = -0.971f, verticalAngularOffsetDeg = 16.011f, ringId = 63},
                new Laser {horizontalAngularOffsetDeg = -3.108f, verticalAngularOffsetDeg = 16.598f, ringId = 64},
            }
        };

        // https://www.hesaitech.com/wp-content/uploads/2023/05/AT128E2X_User_Manual_A01-en-230510.pdf
        public static LaserArray HesaiAT128E2X => new LaserArray
        {
            centerOfMeasurementLinearOffsetMm = new Vector3(-17.1f, 24.0f, 41.65f),
            focalDistanceMm = 0.0f,
            lasers = new[]
            {
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -12.93f, ringId = 128, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -12.73f, ringId = 127, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -12.53f, ringId = 126, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -12.33f, ringId = 125, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -12.13f, ringId = 124, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -11.93f, ringId = 123, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -11.73f, ringId = 122, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -11.53f, ringId = 121, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -11.33f, ringId = 120, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -11.13f, ringId = 119, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -10.93f, ringId = 118, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -10.73f, ringId = 117, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -10.53f, ringId = 116, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -10.33f, ringId = 115, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -10.13f, ringId = 114, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -9.93f, ringId = 113, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -9.73f, ringId = 112, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -9.53f, ringId = 111, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -9.33f, ringId = 110, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -9.13f, ringId = 109, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -8.93f, ringId = 108, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -8.73f, ringId = 107, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -8.53f, ringId = 106, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -8.33f, ringId = 105, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -8.13f, ringId = 104, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -7.93f, ringId = 103, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -7.73f, ringId = 102, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -7.53f, ringId = 101, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -7.33f, ringId = 100, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -7.13f, ringId = 99, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -6.93f, ringId = 98, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -6.73f, ringId = 97, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -6.53f, ringId = 96, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -6.33f, ringId = 95, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -6.13f, ringId = 94, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -5.93f, ringId = 93, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -5.73f, ringId = 92, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -5.53f, ringId = 91, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -5.33f, ringId = 90, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -5.13f, ringId = 89, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -4.93f, ringId = 88, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -4.73f, ringId = 87, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -4.53f, ringId = 86, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -4.33f, ringId = 85, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -4.13f, ringId = 84, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -3.93f, ringId = 83, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -3.73f, ringId = 82, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = -3.53f, ringId = 81, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -3.33f, ringId = 80, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -3.13f, ringId = 79, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -2.93f, ringId = 78, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -2.73f, ringId = 77, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -2.53f, ringId = 76, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -2.33f, ringId = 75, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -2.13f, ringId = 74, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -1.93f, ringId = 73, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -1.73f, ringId = 72, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -1.53f, ringId = 71, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -1.33f, ringId = 70, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -1.13f, ringId = 69, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -0.93f, ringId = 68, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -0.73f, ringId = 67, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = -0.53f, ringId = 66, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = -0.33f, ringId = 65, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = -0.13f, ringId = 64, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 0.07f, ringId = 63, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 0.27f, ringId = 62, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 0.47f, ringId = 61, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 0.67f, ringId = 60, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 0.87f, ringId = 59, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 1.07f, ringId = 58, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 1.27f, ringId = 57, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 1.47f, ringId = 56, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 1.67f, ringId = 55, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 1.87f, ringId = 54, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 2.07f, ringId = 53, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 2.27f, ringId = 52, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 2.47f, ringId = 51, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 2.67f, ringId = 50, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 2.87f, ringId = 49, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 3.07f, ringId = 48, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 3.27f, ringId = 47, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 3.47f, ringId = 46, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 3.67f, ringId = 45, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 3.87f, ringId = 44, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 4.07f, ringId = 43, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 4.27f, ringId = 42, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 4.47f, ringId = 41, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 4.67f, ringId = 40, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 4.87f, ringId = 39, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 5.07f, ringId = 38, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 5.27f, ringId = 37, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 5.47f, ringId = 36, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 5.67f, ringId = 35, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 5.87f, ringId = 34, minRange = 7.2f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 6.07f, ringId = 33, minRange = 0.5f, maxRange = 200f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 6.27f, ringId = 32, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 6.47f, ringId = 31, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 6.67f, ringId = 30, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 6.87f, ringId = 29, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 7.07f, ringId = 28, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 7.27f, ringId = 27, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 7.47f, ringId = 26, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 7.67f, ringId = 25, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 7.87f, ringId = 24, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 8.07f, ringId = 23, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 8.27f, ringId = 22, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 8.47f, ringId = 21, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 8.67f, ringId = 20, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 8.87f, ringId = 19, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 2.4f, verticalAngularOffsetDeg = 9.07f, ringId = 18, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -0.65f, verticalAngularOffsetDeg = 9.27f, ringId = 17, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 9.47f, ringId = 16, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 9.67f, ringId = 15, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 9.87f, ringId = 14, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 10.07f, ringId = 13, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 10.27f, ringId = 12, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 10.47f, ringId = 11, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 10.67f, ringId = 10, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 10.87f, ringId = 9, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 11.07f, ringId = 8, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 11.27f, ringId = 7, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 11.47f, ringId = 6, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 11.67f, ringId = 5, minRange = 0.5f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 11.87f, ringId = 4, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 12.07f, ringId = 3, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = -2.4f, verticalAngularOffsetDeg = 12.27f, ringId = 2, minRange = 7.2f, maxRange = 100f},
                new Laser {horizontalAngularOffsetDeg = 0.65f, verticalAngularOffsetDeg = 12.47f, ringId = 1, minRange = 0.5f, maxRange = 100f},
            }
        };
    }
}
