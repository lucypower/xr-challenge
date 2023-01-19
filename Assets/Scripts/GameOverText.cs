using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public GameObject m_gameOver;
    public TMP_Text m_text;

    public PlayerStats m_playerStats;

    private void Start()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void GameOver()
    {
        --m_playerStats.m_lives;
        m_gameOver.SetActive(true);
        Time.timeScale = 0;

        m_text.text = "You have " + m_playerStats.m_lives + " lives remaining";
    }
}
