using UnityEditor;

namespace UI
{
    #if UNITY_EDITOR
    
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
    
    #endif
}