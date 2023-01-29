using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameOverScreen : MonoBehaviour
{
    public Transform m_respawnPoint;
    public GameObject m_player;
    GameOverText m_gameOverText;

    private void Awake()
    {
        m_gameOverText = GetComponentInParent<GameOverText>();
    }

    public void Respawn()
    {
        Debug.Log("Respawn");

        m_gameOverText.m_gameOver.SetActive(false);
        m_player.transform.position = m_respawnPoint.transform.position;

        m_gameOverText.m_isPaused = false;

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Debug.Log("Restart");

        Time.timeScale = 1;
        m_gameOverText.m_isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

        Application.Quit();
    }
}
