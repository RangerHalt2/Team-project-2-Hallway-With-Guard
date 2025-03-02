//Purpose: To handle the Menus, Buttons, and Scene Loading
//Main Contributor and Author: Logan Baysinger
//Other Contributor: Jaime Abrego
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{

    private Pause pauseManager;

    //JA: Pause Menu | Lets use the same canvas and button names
    private Scene scene;
    [SerializeField] private Canvas masterCanvas;
    [SerializeField] private Canvas menuPause;
    [SerializeField] private Canvas menuOptions;
    [SerializeField] private Canvas menuInfo;
    [SerializeField] private Canvas LoseScreen;
    [SerializeField] private Canvas WinScreen;
    public bool canEsc = true;


    //JA: the bool variable stores whether each version of the same button is currently Enabled or invisible
    [SerializeField] private GameObject buttonInvincON;
    private static bool boolInvincON = false;
    [SerializeField] private GameObject buttonInvincOFF;
    private static bool boolInvincOFF = true;

    [SerializeField] private GameObject buttonSlowModeON;
    private static bool boolSlowModeON = false;
    [SerializeField] private GameObject buttonSlowModeOFF;
    private static bool boolSlowModeOFF = true;

    public bool isSlowMode()
    {
        return boolSlowModeON;
    }
    private void Awake()
    {
        //JA: not sure if this needs to stay here yet 
        
    }

    public void Start()
    {
        //JA: Stores the current Scene/Level in the scene variable
        pauseManager = GameObject.FindObjectOfType<Pause>();
        scene = SceneManager.GetActiveScene();

        //JA: Disables Menu Canvases upon scene start
        masterCanvas.gameObject.SetActive(false);
        menuPause.gameObject.SetActive(false);
        menuOptions.gameObject.SetActive(false);
        LoseScreen.gameObject.SetActive(false);
        WinScreen.gameObject.SetActive(false);
        menuInfo.gameObject.SetActive(false);
        buttonInvincON.gameObject.SetActive(false);
        buttonSlowModeON.gameObject.SetActive(false);

        // JA: New Implementation not yet tested. Updates Toggle Button Vis based on prior input.
        buttonInvincOFF.gameObject.SetActive(boolInvincOFF);
        buttonInvincON.gameObject.SetActive(boolInvincON);
        buttonSlowModeOFF.gameObject.SetActive(boolSlowModeOFF);
        buttonSlowModeON.gameObject.SetActive(boolSlowModeON);

        //  JA: Disabled for now until we know the main menu name and setup
        
        if (scene.name == "MainMenu")
        {
            masterCanvas.gameObject.SetActive(true);
            menuPause.gameObject.SetActive(true);
            pauseManager.isPaused = true; 
        }

        
    }


    // JA: Disabled for now until we can connect the UI and Pause Functionality
    
    //LB: isPaused will switch to what it isn't, the ternirary operator will set the time scale based on T/F, and AudioListener.pause will update. 
    

    public void PullUPPause()
    {
        pauseManager.TogglePause();
        menuPause.gameObject.SetActive(true);
        menuOptions.gameObject.SetActive(false);
        menuInfo.gameObject.SetActive(false);
        if (pauseManager.isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }


    // Jaime's Menu Functions (called upon by different UI buttons being clicked)
    public void openOptionsMenu()
    {
        //Debug.Log("Open Options Menu");
        //JA: Enables the Options Screen and Disables the Pause Screen
        menuPause.gameObject.SetActive(false);

        //JA: needs a 1sec wait in between
        menuOptions.gameObject.SetActive(pauseManager.isPaused);

        canEsc = false;
    }

    public void openInfoMenu()
    {
        //JA: Enables the Info Screen and Disables the Pause Screen
        menuPause.gameObject.SetActive(false);

        //JA: needs a 1sec wait in between
        menuInfo.gameObject.SetActive(pauseManager.isPaused);

        canEsc = false;
    }


    public void backToPauseMenu()
    {
        //Debug.Log("Go back to Pause Menu");
        //JA: Enables the Pause Screen and Disables the Other Screens
        menuPause.gameObject.SetActive(pauseManager.isPaused);

        //JA: needs a 1sec wait in between
        menuOptions.gameObject.SetActive(false);
        menuInfo.gameObject.SetActive(false);
        //JA: more menu screens to come

        canEsc = true;
    }
    public void toggleInvincibility()
    {
        //Debug.Log("Switch OFF/ON Buttons");
        //JA: the bool variable stores the previous state of the seperate on and off buttons before switching and updating
        //each button like Invincibility is gonna need its own code like this
        boolInvincOFF = !boolInvincOFF;
        buttonInvincOFF.gameObject.SetActive(boolInvincOFF);
        boolInvincON = !boolInvincON;
        buttonInvincON.gameObject.SetActive(boolInvincON);
    }

    public void toggleSlowMode()
    {
        boolSlowModeOFF = !boolSlowModeOFF;
        buttonSlowModeOFF.gameObject.SetActive(boolSlowModeOFF);
        boolSlowModeON = !boolSlowModeON;
        buttonSlowModeON.gameObject.SetActive(boolSlowModeON);
    }

    // JA: Disabled until Scenes are Setup
    
    public void startGame()
    {
        //if (scene.name != "MainMenu")
        SceneManager.LoadScene("Area1");
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    

    public void closeGame()
    {
        Application.Quit();
    }


    

}




/* Notes

JA: Removed script that disables/enables the grenade cooldown images in the UI


*/