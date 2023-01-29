using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_speed;
    public float m_sprintSpeed;
    public float m_crouchSpeed;

    public float m_sensitivity;
    public Transform m_cameraDolly;
    public Transform m_camera;
    Vector2 m_mouseRotation;

    Rigidbody m_RB;
    public float m_jumpForce;
    bool m_isGrounded = true;

    Vector3 m_scale;
    Vector3 m_crouchScale;
    [HideInInspector] public bool m_isCrouching;

    [SerializeField] private GameOverText m_gameOverText;
    [SerializeField] private GameObject m_gameOver;

    Vector3 m_direction;

    private void Start()
    {
        m_gameOverText = m_gameOver.GetComponent<GameOverText>();

        m_RB = GetComponent<Rigidbody>();
        m_scale = GetComponent<Transform>().localScale;

        //m_RB.velocity = Vector3.forward * 12;
        m_crouchScale = new Vector3(m_scale.x, m_scale.y / 2, m_scale.z);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_mouseRotation.x += Input.GetAxis("Mouse X") * m_sensitivity;
        m_mouseRotation.y += Input.GetAxis("Mouse Y") * m_sensitivity;
        m_mouseRotation.y = Mathf.Clamp(m_mouseRotation.y, -45, 45);

        if (!m_gameOverText.m_isPaused)
        {
            m_cameraDolly.rotation = Quaternion.Euler(-m_mouseRotation.y, m_mouseRotation.x, 0);
        }

        Vector3 cameraForward = m_camera.forward;
        Vector3 cameraRight = m_camera.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;
        m_direction = (cameraForward * vertical + cameraRight * horizontal);

        transform.Translate(m_speed * Time.deltaTime * m_direction);
        //m_RB.MovePosition(transform.position + (m_speed * Time.deltaTime * m_direction));
        

        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && !m_isCrouching)
        {
            Debug.Log("Sprint");

            transform.Translate(m_sprintSpeed * Time.deltaTime * m_direction);
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.Translate(m_crouchSpeed * Time.deltaTime * m_direction);
            Crouch();
        }
        else
        {
            m_isCrouching = false;
            transform.localScale = m_scale;
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
        m_RB.AddForce(Vector3.up * m_jumpForce, ForceMode.Acceleration);
    }

    public void Crouch()
    {
        m_isCrouching = true;
        transform.localScale = m_crouchScale;        
    }

    
}
