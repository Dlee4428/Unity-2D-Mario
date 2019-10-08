using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject m_gameOverScreen;

    public void GameOverScreen()
    {
        m_gameOverScreen.SetActive(true);
    }

    /* private void Update()
     {
         if (Input.GetKeyDown(KeyCode.Escape))
         {
             if (!m_escMenuOpen)
             {
                 m_escMenu.SetActive(true);
                 m_escMenuOpen = true;
             } else
             {
                 m_escMenu.SetActive(false);
                 m_escMenuOpen = false;
             }
         }
     } */
}
