using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

    private BaseController parentController;

	// Use this for initialization
	void Start () {
        GameObject parent = transform.parent.gameObject;
        
        if (parent != null)
        {
            if (parent.tag == "solider")
            {
                parentController = (BaseController)parent.GetComponent<AntController>();
                //
            }
            else 
            {
                if (parent.tag == "tower")
                {
                    parentController = (BaseController)parent.GetComponent<TowerController>();
                }
            }

            if (parentController != null)
            {
                Debug.Log("Get BaseController" + parentController.isMine);
            }
            
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (parentController != null)
        {
            //Debug.Log("Collider with range");
            //parentController.AddEnemyInRange(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (parentController != null)
        {
            parentController.RemoveEnemyInRange(other.gameObject);
        }
    }
}
