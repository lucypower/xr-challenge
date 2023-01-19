using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOver;
    GameOverText m_gameOverText;

    [SerializeField] private TMP_Text m_text;

    private void Awake()
    {
        m_gameOverText = m_gameOver.GetComponent<GameOverText>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            WaterDeath();
        }
    }

    public void WaterDeath()
    {
        Debug.Log("Death");

        m_gameOverText.GameOver();

        m_text.text = "You Died From The Water!";

        // stop time
        // bring up ui that says death and cause of it
        // decrease lives if that's what I do
        // function to restart level/respawn player
    }
}
