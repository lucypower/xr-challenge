using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    Pickup m_pickup;

    public GameObject m_player;
    PlayerStats m_playerStats;

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

            m_playerStats.m_score += m_pickup.ScoreValue; // need something around here ish to stop score increasing and pickups collected when running over the object
            m_playerStats.m_pickupsCollected++; // maybe a coroutine when collected then set active false a small while later

        }
    }


}
