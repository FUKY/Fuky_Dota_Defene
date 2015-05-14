using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    public bool isMine;
    public List<GameObject> listTower;
    public List<GameObject> listAllTower;
    public RectTransform canvasRectTransform;
    public Transform rect;
    public GameObject arrow;
    private List<GameObject> listArrow;

    private Dictionary<int, AntController> listSolider = new Dictionary<int, AntController>();

    public MainTowerController mainTower;

    private float timeSpawnSoliderCur;
    public float countDownSpawnSolider;

    private int towerStart;
    private int towerEnd;

	// Use this for initialization
	void Start () {
        listArrow = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        timeSpawnSoliderCur += Time.deltaTime;
        if (timeSpawnSoliderCur > countDownSpawnSolider)
        {
            //Spawn
            AntController antControl = mainTower.SpawnAnt();
            listSolider[antControl.GetAntId()] = antControl;
            timeSpawnSoliderCur = 0;
        }
        
	}
    Vector3 posBegin, posEnd;
    public void OnBeginDrag(PointerEventData eventData)
    {
        int idTowerStart = GetTowerByPointer(eventData);
        if (idTowerStart != -1)
        {
            towerStart = idTowerStart;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Destroy(listArrow[0]);
        //listArrow.Clear();
        int idTowerEnd = GetTowerByPointer(eventData);
        Debug.Log(System.String.Format("ID Tower End = {0}", idTowerEnd));

        //if (idTowerEnd != -1 && (towerStart >= 0 && towerStart <= listTower.Count))
        //{
        //    towerEnd = idTowerEnd;
        //    GameObject towerStartObj = listTower[towerStart];
        //    GameObject towerTrans = towerStartObj.transform.FindChild("Tower").gameObject;
        //    TowerController towerStartControl = towerTrans.GetComponent<TowerController>();
            
        //    GameObject towerEndObj = listTower[towerEnd];
        //    if (towerStartControl != null)
        //    {
        //        Debug.Log("Has tower controller");
        //        towerStartControl.SetTarget((RectTransform)towerEndObj.transform);
        //    } 
        //    else
        //    {
        //        Debug.Log("Hasn't tower controller");
        //    }            
        //}
        if (idTowerEnd != -1 && (towerStart >= 0 && towerStart <= listAllTower.Count))
        {
            towerEnd = idTowerEnd;
            GameObject towerStartObj = listAllTower[towerStart];
            GameObject towerTrans = towerStartObj.transform.FindChild("Tower").gameObject;
            TowerController towerStartControl = towerTrans.GetComponent<TowerController>();

            GameObject towerEndObj = listAllTower[towerEnd];
            if (towerStartControl != null)
            {
                Debug.Log("Has tower controller");
                towerStartControl.SetTarget((RectTransform)towerEndObj.transform);
            }
            else
            {
                Debug.Log("Hasn't tower controller");
            }
        }

    }

    public AntController GetAntControlByID(int antID) 
    {
        if (listSolider.ContainsKey(antID))
        {
            return listSolider[antID];
        }

        return null;
    }

    private int GetTowerByPointer(PointerEventData eventData)
    {
        Vector2 pointerPostion = eventData.position;
        Vector2 localPointerPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, pointerPostion, eventData.pressEventCamera, out localPointerPosition
        ))
        {
            
            int i = GetTower(localPointerPosition);

            if (i != -1)
                InstantiateArrow(listAllTower[i].transform.localPosition);
            return i;
        }
        return -1;
    }

    int GetTower(Vector2 localPostition)
    {
        for (int i = 0; i < listAllTower.Count; i++)
        {

            RectTransform rectTransform = listAllTower[i].GetComponent<RectTransform>();

            float left = listAllTower[i].transform.localPosition.x - 50 / 2;
            float right = listAllTower[i].transform.localPosition.y - 50 / 2;
            Rect rect = new Rect(left, right, rectTransform.rect.width, rectTransform.rect.height);
            if (rect.Contains(localPostition))
            {
                return i;               
            }
            
        }
        
       return -1;
    }
    void InstantiateArrow(Vector3 pos)
    {
        GameObject arr = Instantiate(arrow, Vector3.zero, Quaternion.identity) as GameObject;
        arr.transform.parent = rect;
        arr.transform.localPosition = pos;   
        arr.transform.localScale = Vector3.one;
        listArrow.Add(arr);
    }

    float RotaionArrow(Vector3 posBegin, Vector3 posEnd)
    {
        Vector3 relative = posEnd - posBegin;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        return angle;
    }
}
