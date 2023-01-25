using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishGameTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;

    private GameObject[] m_pickupsAvailable;
    [SerializeField] private GameObject m_player;
    PlayerStats m_playerStats;

    private void Start()
    {
        m_pickupsAvailable = GameObject.FindGameObjectsWithTag("Pickup");
        m_playerStats = m_player.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_playerStats.m_pickupsCollected == m_pickupsAvailable.Length)
            {
                m_text.text = "You collected all of the pickups!";
                // TODO : call win condition from another script
            }
            else
            {
                m_text.text = "Come back when you've collected all the pickups!";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_playerStats.m_pickupsCollected != m_pickupsAvailable.Length)
            {
                for (int i = 0; i < m_text.text.Length; i++)
                {
                    m_text.text = m_text.text.Remove(i);
                }
            }
        }
    }
}
