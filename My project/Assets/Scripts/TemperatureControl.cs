using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;

public class TemperatureControl : MonoBehaviour
{
    float _MaxTemperature=  110;
    float _CurrentTemperture;
    float _Inicialtemperature = 27;
    float _ConstantHeating = 0.1f; // Ajusta qué tan rápido sube la temperatura
    float _time = 0f;



    bool lightOn;
    [SerializeField] TextMeshProUGUI temperature;

   [SerializeField] particleController particleControl;
    // Start is called before the first frame update
    void Start()
    {
       //particleControl = GetComponent<particleController>();

       
    }
    void OnEnable()
    {
        ControlPanel.OnSimulatorOn += CheckTemperature;
    }
    void OnDisable()
    {
        ControlPanel.OnSimulatorOn -= CheckTemperature;
      
    }
    // Update is called once per frame
    void Update()
    {
       
       
        
    }
    void CheckTemperature()
    {
        _time += Time.deltaTime;
        _CurrentTemperture = _MaxTemperature + (_Inicialtemperature - _MaxTemperature) * Mathf.Exp(-_ConstantHeating * _time);
        //Debug.Log("ola causa, la temperatura es de : " + _CurrentTemperture);
        temperature.text = "Temperatura:" + _CurrentTemperture;

        if (_CurrentTemperture>= _MaxTemperature)
        {
            particleControl.StopFire();
            lightOn = true;
            //Debug.Log("noseapagacausa");
            //apagar el fuego, prender la luz amarilla
        }
       // lightOn = false;
    }

    public bool isOverload()
    {
        return lightOn ;
    }
}
