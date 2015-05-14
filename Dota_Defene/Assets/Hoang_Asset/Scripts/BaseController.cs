using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseController : MonoBehaviour {
    public GameObject bullet;

    public bool isMine;

    public int hp;
    public int damage;

    public float countDown;

    [HideInInspector]
    private float timeAttackCur;//+= deltaTime
#if DIRECT_HIT
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
#else 
    public List<GameObject> targetList = new List<GameObject>();

    public void AddEnemyInRange(GameObject enemy)
    {
        targetList.Add(enemy);
    }

    public int RemoveEnemyInRange(GameObject enemy)
    {
        targetList.Remove(enemy);
        return targetList.Count;
    }
#endif


	// Use this for initialization
	void Start () {
        timeAttackCur = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //timeAttackCur += Time.deltaTime;

        //if (targetList.Count > 0)
        //{
        //    if (timeAttackCur > countDown)
        //    {
        //        timeAttackCur = 0;
        //        onAttack();
        //    }
            
        //}
	}

    public void UpdateAttack() 
    {
        timeAttackCur += Time.deltaTime;

        if (targetList.Count > 0)
        {
            if (timeAttackCur > countDown)
            {
                timeAttackCur = 0;
                onAttack();
            }

        }
    }

    public void SetIsMine(bool _isMine) 
    {
        isMine = _isMine;
    }

    public virtual void onAttack()
    {
        //Chon mot con enemy gan nhat va ban no
        GameObject target = targetList[0];
        if (target != null)
        {
            GameObject bulletObj = Instantiate(bullet, Vector3.one, Quaternion.identity) as GameObject;
            bulletObj.transform.SetParent(transform.parent);
            bulletObj.transform.localPosition = transform.localPosition;
            bulletObj.transform.localScale = Vector3.one;
            MoveBullet _moveBullet = bulletObj.GetComponent<MoveBullet>();
            _moveBullet.SetGetTaget(target.transform, this.isMine, this.damage);            
        }

        //Tạo ra viên đạn và Fire tại đây

    }
    

    public virtual void Hit(int DMG)
    {
        hp -= DMG;
        if (hp <= 0)
        {
            //die
            Die();
        }
    }

    public virtual void Die() 
    {
        Destroy(gameObject);
        //Cong diem cho doi thu
    }
}
