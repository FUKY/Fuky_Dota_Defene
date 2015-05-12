using UnityEngine;
using System.Collections;

public class AntController : BaseController {

    public float speed = 1;

    public RectTransform target;


    public float angle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //angle = AngleRotation(transform, target);

        Move();
	}

    void Move() 
    {
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * speed;

        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
    }

    float AngleRotation(Transform transfBegin, RectTransform transfEnd)
    {
        Vector3 relative = transfBegin.localPosition - transfEnd.localPosition;//transfBegin.InverseTransformPoint(transfEnd.localPosition);
        
        float angle1 = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle1;
    }
}
