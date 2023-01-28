using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public bool m_isPressed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!m_isPressed)
            {
                transform.Translate(new Vector3(0, -0.049f, 0), Space.Self);
                m_isPressed = true;
            }
        }
    }

    public void ButtonReset()
    {
        if(m_isPressed)
        {
            transform.Translate(new Vector3(0, 0.0495f, 0), Space.Self);
            m_isPressed = false;
        }
    }
}
