using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement m_player = other.GetComponent<PlayerMovement>();
            if (m_player != null)
            {
                Debug.Log("Above the Underworld!");
                m_player.PipeUnderworld();
            }
        }
    }
}
