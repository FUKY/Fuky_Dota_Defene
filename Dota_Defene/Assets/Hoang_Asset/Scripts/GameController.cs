using UnityEngine;
using System.Collections;

public class GameController : MonoSingleton<GameController> {

    public PlayerController playerController;
    public PlayerController enemyController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public PlayerController GetPlayerControllerByIsMine(bool isMine) 
    {
        if (isMine)
        {
            return playerController;
        }
        else
        {
            return enemyController;
        }
    }
}
