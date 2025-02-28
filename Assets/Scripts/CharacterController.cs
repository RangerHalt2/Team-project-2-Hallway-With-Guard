using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float SprintMultiplier = 2.0f;

    private InputHandler inputHandler;

    [SerializeField] private Transform orientation;

    private Rigidbody rb;

    private Vector3 movementDirection;
    [SerializeField] private float jumpHeight = 10;

    private Pause pauseManager;

    private bool touchingGround = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pauseManager = GameObject.FindObjectOfType<Pause>();
        inputHandler = GameObject.FindObjectOfType<InputHandler>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = orientation.forward * inputHandler.MoveInput.y + orientation.right * inputHandler.MoveInput.x;

        if (inputHandler.PauseInput)
        {
            inputHandler.PauseInput = false;
            pauseManager.TogglePause();
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
