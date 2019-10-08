using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int m_maxHealth = 1;
    public int m_currentHealth;
    public bool Death = false;
    public bool PowerUp = false;
    public float invinciblilityLength;
    private float invincibilityCounter;
    public int count = 0;
    public int timeCount = 0;
    public Text countText;
    public Text timeCountText;

    //Components
    private Animator m_animator;
    private Animation m_animation;
    private Rigidbody2D m_rigidbody2D;
    public HUD m_hud;
    public PlayerMovement m_player;
    public EnemyAI m_enemyAI;


    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_animation = GetComponent<Animation>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_player = GetComponent<PlayerMovement>();
        m_enemyAI = GetComponent<EnemyAI>();
    }

    void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            m_animation.Play("Player_RedFlash");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("KillZone"))
        {
            if (TakeDamage(other.gameObject.GetComponent<KillZone>().Damage))
            {
                SoundManager.StopSound("background");
                SoundManager.PlaySound("death");
                Debug.Log("ARRRRRRRRRGGGGGGG!");
                Die();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (TakeDamage(other.gameObject.GetComponent<EnemyAI>().Damage))
            {
                SoundManager.StopSound("background");
                SoundManager.PlaySound("death");
                Debug.Log("GoodBye Mario!");
                Die();
            }
        }
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            m_rigidbody2D.AddForce(new Vector3(knockbackDir.x * -100,
                knockbackDir.y * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }

    private bool TakeDamage(int damageToTake)
    {
        bool isDead = false;
        if (m_currentHealth <= 0 && m_maxHealth <= 0)
        {
            isDead = true;
            return !isDead;
        }
        if (invincibilityCounter <= 0)
        {
            m_currentHealth -= damageToTake;
            m_maxHealth -= damageToTake;
            Debug.Log("Argh! Damaged by 1!");
            m_animation.Play("Player_RedFlash");
            RevertBack();
            KnockOnContact();
            invincibilityCounter = invinciblilityLength;
        }
        if (m_currentHealth <= 0 && m_maxHealth <= 0)
        {
            isDead = true;
            return isDead;
        }
        isDead = false;
        return isDead;
    }

    public void Die()
    {
        //TODO: Play death anim
        m_animator.SetBool("Death", true);
        //TODO: Play particle system
        m_hud.GameOverScreen();
        // m_particleSystem.Play();
        //TODO: Reset player
        GetComponent<PlayerMovement>().enabled = false;
    }

    public void Mushroom()
    {
        SoundManager.PlaySound("powerup");
        m_maxHealth += 1;
        m_currentHealth += 1;
        m_animator.SetBool("PowerUp", true);
        m_animation.Play("Player_RedFlash");
    }

    public void RevertBack()
    {
        m_animator.SetBool("PowerUp", false);
    }

    private void KnockOnContact()
    {
        if (m_currentHealth > 0 && m_maxHealth > 0){
            StartCoroutine(Knockback(0.02f, 0, transform.position));
        } else if (m_currentHealth <= 0 && m_maxHealth <= 0){
            StartCoroutine(Knockback(0, 0, transform.position));
        }
    }

    void OnEnable()
    {
        m_currentHealth = m_maxHealth;
    }
}
