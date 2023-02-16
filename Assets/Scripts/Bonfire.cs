using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField]
    GameObject fireEffect;
    [SerializeField]
    GameObject doorToOpen;
    [SerializeField]
    GameObject blockXrayDoor;

    [SerializeField]
    AudioSource dooraudioS;

    [SerializeField]
    AudioClip doorOpenClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Torch") && blockXrayDoor.activeInHierarchy)
        {
            fireEffect.SetActive(true);
            dooraudioS.PlayOneShot(doorOpenClip);
            blockXrayDoor.SetActive(false);
            doorToOpen.transform.rotation = Quaternion.Euler(-90, 0, -58);
            doorToOpen.transform.position = doorToOpen.transform.position + new Vector3(-0.4f, 0, -0.2f);
        }
    }
}
