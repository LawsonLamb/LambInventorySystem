using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
namespace Scrappy
{
    namespace Database
    {
        namespace Editor
        {


            [System.Serializable]
            public class ScriptableObjectDatabaseWindow<T> : EditorWindow   
                where T :ScriptableObject
            {
                private int m_Index = 0;
                private Vector2 m_ScrollPosition = Vector2.zero;
                private T m_Type;
                public string AssetPath = " ";
                  public string MenuPath = "";
                 public string WindowLabel = " ";



            void OnEnable()
                {
                    m_Index = 0;
                }


            void OnGUI()
                {
                    GUILayout.Label(WindowLabel, EditorStyles.boldLabel);

                    EditorGUILayout.BeginVertical();
                             Header();
                    EditorGUILayout.BeginHorizontal();
                             Body();
                    EditorGUILayout.EndHorizontal();

                            // Footer();
                    EditorGUILayout.EndVertical();


                }

                public virtual void Header( )
                {
                    EditorGUILayout.BeginHorizontal("box", GUILayout.Width(50));

                            HeaderButtons();
                    
                    EditorGUILayout.EndHorizontal();

                }

                public virtual void HeaderButtons()
                {
                    if (GUILayout.Button("Load DataBase"))
                    {
                        m_Type =  LoadDatabase<T>(AssetPath);
                    }



                }


                public virtual void Body()
                {


                }

                


                public virtual void Footer()
                {

                }
               



               public static T LoadDatabase<T> (string AssetPath) where T :ScriptableObject
                {
                return AssetDatabase.LoadAssetAtPath<T>(AssetPath);

                }

        
               public static T CreateDatabase<T>(string AssetPath) where T: ScriptableObject
                {
                    T type = ScriptableObject.CreateInstance<T>();
                    AssetDatabase.CreateAsset(type, AssetPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    return type;
                }











              
            }
        }
    }
}