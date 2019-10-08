using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    // Damage Stuff
    public int m_damage = 2;
    public int Damage
    {
        get
        {
            return m_damage;
        }
    }

    public float bounceOnEnemy;

    private Rigidbody2D m_rigidbody2D;

    void Start()
    {
        m_rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, bounceOnEnemy);
        }
    }
}
