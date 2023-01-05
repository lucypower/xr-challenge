using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    PlayerScore m_playerScore;

    public GameObject m_pickupPrefab;
    Pickup m_pickup;

    private void Start()
    {
        m_playerScore = GetComponent<PlayerScore>();
        m_pickup = m_pickupPrefab.GetComponent<Pickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Pickup Collision");

            m_pickup.GetPickedUp(); // need to work out why iscollected is setting to true before the handle function

            m_playerScore.m_score += m_pickup.ScoreValue;
            //Destroy(other.gameObject);
        }
    }
}
