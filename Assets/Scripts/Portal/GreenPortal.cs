using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPortal : MonoBehaviour
{
    private PurplePortal purplePortal;

    public float startTime;

    private CharController characterController;

    public AudioSource playSound; 


    //This will link the green to the purple portal by finding the game object.
    void Start()
    {
        purplePortal = GameObject.FindFirstObjectByType<PurplePortal>();
        startTime = Time.time;
    }

    private void Update()
    {
        purplePortal = GameObject.FindFirstObjectByType<PurplePortal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if(!purplePortal) return;
        Debug.Log("Made it to Line 30");
        characterController = other.gameObject.GetComponentInParent<CharController>();
        if (characterController.timer > 0) return;
        other.gameObject.SetActive(false);
        other.transform.position = purplePortal.transform.position;
        other.gameObject.SetActive(true);
        characterController.timer = characterController.portalTimer;

        //sound effect
        playSound.Play();
    }


}
