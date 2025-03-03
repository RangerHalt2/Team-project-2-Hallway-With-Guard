using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{
    private WinLossManager wlManager;

    // Start is called before the first frame update
    void Start()
    {
        wlManager = GameObject.FindAnyObjectByType<WinLossManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            wlManager.Win();
    }

}
