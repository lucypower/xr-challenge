using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCorridorText : MonoBehaviour
{
    public GameObject m_text1;
    public GameObject m_text2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_text1.SetActive(false);
            m_text2.SetActive(true);
        }
    }
}
