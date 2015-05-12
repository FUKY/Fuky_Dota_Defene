using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : BaseController {

    List<int> listIDSolider = new List<int>();
    public bool outSolider;//Cho phép solider di ra

    public RectTransform targetTower;

    private float countDownSpawnSolider;
    private float timeSpawnSoliderCur;

    public bool isActive;//khi active thi co the tao ra gold
    private float timeAddGold;
    public float countDownAddGold;
	// Use this for initialization
	void Start () {
        countDownSpawnSolider = 2;
	}
	
	// Update is called once per frame
	void Update () {
        if (outSolider)
        {
            timeSpawnSoliderCur += Time.deltaTime;
            Debug.Log(System.String.Format("Count of list ID solider = {0}", listIDSolider.Count));
            if (listIDSolider.Count > 0 && timeSpawnSoliderCur >= countDownSpawnSolider)
            {
                Debug.Log("Spawn Solider");
                timeSpawnSoliderCur = 0;
                SpawnSolider();
            }
            
        }
        
	}

    void SpawnSolider() 
    {
        //spawn solider thu nhat tu list Tower
        //GameObject solider;
        int antID = listIDSolider[0];
        AntController antControl = GameController.Instance.GetPlayerControllerByIsMine(isMine).GetAntControlByID(antID);
        if (antControl != null)
        {
            antControl.ActiveAnt();
            antControl.SetTargetTower(targetTower);
        }
        listIDSolider.Remove(listIDSolider[0]);
        //solider.GetComponent<AntController>().SetTargetTower(targetTower);
    }

    public void SetTarget(RectTransform _targetTower) 
    {
        outSolider = true;
        targetTower = _targetTower;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //add list Tower
        if (other.gameObject.tag == "solider")
        {
            
            AntController antControl = other.gameObject.GetComponent<AntController>();
            if (antControl != null && antControl.isMine == isMine)// && 
            {
                Debug.Log("Collider with tower");
                if (antControl.GetActiveAnt())
                {
                    listIDSolider.Add(antControl.GetAntId());
                    antControl.DeActiveAnt();
                }

            }else
            {
                this.AddEnemyInRange(other.gameObject);
            }
        }
    }
}
