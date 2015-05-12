using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : BaseController {

    List<GameObject> listSolider;
    public bool outSolider;//Cho phép solider di ra

    public RectTransform targetTower;

    public float countDownSpawnSolider;
    public float timeSpawnSoliderCur;

    public bool isActive;//khi active thi co the tao ra gold
    public float timeAddGold;
    public float countDownAddGold;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (outSolider)
        {
            timeSpawnSoliderCur += Time.deltaTime;
            if (listSolider.Count > 0)
            {
                timeSpawnSoliderCur = 0;
                SpawnSolider();
            }
            
        }
        
	}

    void SpawnSolider() 
    {
        //spawn solider thu nhat tu list Tower
        //GameObject solider;
        //solider.GetComponent<AntController>().SetTargetTower(targetTower);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //add list Tower
    }
}
