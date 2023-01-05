using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_speed;
    Rigidbody m_RB;

    private void Start()
    {
        m_RB = GetComponent <Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_RB.velocity = new Vector3(horizontal, m_RB.velocity.y, vertical) * m_speed;
    }
}
