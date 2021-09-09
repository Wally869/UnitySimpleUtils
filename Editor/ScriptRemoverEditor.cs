using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MissingComponentRemover))]
public class MissingComponentRemoverEditor : Editor
{

        public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        MissingComponentRemover obj = (MissingComponentRemover)target;

        if (GUILayout.Button("Clean")) {
            obj.Clean();

        }

    }



}