using UnityEngine;
using System.Collections;

public class MainTowerController : MonoBehaviour {
    public bool isMine;
    public GameObject prefabAnt;
    public Transform spawnObj;
    public RectTransform rootTower;
    public Transform antContainer;

    private int idAnt;
	// Use this for initialization
	void Start () {
        idAnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [ContextMenu("SpawnAnt")]
    public AntController SpawnAnt() 
    {
        GameObject ant = Instantiate(prefabAnt, spawnObj.localPosition, Quaternion.identity) as GameObject;
        
        ant.transform.SetParent(antContainer);
        ant.transform.localPosition = transform.localPosition;
        ant.transform.localScale = Vector3.one;

        AntController antControl = ant.GetComponent<AntController>();
        antControl.SetTargetTower(rootTower);
        //antControl.ActiveAnt();
        antControl.SetActiveAnt(true);
        antControl.SetIsMine(isMine);
        antControl.SetAntID(idAnt);

        idAnt++;

        return antControl;
    }
}
