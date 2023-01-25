using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Telekinesis : MonoBehaviour
{
    public InputActionReference telekinesisRotationReference = null;
    bool overTelekinesisObject;
    bool grabObject;
    [SerializeField]
    InputActionReference selectAction;

    [SerializeField]
    float grabMaxRotation, grabMinRotation, releaseGrabRotation;

    [SerializeField]
    bool rightHand;
 
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (args.interactableObject.transform.gameObject.CompareTag("TelekinesisObject"))
        {
            overTelekinesisObject = true;
            selectAction.action.Disable();
        }
      Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
     
    }
    public void OnHoverExited(HoverExitEventArgs args)
    {
        overTelekinesisObject = false;
        selectAction.action.Enable();
        Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);
   }
  
    private void Update()
    {
        if (rightHand)
        {
            //if rotation is good for grab
            float value = telekinesisRotationReference.action.ReadValue<Quaternion>().eulerAngles.z;
            if (value < grabMaxRotation && value != 0 && value! > grabMinRotation && overTelekinesisObject && !grabObject)
            {
                grabObject = true;
                //grab object
                GetComponent<XRRayInteractor>().hoverToSelect = true;
                Debug.Log("GRAB");
            }
            if (value > releaseGrabRotation && overTelekinesisObject && grabObject)
            {
                grabObject = false;
                GetComponent<XRRayInteractor>().hoverToSelect = false;
                Debug.Log("RELEASE");
            }

        }else if (!rightHand)
        {
            //if rotation is more than min for grab
            float value = telekinesisRotationReference.action.ReadValue<Quaternion>().eulerAngles.z;
            if (value > grabMinRotation && value <grabMaxRotation && overTelekinesisObject && !grabObject)
            {
                grabObject = true;
                //grab object
                GetComponent<XRRayInteractor>().hoverToSelect = true;
                Debug.Log("GRAB");
            }
            if (value < releaseGrabRotation && overTelekinesisObject && grabObject)
            {
                grabObject = false;
                GetComponent<XRRayInteractor>().hoverToSelect = false;
                Debug.Log("RELEASE");
            }
        }

    }
}
