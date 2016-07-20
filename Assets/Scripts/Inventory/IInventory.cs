using UnityEngine;
using System.Collections;

public interface IInventory {

	void PickUP (ItemWorldObject ItemObject);
	void DropItem(InventoryItem itemToDrop);

}
