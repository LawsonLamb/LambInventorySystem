using UnityEngine;
using System.Collections;
using UnityEditor;
using Scrappy.Database.Editor;
[System.Serializable]
public class ItemEditor : ScriptableObjectDatabaseWindow<ItemDatabase>
{
    [MenuItem("DataEditor/Item Editor Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ItemEditor));

    }


}

    




    


