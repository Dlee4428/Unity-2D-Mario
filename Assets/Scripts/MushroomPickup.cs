using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPickup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            if (m_player != null)
            {
                Debug.Log("Mushroom! Health increase by 1");
                Destroy(this.gameObject);
                m_player.Mushroom();
            }
        }
    }
}
