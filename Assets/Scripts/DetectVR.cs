using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject desktopCharacter;
    private void Start()
    {
        var xrSettings = XRGeneralSettings.Instance;

        if (xrSettings == null)
        {
            Debug.Log("XRGeneralSettings is null");
            return;
        }

        var xrManager = xrSettings.Manager;

        if (xrManager == null)
        {
            Debug.Log("XRManager is null");
            return;
        }

        var xrLoader = xrManager.activeLoader;

        if (xrLoader == null)
        {
            Debug.Log("XRLoader is null");
            xrOrigin.SetActive(false);
            desktopCharacter.SetActive(true);
            return;
        }
        Debug.Log("XRLoader is not null");
        xrOrigin.SetActive(true);
        desktopCharacter.SetActive(false);

    }
}
