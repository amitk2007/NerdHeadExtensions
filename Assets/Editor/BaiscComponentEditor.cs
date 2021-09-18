using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NerdHeadExtensions.EditorSerializaion;

[CustomEditor(typeof(BasicComponentScript))]
public class BaiscComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.DrawDefaultInspector();
        EditorSerializaion.DrawCustomLable(20, "Hi **//my// name is** Amit");
        EditorSerializaion.DrawSerializedField(serializedObject, "text", "Text");
        EditorSerializaion.DrawSerializedField(serializedObject, "pos", "Posotion");
    }
}
