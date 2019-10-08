using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageClear : MonoBehaviour {

    public PlayerMovement playerMovement;
    public float restartDelay = 5f;
    private bool isClear;

    float restartTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            if (m_player != null)
            {
                SoundManager.StopSound("background");
                SoundManager.PlaySound("stageClear");
                Debug.Log("Stage Clear!");
                isClear = true;
                playerMovement.enabled = false;
                playerMovement.m_spriteRenderer.enabled = false;
            }
        }
    }

    void Update()
    {
        if (isClear)
        {
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("mainMenu");
            }
        }
    }
}
