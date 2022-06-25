using System;
using UnityEngine;

namespace Client.Scripts.Tools
{
    [Serializable]
    public class WaveParameters
    {
        [field: SerializeField] public float Amplitude { get; private set; }
        [field: SerializeField] public float Period { get; private set; }
        [field: SerializeField] public float WaveLength { get; private set; }

        [field: Range(0, 360)]
        [field: SerializeField] public float WaveAngle { get; private set; }


        public WaveParameters(float amplitude, float period, float waveLength, float waveAngle)
        {
            Amplitude = amplitude;
            Period = period <= 0 ? 0.001f : period;
            WaveLength = waveLength > 0 ? waveLength : 0.001f;
            WaveAngle = waveAngle;
        }
        
        
    }
}