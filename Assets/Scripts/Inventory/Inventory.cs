using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour,IInventory {
	public List<InventoryItem> inventoryList;
	// Use this for initialization
	void Start () {
		inventoryList = new List<InventoryItem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DropItem(InventoryItem itemToDrop){

	}
	public void PickUP(ItemWorldObject itemObject){
		

	}

	private void AddToInventory(Item item){
		int index = SearchByItem (item);

		if (index != -1) {
			inventoryList [index].count++;

		} else {

			inventoryList.Add (new InventoryItem(item));

		}


	}
	private int SearchByItem(Item item){

		for (int i = 0; i < inventoryList.Count; i++) {

			if (item.ID == inventoryList [i].item.ID) {
				return i;
			}
		}

		return -1;

	}

	private void RemoveToInventory(InventoryItem item){
		
	}
	
	public void SaveToDisk(){
			}
	public void LoadToDisk(){

			}




}
