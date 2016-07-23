using UnityEngine;
using System.Collections;
using UnityEditor;
using Scrappy.Database.Editor;
using System.Linq;
using Rotorz.ReorderableList;
using System.Collections.Generic;
[System.Serializable]
public class ItemEditor : ScriptableObjectDatabaseWindow<ItemDatabase>
{

	public override void Init ()
	{
		base.Init ();
		base.AssetPath = "Assets/Resources/ItemDatabase.asset";

	

	}
		
    [MenuItem("DataEditor/Item Editor Window")]
    public static void ShowWindow()
    {
		
        EditorWindow.GetWindow(typeof(ItemEditor));


    }

	public override void propertyWindow ()
	{		base.propertyWindow ();
		try {
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.BeginVertical ("Box",GUILayout.Width(300));
		Item item = m_Type.getDatabase ().ElementAt (m_Index);
		item.ID = EditorGUILayout.TextField ("ID", item.ID);
		item.itemName = EditorGUILayout.TextField ("Name", item.itemName);
		item.icon = (Sprite)EditorGUILayout.ObjectField ("Sprite",item.icon, typeof(Sprite), false);
		item.mesh = (Mesh)EditorGUILayout.ObjectField ("Mesh", item.mesh, typeof(Mesh), false);

		EditorGUILayout.EndVertical ();	
		EditorGUILayout.EndHorizontal ();
	}
			
		catch (System.ArgumentOutOfRangeException ex){
			Debug.Log(ex.ToString());
		}
		catch(System.NullReferenceException ex){
			Debug.Log(ex.ToString());
			//this.Close();
		}
}

	public override void scrollList(){
		
		ReorderableListGUI.Title ("Item Editor");

		//ReorderableListGUI.ListField<Item> (m_Type.getDatabase (), PendingItemDrawer, DrawEmpty);
	


	}


private Item PendingItemDrawer(Rect position, Item itemValue) {
				// Text fields do not like null values!
				if (itemValue == null)
					itemValue = new Item();

				position.width -= 50;
				itemValue.itemName = EditorGUI.TextField(position, itemValue.itemName);

				position.x = position.xMax + 5;
				position.width = 45;
	

				return itemValue;
			}

private void DrawEmpty() {
		GUILayout.Label("No items in list.", EditorStyles.miniLabel);
	}












    




    


}


public class ItemAdapter: GenericListAdaptor<Item>{
	private static ItemAdapter s_SelectedList;
	public static Item  s_SelectedItem;

	public ItemAdapter(IList<Item> list):base(list,null,16f){

	}

	public override void DrawItemBackground(Rect position,int index){
		if (this == s_SelectedList && List[index] == s_SelectedItem) {
			Color restoreColor = GUI.color;
			GUI.color = ReorderableListStyles.SelectionBackgroundColor;
			GUI.DrawTexture(position, EditorGUIUtility.whiteTexture);
			GUI.color = restoreColor;
		}

	}

	public override void DrawItem (Rect position, int index)
	{ Item item = List [index];
		int controlID = GUIUtility.GetControlID(FocusType.Passive);

		switch (Event.current.GetTypeForControl (controlID)) {
		case EventType.MouseDown:
			Rect totalItemPosition = ReorderableListGUI.CurrentItemTotalPosition;
			if (totalItemPosition.Contains(Event.current.mousePosition)) {
				// Select this list item.
				s_SelectedList = this;
				s_SelectedItem = item;
			}
			break;



		case EventType.Repaint:
			EditorStyles.label.Draw(position, item.itemName, false, false, false, false);
			break;
		}
	

	}




}