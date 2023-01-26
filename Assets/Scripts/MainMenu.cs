using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_main;
    [SerializeField] private GameObject m_settings;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Settings()
    {
        m_main.SetActive(false);
        m_settings.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
