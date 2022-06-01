using System;
using Unity.Mathematics;
using UnityEngine;

namespace Client.Scripts
{
    public class HarmonicMotion
    {
        private readonly float _amplitude;
        private readonly float _period;
        private readonly float _waveLength;
        private readonly float _phase;


        public HarmonicMotion(float amplitude, float period, float waveLength, float phase)
        {
            _amplitude = amplitude;
            _period = period;
            _waveLength = waveLength;
            _phase = phase;
        }
        
        public float GetPosition(float t)
        {
            var angularFrequency = 2 * Mathf.PI / _period;
            var waveNumber =  2 * Mathf.PI / _waveLength;

            return _amplitude * Mathf.Sin(waveNumber * _phase + angularFrequency * t);
        }
    }
}