using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] public float walkSpeed = 5f;
    [SerializeField] private float SprintMultiplier = 2.0f;

    private InputHandler inputHandler;

    [SerializeField] private Transform orientation;
    [SerializeField] private GameObject gun;

    [SerializeField] private Transform greenPrefab;
    [SerializeField] private Transform purplePrefab;

    private Rigidbody rb;

    private Transform greenShot;
    private Transform purpleShot;

    public Vector3 movementDirection;
    [SerializeField] private float jumpHeight = 10;

    private Pause pauseManager;
    private UI_Controller UIManager;
    private bool touchingGround = false;

    public float portalTimer = 2f;
    public float timer;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pauseManager = GameObject.FindObjectOfType<Pause>();
        UIManager = GameObject.FindObjectOfType<UI_Controller>();
        inputHandler = GameObject.FindObjectOfType<InputHandler>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = orientation.forward * inputHandler.MoveInput.y + orientation.right * inputHandler.MoveInput.x;

        timer -= Time.deltaTime;


        if (inputHandler.PauseInput)
        {
            inputHandler.PauseInput = false;
            UIManager.PullUPPause();
            //pauseManager.TogglePause();
        }

        if (inputHandler.FireInput && greenShot == null)
        {
            GreenShot();
            inputHandler.FireInput = false;
        }
        if (inputHandler.altFireInput && purpleShot == null)
        {
            PurpleShot();
            inputHandler.altFireInput = false;
        }

    }
    
    private void FixedUpdate()
    {
        HandleMovement();
        if (inputHandler.JumpInput && touchingGround)
        {
            inputHandler.JumpInput = false;
            touchingGround = false;
            Jump();
        }
    }

    private void GreenShot()
    {
        greenShot = Instantiate(greenPrefab, gun.transform.position, gun.transform.rotation);
    }

    private void PurpleShot()
    {
        purpleShot = Instantiate(purplePrefab, gun.transform.position, gun.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        touchingGround = true;
    }

    void Jump()
    {
        rb.velocity += transform.up * jumpHeight;
    }

    void HandleMovement()
    {
        float speed = walkSpeed * (inputHandler.SprintValue > 0 ? SprintMultiplier : 1f);
        rb.velocity = new Vector3(movementDirection.x * speed, rb.velocity.y, movementDirection.z * speed);
    }
}
