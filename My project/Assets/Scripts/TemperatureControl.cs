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
    float _ConstantHeating = 0.005f; // Ajusta qué tan rápido sube la temperatura
    float _time = 0f;

    Renderer tankRenderer;
    float _waterLevel;

    bool lightOn;
    [SerializeField] TextMeshProUGUI temperature;

   [SerializeField] particleController particleControl;
    [SerializeField] WatterLevel _waterControl;

    //header q no se como se hacia XD


    float q; //transferencia de calor (resultante creo XD
    float h; // coeficiente de transferencia de convección
    float a; //area en m2
    // use _time here
    float c; //diferencia de temperatura entre la superficie y el liquido


    void Start()
    {
        //formula 
       // _waterLevel = _waterControl.GetWaterLevel();
        //particleControl = GetComponent<particleController>();
        tankRenderer = GetComponent<Renderer>();// despues que funcione primero XD
        //_waterControl.GetWaterLevel();
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
       // CheckWater();

    }

    void CheckWater()
    {
        if (_waterControl.GetWaterLevel() >= -2.5f && _waterControl.GetWaterLevel() <= 4f)//2.5 a 1, solo pruebas
        {
            //
           //_time = 0f;
            _ConstantHeating = 0.005f; //noseo
            Debug.Log("ya no funciona wazaa");
        }
        else
        {
            _ConstantHeating = 0.05f;
        }


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

        if (_waterControl.GetWaterLevel() >= -1f && _waterControl.GetWaterLevel() <= 4f)//2.5 a 1, solo pruebas
        {
            //
            //_time = 0f;
           _ConstantHeating = 0.004f; //noseo
            Debug.Log("ya no funciona wazaa");
        }
        else
        {
            _ConstantHeating = 0.005f;
        }
        // lightOn = false;
    }

    public bool isOverload()
    {
        return lightOn ;
    }
}
