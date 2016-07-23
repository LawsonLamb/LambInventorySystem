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
            public abstract class ScriptableObjectDatabaseWindow<T> : EditorWindow   
				where T :ScriptableObject
            {
                public int m_Index = 0;
                private Vector2 m_ScrollPosition = Vector2.zero;
              	public T m_Type;
				public  string AssetPath = " ";
                public string MenuPath = "";
                public string WindowLabel = " ";
		


             	void OnEnable()
                {

					Init ();
                    m_Index = 0;
					m_Type = LoadDatabase<T> (AssetPath);

					if (m_Type == null) {
						m_Type = CreateDatabase<T> (AssetPath);

					}
						
					
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

				public virtual void ScrollArea(){
					EditorGUILayout.BeginVertical (GUILayout.Width(500));
					m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition,GUILayout.ExpandHeight(true)); 

					scrollList ();

					GUILayout.EndScrollView();
					EditorGUILayout.EndVertical ();


				}


				public virtual void scrollList() {
					

				}

				public virtual void propertyWindow(){
					
						

				}

                public virtual void Body()
                {
					ScrollArea ();
					propertyWindow ();

                }

                public virtual void Footer()
                {

                }

				public virtual void Init(){

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