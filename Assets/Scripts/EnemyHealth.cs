using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int m_maxHealth = 2;
    public int m_currentHealth;
    public bool Death = false;

    //Components
    private Animator m_animator;


    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        m_currentHealth = m_maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HurtEnemy"))
        {
            if (TakeDamage(other.gameObject.GetComponent<HurtEnemy>().Damage))
            {
                Debug.Log("Goomba is dead");
                Die();
            }
        }
    }

    public bool TakeDamage(int damageToTake)
    {
        bool isDead = false;
        if (m_currentHealth <= 0)
        {
            isDead = true;
            return !isDead;
        }
        m_currentHealth -= damageToTake;
        if (m_currentHealth <= 0)
        {
            isDead = true;
            return isDead;
        }
        isDead = false;
        return isDead;
    }

    private void Die()
    {
        //TODO: Play death anim
        SoundManager.PlaySound("stomp");
        GetComponent<EnemyAI>().enabled = false;
        m_animator.SetBool("Death", true);
        Destroy(gameObject, 0.9f);
    }

    void OnEnable()
    {
        m_currentHealth = m_maxHealth;
    }
}
