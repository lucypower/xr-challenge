using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject m_pickup;    

    bool m_isCompleted = false;
    bool m_wentWrong = false;

    [SerializeField] private GameObject[] m_buttons;

    ButtonPressed m_redPressed;
    ButtonPressed m_bluePressed;
    ButtonPressed m_greenPressed;
    ButtonPressed m_greyPressed;

    bool m_redDown = false;
    bool m_blueDown = false;
    bool m_greenDown = false;

    float m_buttonNo = 0;


    private void Start()
    {
        m_redPressed = m_buttons[0].GetComponent<ButtonPressed>();
        m_bluePressed = m_buttons[1].GetComponent<ButtonPressed>();
        m_greenPressed = m_buttons[2].GetComponent<ButtonPressed>();
        m_greyPressed = m_buttons[3].GetComponent<ButtonPressed>();
    }

    private void Update()
    {
        if (!m_isCompleted && !m_wentWrong)
        {
            if (m_greenPressed.m_isPressed && m_buttonNo == 0)
            {
                Debug.Log("Green");
                GreenPressed();                
            }
            else if (m_greenPressed.m_isPressed && m_buttonNo != 0 && !m_greenDown)
            {
                m_wentWrong = true;
            }


            if (m_redPressed.m_isPressed && m_buttonNo == 1)
            {
                Debug.Log("Red");
                RedPressed();
            }
            else if (m_redPressed.m_isPressed && m_buttonNo != 1 && !m_redDown)
            {
                m_wentWrong = true;
            }


            if (m_bluePressed.m_isPressed && m_buttonNo == 2)
            {
                Debug.Log("Blue");
                BluePressed();
            }
            else if (m_bluePressed.m_isPressed && m_buttonNo != 2 && !m_blueDown)
            {
                m_wentWrong = true;
            }
        }
        
        if (m_greyPressed.m_isPressed)
        {
            Restart();
        }

        if (m_blueDown && m_redDown && m_greenDown)
        {
            if (m_pickup != null)
            {
                m_pickup.SetActive(true);
            }
        }
    }

    public void RedPressed()
    {
        m_redDown = true;
        m_buttonNo++;
    }

    public void BluePressed()
    {
        m_blueDown = true;
        m_buttonNo++;
        m_isCompleted = true;
    }

    public void GreenPressed()
    {
        m_greenDown = true;
        m_buttonNo++;
    }

    public void Restart()
    {
        Debug.Log("Restart");

        m_redPressed.ButtonReset();
        m_greenPressed.ButtonReset();
        m_bluePressed.ButtonReset();
        m_greyPressed.ButtonReset();

        m_redDown = false;
        m_greenDown = false;
        m_blueDown = false;

        m_buttonNo = 0;

        m_wentWrong = false;
        m_isCompleted = false;
    }
}
