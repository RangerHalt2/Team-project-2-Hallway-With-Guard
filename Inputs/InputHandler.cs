//Purpose: To set the ground work for the input system and the Action Map
//Contributor and Author: Logan Baysinger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;

    [SerializeField] private string actionMapName = "Player";

    [SerializeField] private string move = "Move";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string pause = "Pause";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string fire = "Fire";
    [SerializeField] private string altFire = "AltFire";

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction pauseAction;
    private InputAction jumpAction;
    private InputAction fireAction;
    private InputAction altFireAction;

    public Vector2 MoveInput { get; private set; }
    public float SprintValue { get; private set; }
    public bool PauseInput {  get; set; }
    public bool JumpInput { get; set; }
    public bool FireInput { get; set; }
    public bool altFireInput { get; set; }

    public static InputHandler Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        sprintAction = playerControls.FindActionMap(actionMapName).FindAction(sprint);
        pauseAction = playerControls.FindActionMap(actionMapName).FindAction(pause);
        jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
        fireAction = playerControls.FindActionMap(actionMapName).FindAction(fire);
        altFireAction = playerControls.FindActionMap(actionMapName).FindAction(altFire);
        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        sprintAction.performed += context => SprintValue = context.ReadValue<float>();
        sprintAction.canceled += context => SprintValue = 0f;

        pauseAction.performed += context => PauseInput = true;
        pauseAction.canceled += context => PauseInput = false;

        jumpAction.performed += context => JumpInput = true;
        jumpAction.canceled += context => JumpInput = false;

        fireAction.performed += context => FireInput = true;
        fireAction.canceled += context => FireInput = false;

        altFireAction.performed += context => altFireInput = true;
        altFireAction.canceled += context => altFireInput = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        sprintAction.Enable();
        pauseAction.Enable();
        jumpAction.Enable();
        fireAction.Enable();
        altFireAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        sprintAction.Disable();
        pauseAction.Disable();
        jumpAction.Disable();   
        fireAction.Disable();
        altFireAction.Disable();
    }

}
