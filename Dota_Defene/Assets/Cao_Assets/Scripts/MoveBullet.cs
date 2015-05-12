using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

    public float speed = 1;
    public float angle;
    public RectTransform rect;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Move();      
	}
    [ContextMenu("Test")]
    void Test()
    {
        SetGetTaget(rect);
    }
    public void SetGetTaget(RectTransform targetTrans)
    {
        angle = AngleRotation(targetTrans);
    }
    void Move()
    {        
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        transform.localPosition += new Vector3(x, y, 0);

    }
    float AngleRotation(RectTransform tagetTranform)
    {
        Vector3 relative = tagetTranform.localPosition - transform.localPosition;//transfBegin.InverseTransformPoint(transfEnd.localPosition);

        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.tag == "solider")
        //{
        //    Destroy(col.gameObject);
        //    Destroy(gameObject);
        //}
    }
}
