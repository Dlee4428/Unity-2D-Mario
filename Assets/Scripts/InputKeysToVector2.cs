using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeysToVector2 : InputComponent
{
    [Header("Keys")]
    [SerializeField] private KeyCode up = KeyCode.W;
    [SerializeField] private KeyCode down = KeyCode.S;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode jump = KeyCode.Space;
    [Header("Data")]
    [SerializeField] private string dataName = "inputVector2";

    private DataNode cacheVector;

    // Grounded stuff
    public Transform m_groundCheck;
    public bool m_grounded = false;
    public LayerMask m_groundLayer;
    public bool IsRunning = false;

    // Components
    public float m_jumpForce = 250f;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody2D;
    public SpriteRenderer m_spriteRenderer;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public override void Gather(Data data)
    {
        data[dataName] = cacheVector = new DataNode();
    }

    public override void Input()
    {
        Vector2 v = Vector2.zero;

        if (UnityEngine.Input.GetKey(up))
            v.y += 1;
        if (UnityEngine.Input.GetKey(down))
            v.y -= 1;
        if (UnityEngine.Input.GetKey(left))
            v.x -= 1;
        if (UnityEngine.Input.GetKey(right))
            v.x += 1;
        if (UnityEngine.Input.GetKey(jump) && m_grounded)
        {
            SoundManager.PlaySound("jumpSmall");
            m_animator.SetBool("Ground", false);
            m_rigidbody2D.AddForce(new Vector2(0, m_jumpForce));
            m_grounded = false;
        }

        v.Normalize();

        cacheVector.Assign(v);
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Ground", m_grounded);
    }
}
