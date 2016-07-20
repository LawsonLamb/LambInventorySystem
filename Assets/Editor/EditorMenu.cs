using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorMenu : MonoBehaviour {


	[MenuItem("Assets/Create/ItemDataBase")]
	public static void  CreateItemDataBase(){
		ItemDatabase _items = ScriptableObject.CreateInstance<ItemDatabase>();
		AssetDatabase.CreateAsset (_items, "Assets/Resources/ItemDatabase.asset");
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
