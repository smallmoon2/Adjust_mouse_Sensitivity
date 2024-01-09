﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditorInternal;

namespace RainbowArt.CleanFlatUI
{
    [CustomEditor(typeof(TooltipSnap))]
    public class TooltipSnapEditor : Editor
    {
        SerializedProperty tooltip;       

        protected virtual void OnEnable()
        {
            tooltip = serializedObject.FindProperty("tooltip");           
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(tooltip);                
            serializedObject.ApplyModifiedProperties();           
        }
    }
}
