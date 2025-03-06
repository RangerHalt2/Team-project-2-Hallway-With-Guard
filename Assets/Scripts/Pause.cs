using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private Canvas PauseBody;

    private void Start()
    {
        isPaused = false;
    }

    public void TogglePause()
    {
        Debug.Log("In toggle");
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        AudioListener.pause = isPaused;
        if (!isPaused)
            PauseBody.gameObject.SetActive(isPaused);

        if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
