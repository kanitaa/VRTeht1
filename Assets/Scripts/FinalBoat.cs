using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoat : MonoBehaviour
{
    bool gameOver;

    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    AudioSource audioS;
    [SerializeField]
    AudioClip gameOverClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gameOver)
        {
            gameOverPanel.SetActive(true);
            audioS.PlayOneShot(gameOverClip);
            gameOver = true;
        }
    }
}
