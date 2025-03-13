using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;

public class TemperatureControl : MonoBehaviour
{
    public float _MaxTemperature=  105;//NOSE
    public float _CurrentTemperture;
    float _Inicialtemperature = 27;
    float _ConstantHeating = 0.05f; // Ajusta qué tan rápido sube la temperatura
    float _time = 0f;
    float _dangerTemp = 110;
    Renderer tankRenderer;
    float _waterLevel;

    bool lightOn;
    bool _fireOff;
    bool isFireOff()
    {
        return _fireOff;
    }
    public void SetIsFireOff(bool isFireOff)
    {
        _fireOff = isFireOff;
    }
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
        ControlPanel.OnSimulatorOn += CalculateTemperature;
        ControlPanel.OnAutomatic += Check;
    }
    void OnDisable()
    {
        ControlPanel.OnSimulatorOn -= CalculateTemperature;
        ControlPanel.OnAutomatic -= Check;
    }
    // Update is called once per frame
    void Update()
    {
        //la diferencia entre las tempraturas de ambos cuerpos va a ser un tema feo Xd
        // CheckWater();
        temperature.text = "Temperatura:" + _CurrentTemperture;
        //xmientras:
       

        if (_waterControl.GetWaterLevel() >= -1f && _waterControl.GetWaterLevel() <= 4f)//2.5 a 1, solo pruebas
        {
            //_time = 0f;
            _ConstantHeating = 0.04f; //noseo
            //Debug.Log("ya no funciona wazaa");
        }
        else
        {
            _ConstantHeating = 0.05f;
        }
        if (_waterTemp >= _waterBoil)
        {
            //activar el vapor, vfx supongo, y disminuir agua minimamente//unfill cambia la velocidad
        }

        //ebug.Log("DIAVLO, no prende luz amarilla");
        if (_CurrentTemperture >= 103f)//_MaxTemperature)
        {

            lightOn = true;
            //Debug.Log("noseapagacausa");
            //apagar el fuego, prender la luz amarilla
        }
        if(_fireOff == true && _CurrentTemperture>=_Inicialtemperature)
        {
            _CurrentTemperture -= 0.001f;
        }
        Debug.Log("causa esto es:" + _fireOff);

    }

    void Check()
    {
        Debug.Log("DIAVLO,apagate p");
        if (_CurrentTemperture>=_MaxTemperature)
        {
            _fireOff = true;
            particleControl.StopFire();
        }
    }
    void Aywe()
    {

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
     
    }
    
   
    public bool isOverload()
    {
        return lightOn ;
    }

























    void AutomaticMOde()
    {
        if (_waterLevel <= -4)
        {
            //esto creo q ya no
        }
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
        if (_CurrentTemperture >= _MaxTemperature)
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
}
