using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

    private BaseController parentController;

	// Use this for initialization
	void Start () {
        GameObject parent = transform.parent.gameObject;
        if (parent != null)
        {
            parentController = parent.GetComponent<BaseController>();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (parentController != null)
        {
            parentController.AddEnemyInRange(other.gameObject);
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
