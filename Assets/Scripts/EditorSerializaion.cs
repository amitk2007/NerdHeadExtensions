using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NerdHeadExtensions;

namespace NerdHeadExtensions.EditorSerializaion
{
    public class EditorSerializaion : Editor
    {
        public static void DrawSerializedField(SerializedObject sb, string name, string title)
        {
            // In Class
            SerializedProperty property;
            // OnEnabled
            property = sb.FindProperty(name);
            // OnInspectorGUI
            EditorGUILayout.PropertyField(property, new GUIContent(title));
            sb.ApplyModifiedProperties();
        }

        /// <summary>
        /// Draw a lable with rich text easily
        /// </summary>
        /// <param name="text">Use
        /// **Bold Text**
        /// //Italic Text//
        /// </param>
        public static void DrawCustomLable(string text)
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            text = Formating(text);
            EditorGUILayout.LabelField(text, style);
        }

        /// <summary>
        /// Draw a lable with rich text easily
        /// </summary>
        /// <param name="size">The size of the lable</param>
        /// <param name="text">Use
        /// **Bold Text**
        /// //Italic Text//
        /// </param>
        public static void DrawCustomLable(float size, string text)
        {
            GUIStyle style = new GUIStyle();
            style.richText = true;
            text = Formating(text);
            EditorGUILayout.LabelField("<size=" + size + "> " + text + "</size>", style);
            GUILayout.Space(size - 12);
        }

        public static string Formating(string text)
        {
            text = text.ReplaceRichText("**", "<b>", "</b>");
            text = text.ReplaceRichText("//", "<i>", "</i>");
            return text;
        }
    }
}
