using UnityEngine;
using System.Collections;

public class AntController : BaseController {

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
	
	// Update is called once per frame
	void Update () {
        if (isAcitve)
        {
            Move();
        }
        else 
        {
            if (canActive)
            {
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
        timeCanActiveCur = 0;
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
}
