using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject m_pauseScreen;

    public GameOverText m_gameOver;

    private void Awake()
    {
        m_gameOver.GetComponent<GameOverText>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        m_gameOver.m_isPaused = true;
        m_pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Debug.Log("Resume");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        m_gameOver.m_isPaused = false;
        m_pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
