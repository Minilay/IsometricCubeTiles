using System;
using UnityEngine;

namespace Client.Scripts.Tools
{
    [Serializable]
    public struct WaveParameters
    {
        [field:SerializeField] public float Amplitude { get; set; }
        [SerializeField] private float _period;
        [SerializeField] private float _waveLength;
        [Range(0, 360)]
        [SerializeField] private float _waveDirectionAngle;


        public float Period
        {
            get => _period;
            set => _period = value <= 0 ? 0.001f : value;
        }
        public float WaveLength
        {
            get => _waveLength;
            set => _waveLength = value > 0 ? value : 0.001f;
        }

        public float WaveDirectionAngle
        {
            get => _waveDirectionAngle;
            set => _waveDirectionAngle = value;
        }
    }
}