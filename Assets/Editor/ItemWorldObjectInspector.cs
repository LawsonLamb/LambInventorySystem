using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using Scrappy.Database.Editor;
[CustomEditor(typeof(ItemWorldObject))]
public class ItemWorldObjectInspector :Editor{
    int choice;

    ItemWorldObject worldObject;
    List<string> nameList;
    void OnEnable()
    {
        nameList = new List<string>();
        worldObject = (ItemWorldObject)target;

  

    }
	// Use this for initialization
	void Start () {
	    
	}

   
	
	
}
