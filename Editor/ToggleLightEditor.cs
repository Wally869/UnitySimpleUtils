using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ToggleLights))]
public class ToggleLightsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ToggleLights obj = (ToggleLights)target;

        if (GUILayout.Button("Set State Lights"))
        {
            obj.SetStateLightsOfType();

        }
    }

}
