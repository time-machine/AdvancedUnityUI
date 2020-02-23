using System.IO;
using System.Linq;
using System.Text;
using Assets.Scripts.Managers;
using Boo.Lang;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Editor
{
    [CustomEditor(typeof(WindowManager))]
    public class WindowManagerEditor : UnityEditor.Editor
    {
        private ReorderableList list;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
            if (GUILayout.Button("Generate Window Enums"))
            {
                var windows = ((WindowManager)target).windows;
                var sb = new StringBuilder();
                sb.Append("public enum Windows{");
                sb.Append("None,");
                sb.Append(string.Join(",", from window in windows select window.name.Replace(" ", "")));
                sb.Append("}");
                var path = EditorUtility.SaveFilePanel("Save The Window Enums", "", "WindowEnums.cs", "cs");
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    using (var writer = new StreamWriter(fs))
                    {
                        writer.Write(sb.ToString());
                    }
                }
                AssetDatabase.Refresh();
            }
        }

        private void OnEnable()
        {
            list = new ReorderableList(serializedObject, serializedObject.FindProperty("windows"), true, true, true, true);
            list.drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Windows");
            list.drawElementCallback = (rect, index, active, focused) =>
            {
                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, Screen.width - 75, EditorGUIUtility.singleLineHeight),
                    element, GUIContent.none);
            };
        }
    }
}