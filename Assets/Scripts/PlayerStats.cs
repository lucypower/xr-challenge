using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int m_score = 0;
    public int m_lives = 5;
    public int m_pickupsCollected = 0;
    private GameObject[] m_pickupsAvailable;

    public TMP_Text m_scoreText;
    public TMP_Text m_livesText;
    public TMP_Text m_pickupsText;

    private void Start()
    {
        m_pickupsAvailable = GameObject.FindGameObjectsWithTag("Pickup");
    }

    private void Update()
    {
        m_scoreText.text = "Score : " + m_score;

        m_livesText.text = "Lives : " + m_lives;

        m_pickupsText.text = m_pickupsCollected + " / " + m_pickupsAvailable.Length;
    }
}
