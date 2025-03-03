using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePortal : MonoBehaviour
{
    private GreenPortal greenPortal;

    public float startTime;

    private CharController characterController;

    public AudioSource playSound;


    //This will link the green to the purple portal by finding the game object.
    void Start()
    {
        greenPortal = GameObject.FindFirstObjectByType<GreenPortal>();
        startTime = Time.time;
    }

    private void Update()
    {
        greenPortal = GameObject.FindFirstObjectByType<GreenPortal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (!greenPortal) return;
        Debug.Log("Made it to Line 30P");
        characterController = other.gameObject.GetComponentInParent<CharController>();
        if (characterController.timer > 0) return;
        other.gameObject.SetActive(false);
        other.transform.position = greenPortal.transform.position;
        other.gameObject.SetActive(true);
        characterController.timer = characterController.portalTimer;

        //sound effect
        playSound.Play();
    }


}
