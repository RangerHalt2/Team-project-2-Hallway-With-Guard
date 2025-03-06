using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    [SerializeField] private GameObject slime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            slime.SetActive(true);
            Destroy(gameObject);
        }
    }

}
