using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_speed;
    public float m_sprintSpeed;

    public float m_sensitivity;
    public Transform m_cameraDolly;
    public Transform m_camera;
    Vector2 m_mouseRotation;

    Rigidbody m_RB;
    public float m_jumpForce;
    bool m_isGrounded = true;

    Vector3 m_scale;
    Vector3 m_crouchScale;
    bool m_isCrouching;

    private void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_scale = GetComponent<Transform>().localScale;

        m_crouchScale = new Vector3(m_scale.x, m_scale.y / 2, m_scale.z);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_mouseRotation.x += Input.GetAxis("Mouse X") * m_sensitivity;
        m_mouseRotation.y += Input.GetAxis("Mouse Y") * m_sensitivity;
        m_mouseRotation.y = Mathf.Clamp(m_mouseRotation.y, -45, 45);

        m_cameraDolly.rotation = Quaternion.Euler(-m_mouseRotation.y, m_mouseRotation.x, 0);

        Vector3 cameraForward = m_camera.forward;
        Vector3 cameraRight = m_camera.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        transform.Translate((cameraForward * vertical + cameraRight * horizontal) * Time.deltaTime * m_speed);

        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            EnterCrouch();
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            ExitCrouch();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = true;
        }
    }

    public void Jump()
    {
        Debug.Log("Jump");

        m_isGrounded = false;
        m_RB.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
    }

    public void Sprint()
    {
        transform.Translate(m_sprintSpeed * Time.deltaTime * transform.forward);
    }

    public void EnterCrouch()
    {
        m_isCrouching = true;
        transform.localScale = m_crouchScale;
    }

    public void ExitCrouch()
    {
        m_isCrouching = false;
        transform.localScale = m_scale;
    }
}
