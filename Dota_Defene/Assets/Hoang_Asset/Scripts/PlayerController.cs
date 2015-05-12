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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetTower(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    }
    int GetTower(PointerEventData eventData)
    {
        Vector2 pointerPostion = eventData.position;
        Vector2 localPointerPosition;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, pointerPostion, eventData.pressEventCamera, out localPointerPosition
        ))
        {
            InstantiateArrow(localPointerPosition);
        }
        return -1;
    }
    void InstantiateArrow(Vector3 pos)
    {
        GameObject arr = Instantiate(arrow, Vector3.zero, Quaternion.identity) as GameObject;
        arr.transform.parent = rect;
        arr.transform.localPosition = pos;        
        arr.transform.localScale = Vector3.one;
    }
}
