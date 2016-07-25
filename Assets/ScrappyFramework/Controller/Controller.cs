using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    private Model m_Model;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public Model Model
    {
        get
        {
            return m_Model;
        }

        set
        {
            m_Model = value;
        }
    }
   
}
