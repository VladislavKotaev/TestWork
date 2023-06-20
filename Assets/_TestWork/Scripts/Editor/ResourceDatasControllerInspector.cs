using TestWork.Items;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemDatasController))]
public class ResourceDatasControllerInspector : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ItemDatasController itemDatasController = (ItemDatasController)target;
        if (GUILayout.Button("Find datas"))
        {
            itemDatasController.FindResourceDatas();
        }
    }
}
