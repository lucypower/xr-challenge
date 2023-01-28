using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    Pickup m_pickup;

    public GameObject m_player;
    PlayerStats m_playerStats;

    IEnumerator m_coroutine;

    private void Start()
    {
        m_pickup = GetComponent<Pickup>();
        m_playerStats = m_player.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pickup Collision");

            m_pickup.GetPickedUp(); 

            m_playerStats.m_score += m_pickup.ScoreValue; 
            m_playerStats.m_pickupsCollected++; 

            StartCoroutine(m_coroutine = Timer(0.5f));
        }
    }

    public void DestroyPickup()
    {
        StopCoroutine(m_coroutine);
        Destroy(gameObject);
    }

    IEnumerator Timer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DestroyPickup();
    }

}
