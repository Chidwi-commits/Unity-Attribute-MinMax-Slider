using UnityEditor;
using UnityEngine;

namespace Chidwi.MinMaxSliderAttribute
{
    public class MinMaxSliderAttribute : PropertyAttribute
    {
        public float min;
        public float max;

        public MinMaxSliderAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(MinMaxSliderAttribute))]
    public class MinMaxSliderDrawer : PropertyDrawer
    {
        // Global settings for layout
        private float _labelWidth = 100f; // Width for the variable name label
        private float _fieldWidth = 40f; // Width for the min/max value fields
        private float _minimumSliderWidth = 100f; // Minimum width for the slider
        private float _fieldToSliderPadding = 5f; // Padding between fields and slider
        private float _fieldPadding = 2f; // Padding between min and max fields

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Vector2)
            {
                MinMaxSliderAttribute slider = attribute as MinMaxSliderAttribute;

                // Calculating dynamic widths and positions
                float totalWidthAvailable = position.width - _labelWidth - _fieldWidth * 2 -
                                            _fieldToSliderPadding * 2 - _fieldPadding * 3;
                float sliderWidth = Mathf.Max(totalWidthAvailable, _minimumSliderWidth);

                Rect labelRect = new Rect(position.x, position.y, _labelWidth, position.height);
                Rect minFieldRect = new Rect(position.x + _labelWidth + _fieldPadding, position.y, _fieldWidth,
                    position.height);
                float sliderXPosition = minFieldRect.x + _fieldWidth + _fieldToSliderPadding;
                Rect sliderRect = new Rect(sliderXPosition, position.y, sliderWidth, position.height);
                Rect maxFieldRect = new Rect(sliderRect.x + sliderRect.width + _fieldToSliderPadding, position.y,
                    _fieldWidth, position.height);

                EditorGUI.BeginProperty(position, label, property);

                // Drawing the label
                EditorGUI.LabelField(labelRect, label);

                // Getting current range values
                Vector2 range = property.vector2Value;
                float min = range.x;
                float max = range.y;

                // Drawing fields for min and max values
                min = EditorGUI.FloatField(minFieldRect, min);
                max = EditorGUI.FloatField(maxFieldRect, max);

                // Ensuring min is not greater than max
                min = Mathf.Clamp(min, slider.min, max);
                max = Mathf.Clamp(max, min, slider.max);

                // Drawing the slider
                EditorGUI.MinMaxSlider(sliderRect, ref min, ref max, slider.min, slider.max);

                if (GUI.changed)
                {
                    range.x = min;
                    range.y = max;
                    property.vector2Value = range;
                }

                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use MinMaxSlider with Vector2.");
            }
        }
    }
#endif
}