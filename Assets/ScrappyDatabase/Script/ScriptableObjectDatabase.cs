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
        public class ScriptableObjectDatabase<T> : ScriptableObject where T: Model
        {
            [SerializeField]
            private List<T> m_Database;
            public  List<T> getDatabase()
            {
                return m_Database;
            }
            

            public int FindByName<F>(string NameToFind) where F: Model
            {
                for( int i =0; i< m_Database.Count; i++)
                {
                    if (m_Database[i].Name.Equals(NameToFind))
                    {
                        return i;
                    }
                }
                return -1;

            }

            



        }
    }

}
