using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCorridorText : MonoBehaviour
{
    public GameObject[] m_gameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");

            m_gameObject[0].SetActive(false);
            m_gameObject[1].SetActive(true);
        }
    }
}
