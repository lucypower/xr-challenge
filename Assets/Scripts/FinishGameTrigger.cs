using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishGameTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;
    [SerializeField] private GameObject m_winScreen;

    private GameObject[] m_pickupsAvailable;
    [SerializeField] private GameObject m_player;
    PlayerStats m_playerStats;
    public GameOverText m_gameOver;

    private void Start()
    {
        m_pickupsAvailable = GameObject.FindGameObjectsWithTag("Pickup");
        m_playerStats = m_player.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_playerStats.m_pickupsCollected == (m_pickupsAvailable.Length + 1))
            {
                WinGame();
            }
            else
            {
                m_text.text = "Come back when you've collected all the stars!";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_playerStats.m_pickupsCollected != (m_pickupsAvailable.Length + 1))
            {
                for (int i = 0; i < m_text.text.Length; i++)
                {
                    m_text.text = m_text.text.Remove(i);
                }
            }
        }
    }

    public void WinGame()
    {
        m_winScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        m_gameOver.m_isPaused = true;
        Time.timeScale = 0;
    }
}
