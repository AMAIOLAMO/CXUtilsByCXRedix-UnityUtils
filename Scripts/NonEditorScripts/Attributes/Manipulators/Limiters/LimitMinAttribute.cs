using System;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.CXExtensions
{
    /// <summary>
    /// This limits the target value above a certain threshold
    /// </summary>
    [AttributeUsage( AttributeTargets.Field )]
    public class LimitMinAttribute : MultiPropertyAttribute
    {
        public LimitMinAttribute( float minValue )
        {
            _minValue = minValue;
        }

        private float _minValue;

#if UNITY_EDITOR

        public override SerializedProperty BuildProperty( SerializedProperty property )
        {
            if ( property.propertyType == SerializedPropertyType.Float )
            {
                property.floatValue = Mathf.Min( property.floatValue, _minValue );
                return property;
            }

            EditorGUILayout.HelpBox( "Limit Min cannot be used on types other than float! if you want to limit Int, use LimitMaxIntAttribute instead!", MessageType.Warning );
            return property;
        }
#endif
    }
}
