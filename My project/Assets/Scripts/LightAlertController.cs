using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightAlertController : MonoBehaviour
{
    Renderer alarmRenderer;
    void Start()
    {
         alarmRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LightsOn()
    {
        alarmRenderer.material.SetColor("Color", Color.green);
        Debug.Log("q paso causa");
    }
    void OnEnable()
    {
        ControlPanel.OnSimulatorOnOff += LightsOn;
    }
    void OnDisable()
    {
        ControlPanel.OnSimulatorOnOff -= LightsOn;
    }

}
