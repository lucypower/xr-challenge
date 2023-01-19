using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public GameObject m_gameOver;
    public GameObject m_gameOverNoLives;
    public TMP_Text m_text1;
    public TMP_Text m_text2;

    [HideInInspector] public bool m_isPaused = false;

    public PlayerStats m_playerStats;

    private void Start()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void GameOver()
    {
        m_isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

        --m_playerStats.m_lives;

        if (m_playerStats.m_lives > 0)
        {
            m_gameOver.SetActive(true);

            m_text1.text = "You have " + m_playerStats.m_lives + " lives remaining";
        }
        else
        {
            m_gameOverNoLives.SetActive(true);

            m_text2.text = "You have no lives remaining!";
        }
    }
}
