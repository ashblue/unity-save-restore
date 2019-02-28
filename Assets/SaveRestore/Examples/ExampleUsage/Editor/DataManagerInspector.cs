using UnityEditor;
using UnityEngine;

namespace CleverCrow.SaveRestore.Examples.Editors {
    [CustomEditor(typeof(DataManager))]
    public class DataManagerInspector : Editor {
        public override void OnInspectorGUI () {
            base.OnInspectorGUI();

            if (!Application.isPlaying) return;

            var manager = target as DataManager;
            if (GUILayout.Button("Save")) {
                manager.Save();
            }

            if (GUILayout.Button("Load")) {
                manager.Load();
            }
        }
    }
}