using System;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.CXExtensions
{
    /// <summary>
    /// This shows a error box indicates that this field cannot be null
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class LimitMaxIntAttribute : MultiPropertyAttribute
    {
        public LimitMaxIntAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        private int _maxValue;

#if UNITY_EDITOR
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label, FieldInfo fieldInfo)
        {
            base.OnGUI(position, property, label, fieldInfo);

            if(property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = Mathf.Min(property.intValue, _maxValue);
                return;
            }

            EditorGUILayout.HelpBox("Limit Max cannot be used on types other than int! if you want to limit float, use LimitMaxAttribute instead!", MessageType.Warning);
        }
#endif
    }
}
