using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate1 : MonoBehaviour
{
    [SerializeField] GameObject gate;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gate.SetActive(false);
        }
    }
    /*
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Barrel")
        {
            gate.SetActive(true);
        }
    }
    */
}
