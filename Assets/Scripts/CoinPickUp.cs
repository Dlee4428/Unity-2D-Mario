using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickUp : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            if (m_player != null)
            {
                SoundManager.PlaySound("coin");
                Debug.Log("Coin Collected!");
                Destroy(this.gameObject);
                m_player.count = m_player.count + 1;
                m_player.countText.text = m_player.count.ToString();
            }
        }
    }
}
