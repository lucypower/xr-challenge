using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameObject m_pickupPrefab;
    Pickup m_pickup;

    PlayerStats m_playerStats;

    private void Start()
    {
        m_pickup = m_pickupPrefab.GetComponent<Pickup>();
        m_playerStats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Pickup Collision");

            m_pickup.GetPickedUp(); // need to work out why iscollected is setting to true before the handle function

            m_playerStats.m_score += m_pickup.ScoreValue;
            m_playerStats.m_pickupsCollected++;

            //Destroy(other.gameObject);
        }
    }
}
