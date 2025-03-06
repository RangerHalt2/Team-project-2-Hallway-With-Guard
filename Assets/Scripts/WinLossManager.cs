using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossManager : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject player;
    [SerializeField] private Canvas masterCanvas;
    [SerializeField] private Canvas LoseScreen;
    [SerializeField] private Canvas WinScreen;
    private UI_Controller ui;
    private float winTimer = 5;
    private bool loss;
    private float count;
    //LB: Place a connection to the UIController here.
    private Pause pauseManager;

    private void Awake()
    {
        pauseManager = GameObject.FindObjectOfType<Pause>();
        ui = GameObject.FindObjectOfType<UI_Controller>();
    }

    private void Update()
    {
        count -= Time.deltaTime;
        if (pauseManager.isPaused) return;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("player is null");
            return;
        }

        Loss();
    }

    public void Loss()
    {
        if (ui.getInvuln() || loss) return;
        Transform enemyTrans;
        Transform playerTrans = player.transform;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyTrans = enemies[i].transform;
            if ((enemyTrans.position.x - 0.5 <= playerTrans.transform.position.x && enemyTrans.position.x + 0.5 >= playerTrans.transform.position.x) && (enemyTrans.position.z - 0.5 <= playerTrans.transform.position.z && enemyTrans.position.z + 0.5 >= playerTrans.transform.position.z))
            {
                //LB: Access the loss screen here, this is the lose condition. Equally so, the game will pause.
                pauseManager.TogglePause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                masterCanvas.gameObject.SetActive(true);
                LoseScreen.gameObject.SetActive(true);
                ui.canEsc = false;
                loss = true;
                return;
            }
        }
    }

    public void Win()
    {
        Debug.Log("Entered Win");
        if (count >= 0) return;
        //LB: Place the win condition script will be called here
        //LB: Access the UI manager, display win Screen
        
        Debug.Log("WinFunction");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        masterCanvas.gameObject.SetActive(true);
        WinScreen.gameObject.SetActive(true);
        ui.canEsc = false;
        count = winTimer;
        pauseManager.TogglePause();
    }


}
