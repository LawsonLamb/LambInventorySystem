using UnityEngine;
using System.Collections;

public class InventoryItem {
	public Item item;
	public int count;
	public InventoryItem(Item item){
		this.item = item;
		this.count = 1;
	}
}
