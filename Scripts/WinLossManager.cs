using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossManager : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject player;

    //LB: Place a connection to the UIController here.
    private Pause pauseManager;

    private void Awake()
    {
        pauseManager = GameObject.FindObjectOfType<Pause>();
    }

    private void Update()
    {
        if (pauseManager.isPaused) return;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("player is null");
            return;
        }

        Loss();
        Win();
    }

    public void Loss()
    {
        Transform enemyTrans;
        Transform playerTrans = player.transform;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyTrans = enemies[i].transform;
            if (enemyTrans.position.x == playerTrans.transform.position.x && enemyTrans.position.z == playerTrans.transform.position.z)
            {
                //LB: Access the loss screen here, this is the lose condition. Equally so, the game will pause.
                pauseManager.TogglePause();
                return;
            }
        }
    }

    public void Win()
    {
        //LB: Place the win condition script will be called here
        //LB: Access the UI manager, display win Screen
        pauseManager.TogglePause();
    }


}
