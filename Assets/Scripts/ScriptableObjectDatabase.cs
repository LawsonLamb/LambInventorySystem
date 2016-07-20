using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

[Serializable]
public class   ScriptableObjectDatabase<T>: ScriptableObject {
	[SerializeField]
	public List<T> _database;
	// Use this for initialization
	void Start () {
		_database = new List<T> ();
	}
	// Update is called once per frame
	void Update () {
	
	}

		
}
