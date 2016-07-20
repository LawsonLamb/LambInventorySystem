using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Scrappy { 
    namespace Database
    {
        [Serializable]
        public class ScriptableObjectDatabase<T> : ScriptableObject
        {
            [SerializeField]
            private List<T> m_Database;
            // Use this for initialization
            void Start()
            {
            }
            // Update is called once per frame
            void Update()
            {

            }
            public List<T> getDatabase()
            {
                return m_Database;
            }
         


     
        }
    }

}
