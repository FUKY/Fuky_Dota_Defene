using UnityEngine;
using System.Collections;

public class AntController : BaseController {
    private int id;

    public float speed = 1;
    
    private bool isAcitve;
    private bool canActive;

    private float timeCanActiveCur;
    public float timeCanActive = 2;

    public RectTransform targetTrans;


    public float angle;
	// Use this for initialization
	void Start () {
        isAcitve = true;
	}
    void SetPritive()
    {
        hp = 0;
        damage = 10;
    }
	// Update is called once per frame
	void Update () {
        Move();
        if (isAcitve)
        {
            //Move();
            UpdateAttack();
        }
        else 
        {
            if (canActive)
            {
                //Move();
                timeCanActiveCur += Time.deltaTime;
                if (timeCanActiveCur >= timeCanActive)
                {
                    isAcitve = true;
                    timeCanActiveCur = 0;
                }
            }
            
        }
	}

    void Move() 
    {
        angle = AngleRotation(transform, targetTrans);

        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * speed * Time.deltaTime;

        transform.localPosition += new Vector3(x, y, 0);
    }

    float AngleRotation(Transform transfBegin, RectTransform transfEnd)
    {
        Vector3 relative = transfEnd.localPosition - transfBegin.localPosition;//transfBegin.InverseTransformPoint(transfEnd.localPosition);
        
        float angle1 = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle1;
    }

    public void SetTargetTower(RectTransform targetTowerTrans)
    {
        targetTrans = targetTowerTrans;
    }

    public void ActiveAnt() 
    {
        gameObject.SetActive(true);
        canActive = true;
        isAcitve = false;
        timeCanActiveCur = 0;
    }

    public void SetActiveAnt(bool _isActive)
    {
        isAcitve = _isActive;
    }

    public void SetAntID(int idAnt) 
    {
        this.id = idAnt;
    }

    public int GetAntId() 
    {
        return this.id;
    }

    public bool GetActiveAnt() 
    {
        return isAcitve;
    }

    public void DeActiveAnt() 
    {
        gameObject.SetActive(false);
        isAcitve = false;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "solider")
        {
            
            AntController _ant = col.gameObject.GetComponent<AntController>();
            if (isMine != _ant.isMine)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
