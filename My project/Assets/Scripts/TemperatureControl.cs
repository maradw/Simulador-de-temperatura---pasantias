using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;

public class TemperatureControl : MonoBehaviour
{
    float _MaxTemperature=  110;
    public float _CurrentTemperture;
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
    float _boilingTemperature =100;


    float q; //transferencia de calor (resultante creo XD
    float h = 200; // coeficiente de transferencia de convección / en teoria debia ser un valor entre 100 a 300
    float a = 51987.07f; //area en m2
    // use _time here
    float c; //diferencia de temperatura entre la superficie y el liquido
    float _waterTemp;

    float _waterBoil;

    void Start()
    {
        //formula 
       // _waterLevel = _waterControl.GetWaterLevel();
        //particleControl = GetComponent<particleController>();
        tankRenderer = GetComponent<Renderer>();// despues que funcione primero XD
        //_waterControl.GetWaterLevel();
        _waterTemp = _waterControl.GetTemperature();
        c =_CurrentTemperture - _waterTemp;
    }
    void CalculateHeatInWater()
    {
        q = -(h) * a * _time * c;//formula de transferencia del calor
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
        //la diferencia entre las tempraturas de ambos cuerpos va a ser un tema feo Xd
        // CheckWater();

        //xmientras:
        if (_CurrentTemperture >= _MaxTemperature)
        {
            particleControl.StopFire();
            lightOn = true;
            //Debug.Log("noseapagacausa");
            //apagar el fuego, prender la luz amarilla
        }

        if (_waterControl.GetWaterLevel() >= -1f && _waterControl.GetWaterLevel() <= 4f)//2.5 a 1, solo pruebas
        {
            //_time = 0f;
            _ConstantHeating = 0.004f; //noseo
            Debug.Log("ya no funciona wazaa");
        }
        else
        {
            _ConstantHeating = 0.005f;
        }
        if (_waterTemp >= _waterBoil)
        {
            //activar el vapor, vfx supongo, y disminuir agua minimamente//unfill cambia la velocidad
        }

    }

    void CheckWater() //esto no
    {
        if (_waterControl.GetWaterLevel() >= -2.5f && _waterControl.GetWaterLevel() <= 4f)//2.5 a 1, solo pruebas
        {
            //
           //_time = 0f;
            _ConstantHeating = 0.005f; //noseo
           // Debug.Log("ya no funciona wazaa");
        }
        else
        {
            _ConstantHeating = 0.05f;
        }
        // esto paso a check temperature

    }
    void CalculateTemperature()
    {
        _time += Time.deltaTime;  
        _CurrentTemperture = _MaxTemperature + (_Inicialtemperature - _MaxTemperature) * Mathf.Exp(-_ConstantHeating * _time); // otro booleano *gif bebe ceniza *
        //Debug.Log("ola causa, la temperatura es de : " + _CurrentTemperture);
        temperature.text = "Temperatura:" + _CurrentTemperture;
    }
    void CheckTemperature()
    {
        /* _time += Time.deltaTime;
         _CurrentTemperture = _MaxTemperature + (_Inicialtemperature - _MaxTemperature) * Mathf.Exp(-_ConstantHeating * _time); // otro booleano *gif bebe ceniza *
         //Debug.Log("ola causa, la temperatura es de : " + _CurrentTemperture);
         temperature.text = "Temperatura:" + _CurrentTemperture;
        */ 
        //nomas


        //en el update
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
        if (_waterTemp >= _waterBoil)
        {
            //activar el vapor, vfx supongo, y disminuir agua minimamente//unfill cambia la velocidad
        }
        // lightOn = false; 
    }
    void AutomaticMOde()
    {
        if(_waterLevel <= -4)
        {
            //esto creo q ya no
        }
    }
    public bool isOverload()
    {
        return lightOn ;
    }
}
