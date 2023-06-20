using UnityEngine;
using UnityEditor;
 #if UNITY_EDITOR
[CustomEditor(typeof(setup))]
public class editor : Editor
{
    // public override void OnInspectorGUI()
    // {
    //     DrawDefaultInspector();
 
    //     setup setupGo = (setup)target;
    //     if (GUILayout.Button("Create Asset Library file"))
    //     {
    //         setupGo.CreateAssetLib();
    //     }
    // }
}
#endif