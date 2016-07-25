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
  public override void OnGUI()
    { 
         base.OnGUI();
    }
    ItemAdapter itemAdapter;
	public override void Init ()
    { 
        itemAdapter = new ItemAdapter(m_Type.getDatabase());
	
	}

    public override void setPaths()
    {
        base.setPaths();
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
		EditorGUILayout.BeginHorizontal ("Box", GUILayout.Width(300));
		EditorGUILayout.BeginVertical ("Box",GUILayout.Width(300));
            Item item = ItemAdapter.s_SelectedItem;
            if (item != null)
            {
                item.ID = EditorGUILayout.TextField("ID", item.ID);
                item.Name = EditorGUILayout.TextField("Name", item.Name);
                item.icon = (Sprite)EditorGUILayout.ObjectField("Sprite", item.icon, typeof(Sprite), false);
                item.mesh = (Mesh)EditorGUILayout.ObjectField("Mesh", item.mesh, typeof(Mesh), false);
            }
            else
            {
                EditorGUILayout.LabelField("Select item to \n be able to edit ",GUILayout.Height(50.0f));

            }
		EditorGUILayout.EndVertical ();	
		EditorGUILayout.EndHorizontal ();
	}
			
		catch (System.ArgumentOutOfRangeException ex){
			Debug.Log(ex.ToString());
		}
		catch(System.NullReferenceException ex){
			Debug.Log(ex.ToString());
			this.Close();
		}
}

	public override void scrollList(){
      
        ReorderableListGUI.Title ("Item Editor");

        //ReorderableListGUI.ListField<Item> (m_Type.getDatabase (), PendingItemDrawer, DrawEmpty);
         ReorderableListGUI.ListField(itemAdapter);



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
			EditorStyles.label.Draw(position, item.Name, false, false, false, false);
			break;
		}
	

	}




}