using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Telekinesis : MonoBehaviour
{
    public InputActionReference telekinesisSelectReference = null;
    bool overTelekinesisObject;
    bool grabObject;
 
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (args.interactableObject.transform.gameObject.CompareTag("TelekinesisObject"))
        {
            overTelekinesisObject = true;
        }
      Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
     
    }
    public void OnHoverExited(HoverExitEventArgs args)
    {
        overTelekinesisObject = false;
        Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);
   }

    private void Update()
    {
        //if rotation is more than min for grab
        float value = telekinesisSelectReference.action.ReadValue<Quaternion>().eulerAngles.z;
        if (value < 300 && value!=0 && value !>200 &&overTelekinesisObject && !grabObject)
        {
            grabObject = true;
            //grab object
            GetComponent<XRRayInteractor>().hoverToSelect = true;
            Debug.Log("GRAB");
        }
       if(value > 320 && overTelekinesisObject && grabObject)
        {
            grabObject = false;
            GetComponent<XRRayInteractor>().hoverToSelect = false;
            Debug.Log("UNGRAB");
        }
       
    }
}
