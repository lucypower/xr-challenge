using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCorridorText : MonoBehaviour
{
    public GameObject m_gameObject;
    public GameObject m_gameObject2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");

            m_gameObject.SetActive(false);
            m_gameObject2.SetActive(true);
        }
    }
}
