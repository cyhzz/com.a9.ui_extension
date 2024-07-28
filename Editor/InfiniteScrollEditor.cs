
using UnityEditor;
using UnityEngine;

namespace Com.A9.UIExt
{

    [CustomEditor(typeof(InfiniteScroll))]
    public class InfiniteScrollEditor : Editor
    {

        /// <summary>
        /// Scroller target
        /// </summary>
        private InfiniteScroll _target;

        /// <summary>
        /// Serialized target object
        /// </summary>
        private SerializedObject _object;

        /// <summary>
        /// Item list prefab
        /// </summary>
        private SerializedProperty _prefab;

        /// <summary>
        /// Top padding
        /// </summary>
        private SerializedProperty _topPadding;

        /// <summary>
        /// Bottom padding
        /// </summary>
        private SerializedProperty _bottomPadding;

        /// <summary>
        /// Spacing between items
        /// </summary>
        private SerializedProperty _itemSpacing;

        /// <summary>
        /// Label font asset
        /// </summary>

        /// <summary>
        /// Can we pull from top
        /// </summary>
        private SerializedProperty _isPullTop;

        /// <summary>
        /// Can we pull from bottom
        /// </summary>
        private SerializedProperty _isPullBottom;

        /// <summary>
        /// Left padding
        /// </summary>
        private SerializedProperty _leftPadding;

        /// <summary>
        /// Right padding
        /// </summary>
        private SerializedProperty _rightPadding;

        /// <summary>
        /// Pull left text label
        /// </summary>

        /// <summary>
        /// Can we pull from left
        /// </summary>
        private SerializedProperty _isPullLeft;

        /// <summary>
        /// Can we pull from right
        /// </summary>
        private SerializedProperty _isPullRight;

        /// <summary>
        /// Coefficient when labels should action
        /// </summary>
        private SerializedProperty _pullValue;

        /// <summary>
        /// Label position offset
        /// </summary>
        private SerializedProperty _labelOffset;

        /// <summary>
        /// Init data
        /// </summary>
        private void OnEnable()
        {
            _target = (InfiniteScroll)target;
            _object = new SerializedObject(target);
            _prefab = _object.FindProperty("prefab");
            _topPadding = _object.FindProperty("TopPadding");
            _bottomPadding = _object.FindProperty("BottomPadding");
            _itemSpacing = _object.FindProperty("ItemSpacing");

            _isPullTop = _object.FindProperty("IsPullTop");
            _isPullBottom = _object.FindProperty("IsPullBottom");
            _leftPadding = _object.FindProperty("LeftPadding");
            _rightPadding = _object.FindProperty("RightPadding");

            _isPullLeft = _object.FindProperty("IsPullLeft");
            _isPullRight = _object.FindProperty("IsPullRight");
            _pullValue = _object.FindProperty("PullValue");
            _labelOffset = _object.FindProperty("LabelOffset");
        }

        /// <summary>
        /// Draw inspector
        /// </summary>
        public override void OnInspectorGUI()
        {
            _object.Update();
            EditorGUI.BeginChangeCheck();
            _target.Type = GUILayout.Toolbar(_target.Type, new string[] { "Vertical", "Horizontal" });
            switch (_target.Type)
            {
                case 0:
                    EditorGUILayout.PropertyField(_prefab);
                    EditorGUILayout.PropertyField(_topPadding);
                    EditorGUILayout.PropertyField(_bottomPadding);
                    EditorGUILayout.PropertyField(_itemSpacing);

                    EditorGUILayout.PropertyField(_isPullTop);
                    EditorGUILayout.PropertyField(_isPullBottom);
                    EditorGUILayout.PropertyField(_pullValue);
                    EditorGUILayout.PropertyField(_labelOffset);
                    break;
                case 1:
                    EditorGUILayout.PropertyField(_prefab);
                    EditorGUILayout.PropertyField(_leftPadding);
                    EditorGUILayout.PropertyField(_rightPadding);
                    EditorGUILayout.PropertyField(_itemSpacing);

                    EditorGUILayout.PropertyField(_isPullLeft);
                    EditorGUILayout.PropertyField(_isPullRight);
                    EditorGUILayout.PropertyField(_pullValue);
                    EditorGUILayout.PropertyField(_labelOffset);
                    break;
                default:
                    break;
            }
            if (EditorGUI.EndChangeCheck())
            {
                _object.ApplyModifiedProperties();
            }
        }

    }

}