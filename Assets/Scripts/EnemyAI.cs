using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle,
    Wander,
    Chase
}
public class EnemyAI : MonoBehaviour
{
    // Damage Stuff
    public int m_damage = 1;
    public int Damage
    {
        get
        {
            return m_damage;
        }
    }

    // States stuff
    States m_currentState = States.Idle;
    public Transform m_target;

    //Wander stuff
    public Vector3 m_startPos;
    public Vector3 m_endPos;
    public float m_wanderOffset;
    bool m_moveRight = true;
    bool m_moveLeft = false;

    // Range stuff
    float m_chaseRange = 5f;

    // Movement stuff
    [HideInInspector]
    public bool m_facingRight = true;
    float m_currentSpeed;
    public float m_chaseSpeed = 0.5f;
    public float m_wanderSpeed = 0.5f;

    // Grounded stuff
    public Transform m_groundCheck;
    public bool m_grounded = false;
    float m_groundCheckRadius = 0.2f;
    public LayerMask m_groundLayer;

    // Components
    private Animator m_animator;
    private Rigidbody2D m_rb2d;

    // Called when game is first launched.
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        m_currentSpeed = m_wanderSpeed;
        m_startPos = new Vector3(transform.position.x - m_wanderOffset,
            transform.position.y, transform.position.z);
        m_endPos = new Vector3(transform.position.x + m_wanderOffset,
            transform.position.y, transform.position.z);
    }

    private void Update()
    {
        //if (Input.GetButtonDown("Jump") && m_grounded) {
        //    m_animator.SetBool("Ground", false);
        //    m_rb2d.AddForce(new Vector2(0, m_jumpForce));
        //}
    }

    private void FixedUpdate()
    {
        UpdateGroundCheck();
        UpdateStates();
        UpdateAnimations();

        switch (m_currentState)
        {
            case States.Wander:
                if (m_grounded)
                    Wander();
                break;
            case States.Chase:
                if (m_grounded)
                    Chase();
                break;
            default:
                break;
        }

        if (m_rb2d.velocity.x > 0 && !m_facingRight)
            Flip();
        else if (m_rb2d.velocity.x < 0 && m_facingRight)
            Flip();
    }

    void Flip()
    {
        m_facingRight = !m_facingRight;
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    void UpdateStates()
    {
        float distance = Vector2.Distance(m_target.position,
            transform.position);
        if (distance < m_chaseRange)
        {
            m_currentState = States.Chase;
        }
        else
        {
            m_currentState = States.Wander;
        }
    }

    void UpdateAnimations()
    {
        if (m_currentState == States.Chase)
        {
            m_animator.SetFloat("Speed", 0.5f);
        }
        else if (m_currentState == States.Wander)
        {
            m_animator.SetFloat("Speed", 0.25f);
        }
    }

    void UpdateGroundCheck()
    {
        m_grounded = Physics2D.OverlapCircle(m_groundCheck.position,
            m_groundCheckRadius, m_groundLayer);
        m_animator.SetBool("Ground", m_grounded);
    }

    void Wander()
    {
        if (transform.position.x > m_endPos.x && m_moveRight)
        {
            m_currentSpeed = -1;
            m_moveRight = false;
            m_moveLeft = true;
        }
        else if (transform.position.x < m_startPos.x && m_moveLeft)
        {
            m_currentSpeed = 1;
            m_moveRight = true;
            m_moveLeft = false;
        }
        m_rb2d.velocity = new Vector2(m_currentSpeed, m_rb2d.velocity.y);
    }

    void Chase()
    {
        m_currentSpeed = m_chaseSpeed;
        Vector2 direction = m_target.position - transform.position;
        Vector2 hDirection = new Vector2(direction.x, 0);
        Vector2 velocity = hDirection * m_currentSpeed;
        m_rb2d.velocity = velocity;
    }
}
