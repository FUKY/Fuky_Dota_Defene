using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveBullet : MonoBehaviour {

    private bool isMine;
    private int damage;
    public float speed = 1;
    public float angle;
   
    //public RectTransform rect;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Move();      
	}
    //[ContextMenu("Test")]
    //void Test()
    //{
    //    SetGetTaget(rect);
    //}
    public void SetGetTaget(Transform targetTrans, bool _isMine, int _dmg)
    {
        angle = AngleRotation(targetTrans);
        damage = _dmg;
        isMine = _isMine;
    }
    void Move()
    {        
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        transform.localPosition += new Vector3(x, y, 0);

    }
    float AngleRotation(Transform tagetTranform)
    {
        Vector3 relative = tagetTranform.localPosition - transform.localPosition;//transfBegin.InverseTransformPoint(transfEnd.localPosition);

        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle;
    }
    void Test()
    {
        TowerController _towerControl = transform.parent.GetComponentInChildren<TowerController>();
        if (_towerControl == null)
        {
            Debug.Log("K tim thay");
        }
        if(_towerControl != null)
        {
            Debug.Log("Da Remove");
            _towerControl.RemoveListTaget();
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "solider")
        {
            Debug.Log("Da va cham voi Bee");            
            Destroy(col.gameObject);
            Test();
            
        }
        Destroy(gameObject);
    }
}
