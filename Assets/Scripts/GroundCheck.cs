using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck: MonoBehaviour {

  public PlayerMovement m_player;

    public LayerMask m_groundLayer;
    int m_groundLayerIndex;

    private void Awake()
    {
        m_groundLayerIndex = Mathf.RoundToInt(Mathf.Log(m_groundLayer.value, 2));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == m_groundLayerIndex)
        {
            m_player.m_grounded = true;
        }
    }
}
