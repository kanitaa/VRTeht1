using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [SerializeField]
    GameObject invisibleBridge;

    [SerializeField]
    AudioSource audioS;
    [SerializeField]
    AudioClip bridgeVisibleAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !invisibleBridge.activeInHierarchy)
        {
            invisibleBridge.SetActive(true);
            audioS.PlayOneShot(bridgeVisibleAudio);
        }
    }
}
