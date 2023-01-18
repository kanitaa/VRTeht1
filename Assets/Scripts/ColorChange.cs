using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChange : MonoBehaviour
{
    public InputActionReference colorReference = null;

    MeshRenderer mRenderer = null;
    float lastValue=0;


    private void Awake()
    {
        mRenderer = GetComponent<MeshRenderer>();
       
    }


    private void Update()
    {
        float value = colorReference.action.ReadValue<float>();
        if (value != lastValue)
        {
            UpdateColor(value);
            lastValue = value;
        }
    }
    void UpdateColor(float newValue)
    {
        mRenderer.material.color = new Color(newValue, newValue, 0);
    }
}
