using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer m_audioMixer;
    public TMP_Dropdown m_resDropdown;
    Resolution[] m_resolution;

    private void Start()
    {
        m_resolution = Screen.resolutions;
        int currentRes = 0;

        List<string> resOptions = new List<string>();

        for (int i = 0; i < m_resolution.Length; i++)
        {
            string res = m_resolution[i].width + " x " + m_resolution[i].height;
            resOptions.Add(res);

            if (m_resolution[i].width == Screen.currentResolution.width && m_resolution[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        m_resDropdown.ClearOptions();
        m_resDropdown.AddOptions(resOptions);
        m_resDropdown.value = currentRes;
        m_resDropdown.RefreshShownValue();
    }

    public void Volume(float volume)
    {
        m_audioMixer.SetFloat("volume", volume);
    }

    public void Fullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void Resolution(int index)
    {
        Resolution resolutions = m_resolution[index];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }

    public void Quality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
