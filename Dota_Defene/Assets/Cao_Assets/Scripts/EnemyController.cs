using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed = 1;

    public RectTransform target;

    private float x, y;
    //private float angle;
    void Awake()
    { 
    }
    private float angle;
	// Use this for initialization
	void Start () {
        angle = AngleRotation(transform ,target);
	}
	
	// Update is called once per frame
	void Update () {
        x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed;
        y = Mathf.Sin(Mathf.Deg2Rad * angle) * speed;

        transform.position += new Vector3(x, y, 0) * Time.deltaTime;

	}

    float AngleRotation(Transform transfBegin, RectTransform transfEnd)
    {
        Vector3 relative = transfBegin.InverseTransformPoint(transfEnd.position); 
       
        float angle1 = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        return angle1;       
    }
}
