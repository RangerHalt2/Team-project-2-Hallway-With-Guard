using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private Canvas MasterCanvas;

    private void Start()
    {
        isPaused = false;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        AudioListener.pause = isPaused;
        //MasterCanvas.gameObject.SetActive(isPaused);

        if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
