// Copyright (c) Rotorz Limited. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using Rotorz.ReorderableList;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReorderableListDemo : EditorWindow {

	[MenuItem("Window/List Demo (C#)")]
	static void ShowWindow() {
		GetWindow<ReorderableListDemo>("List Demo");
	}

	public List<Item> shoppingList;
	public ItemAdapter itemList;
	ItemDatabase itemDatabase;


	
	private void OnEnable() {
		
		itemDatabase = AssetDatabase.LoadAssetAtPath<ItemDatabase>("Assets/Resources/ItemDatabase.asset");
		itemList = new ItemAdapter (itemDatabase.getDatabase ());

	

	}

	private Vector2 _scrollPosition;

	private void OnGUI() {
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		
		ReorderableListGUI.Title("Shopping List");
	//	ReorderableListGUI.ListField<Item> (itemDatabase.getDatabase(), PendingItemDrawer, DrawEmpty);
		ReorderableListGUI.ListField(itemList);
		GUILayout.EndScrollView();
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