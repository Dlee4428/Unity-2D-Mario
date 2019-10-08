using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [HideInInspector]
    public bool m_facingRight = true;
    float m_currentSpeed;
    public float m_runSpeed = 3.2f;
    public float m_speed = 2f;

    // Grounded stuff
    public Transform m_groundCheck;
    public bool m_grounded = false;
    public LayerMask m_groundLayer;
    public bool IsRunning = false;

    // Jump stuff
    public float m_jumpForce = 250f;

    // Components
    private Animator m_animator;
    private Rigidbody2D m_rigidbody2D;
    public QuestionBlock m_questionBlock;
    public SpriteRenderer m_spriteRenderer;

    // Called when game is first launched.
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        m_currentSpeed = m_speed;
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump") && m_grounded)
        {
            SoundManager.PlaySound("jumpSmall");
            m_animator.SetBool("Ground", false);
            m_rigidbody2D.AddForce(new Vector2(0, m_jumpForce));
            m_grounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_currentSpeed = m_runSpeed;
            m_animator.SetBool("IsRunning", true);
        }
        else
        {
            m_currentSpeed = m_speed;
            m_animator.SetBool("IsRunning", false);
        }
    }


    private void FixedUpdate()
    {
        m_animator.SetBool("Ground", m_grounded);
        m_animator.SetFloat("vSpeed", m_rigidbody2D.velocity.y);

        float h = Input.GetAxis("Horizontal");
        m_animator.SetFloat("Speed", Mathf.Abs(h));

        m_rigidbody2D.velocity = new Vector2(h * m_currentSpeed, m_rigidbody2D.velocity.y);
      
        if (h > 0 && !m_facingRight)
            Flip();
        else if (h < 0 && m_facingRight)
            Flip();
    }

    void Flip()
    {
        m_facingRight = !m_facingRight;
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public void PipeUnderworld()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_currentSpeed = m_runSpeed;
            m_animator.SetBool("IsRunning", true);
        }
    }
}