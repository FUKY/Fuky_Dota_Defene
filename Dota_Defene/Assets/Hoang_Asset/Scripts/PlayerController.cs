using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    public bool isMine;
    public List<GameObject> listTower;
    public RectTransform canvasRectTransform;
    public Transform rect;
    public GameObject arrow;
    private List<GameObject> listArrow;
	// Use this for initialization
	void Start () {
        listArrow = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    Vector3 posBegin, posEnd;
    public void OnBeginDrag(PointerEventData eventData)
    {
        posBegin = GetPosition(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Destroy(listArrow[0]);
        //listArrow.Clear();
    }
    Vector2  GetPosition(PointerEventData eventData)
    {
        Vector2 pointerPostion = eventData.position;
        Vector2 localPointerPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, pointerPostion, eventData.pressEventCamera, out localPointerPosition
        ))
        {
            int i =GetPower(localPointerPosition);
            if (i != -1)
                InstantiateArrow(listTower[i].transform.localPosition);
            return localPointerPosition;
        }
        return localPointerPosition;
    }
    int GetPower(Vector2 localPostition)
    {
        for (int i = 0; i < listTower.Count; i++)
        {
            
            RectTransform rectTransform= listTower[i].GetComponent<RectTransform>();
            float left = listTower[i].transform.localPosition.x - 50 / 2;
            float right = listTower[i].transform.localPosition.y - 50 / 2;
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
