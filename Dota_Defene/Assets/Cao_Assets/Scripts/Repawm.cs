using UnityEngine;
using System.Collections;

public class Repawm : MonoBehaviour {
    public GameObject objRepawn;
    public float timeRepawn;
    private float timeDelay;

	// Use this for initialization
	void Start () {
        timeDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeDelay > timeRepawn)
        {
            InstantiateRePawn();
        }
        timeDelay += Time.deltaTime;	
	}
    void InstantiateRePawn()
    {
        Instantiate(objRepawn, gameObject.transform.position, Quaternion.identity);
    }
}
