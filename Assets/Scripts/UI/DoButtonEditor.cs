using UnityEditor;

namespace UI
{
    [CustomEditor(typeof(DoButton))]
    public class DoButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();

            serializedObject.ApplyModifiedProperties();
        }
    }
}