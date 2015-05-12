using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseController : MonoBehaviour {
    public GameObject bullet;

    public int hp;
    public int damage;

    public List<BaseController> targetList = new List<BaseController>();

    
    public void AddEnemyInRange(BaseController enemy)
    {
        targetList.Add(enemy);
    }

    public int RemoveEnemyInRange(BaseController enemy)
    {
        targetList.Remove(enemy);
        return targetList.Count;
    }

    //public void SetEnemyInRange(bool EnemyInRange)
    //{
    //    targetList.SetBool(AnimatorParameters.EnemyInRange, EnemyInRange);
    //}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void onAttack()
    {
    }

    public virtual void Hit(int DMG)
    {
    }
}
