using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOver;
    GameOverText m_gameOverText;
    PlayerStats m_playerStats;
    PlayerMovement m_playerMovement;

    [SerializeField] private TMP_Text m_text1;
    [SerializeField] private TMP_Text m_text2;

    private void Awake()
    {
        m_gameOverText = m_gameOver.GetComponent<GameOverText>();
        m_playerStats = GetComponent<PlayerStats>();
        m_playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            if (m_playerStats.m_lives > 1)
            {
                if (collision.gameObject.CompareTag("Water"))
                {
                    WaterDeath();
                }
            }
            else
            {
                EndGameDeath();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(m_playerStats.m_lives > 1)
        {
            if(!m_playerMovement.m_isCrouching)
            {
                if (other.gameObject.CompareTag("Spike"))
                {
                    SpikeDeath();
                }
            }
        }
        else
        {
            EndGameDeath();
        }
    }

    public void WaterDeath()
    {
        Debug.Log("Death");

        m_gameOverText.GameOver();

        m_text1.text = "You Died From The Water!";
    }

    public void SpikeDeath()
    {
        Debug.Log("Death");

        m_gameOverText.GameOver();

        m_text1.text = "You Died From Spikes!";
    }

    public void EndGameDeath()
    {
        m_gameOverText.GameOver();

        m_text2.text = "You Died!";
    }
}
