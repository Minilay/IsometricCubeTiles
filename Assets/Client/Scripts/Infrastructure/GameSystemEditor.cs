using UnityEditor;
using UnityEngine;

namespace Client.Scripts.Infrastructure
{ 
    [CustomEditor(typeof(GameSystem))]
    public class GameSystemEditor : Editor
    {
        private GameSystem _gameSystem;
        private bool _isSwitch; 

        private void OnEnable()
        {
            _gameSystem =(GameSystem)target ;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _isSwitch = GUILayout.Toggle(_isSwitch, "switch");
            _gameSystem.Switch(_isSwitch);
        }
    } 
}