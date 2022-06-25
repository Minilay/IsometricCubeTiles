using System;
using Client.Scripts.Tools;
using UnityEngine;

namespace Client.Scripts.Objects
{
    [Serializable]
    public class WaveData
    {
        [field: SerializeField] public WaveParameters FirstWave { get; set; }
        [field: SerializeField] public WaveParameters SecondWave { get; set; }

        public WaveData(WaveParameters firstWave, WaveParameters secondWave)
        {
            FirstWave = firstWave;
            SecondWave = secondWave;
        }
    }
}