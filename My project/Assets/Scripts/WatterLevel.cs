using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WatterLevel : MonoBehaviour
{
    [SerializeField] private Material _waterShader;
    [SerializeField] private float _fillSpeed = 0.01f;

    [SerializeField] TextMeshProUGUI _waterLevel;

    float _level = -5.4f;

    float _minLevelA = -5.4f; //rango minimo
    float _minLevelB = -3.4f;
    float _maxLevelA = 3.5f; //ranog maximo
    float _maxLevelB = 6.5f;
    // Start is called before the first frame update

    bool _isWaterLow;
    float waterTemperature = 25f;
    void Start()
    {
       // _waterShader.SetFloat("_WaterLevel", _level);
      // _level = _waterShader.GetFloat("_fiil"); esto guarda automaticamnete el valor de fill en la sesion anteroir un scriptableobj gratis wazaaaaa
    }
    void OnEnable()
    {
       // ControlPanel.OnSimulatorOn += FillUpWater;
        ControlPanel.OnAutomatic += AutomaticFill;
        ControlPanel.OnManual += ManualFill;
    }
    void OnDisable()
    {
        //ControlPanel.OnSimulatorOn -= FillUpWater;
        ControlPanel.OnAutomatic -= AutomaticFill;
        ControlPanel.OnManual -= ManualFill;
    }
    void Update()
    {
        _waterLevel.text = "water level: " + _level;
        if (_level >= _minLevelA && _level <= _minLevelB)
        {
            _isWaterLow = true;
            // Debug.Log("se esta secando causa, prende la luz roja");
        }
        else if (_level >= _minLevelB)
        {
            _isWaterLow = false;
        }


        else if (_level >= _maxLevelA && _level <= _maxLevelB)
        {
            // Debug.Log("mucha awa causa");
            //UnfillWater();

        }
        else
        {

        }
        // esto tambien la parecer
        //FillUpWater();
        //UnfillWater();
       // AutomaticFill();//probar
    }
   
    public float GetTemperature()
    {
        return waterTemperature;
    }
    void FillUpWater()
    {
        _level += Time.deltaTime * _fillSpeed;
        _waterShader.SetFloat("_fiil", _level);
        //solo esto deberia ir en el update creo *inserte gif de bebe ceniza*

        // hasta aqui


        // Debug.Log(_level);

    }
    public bool GetIsWaterLow()
    {
        return _isWaterLow;
    }
    void UnfillWater()//para el modo manual, automatico no seria necesario
    {
        //activarcuando el agua esta demasiado llena
        _level -= Time.deltaTime * _fillSpeed;
         _waterShader.SetFloat("_fiil", _level);
        //Debug.Log("waza, se va el agua" + _level);
    }
    
    public float GetWaterLevel()
    {
        return _level;
    }
    
   void ManualFill()
    {
        FillUpWater();
    }
    void AutomaticFill() //funciona
    {
        /*_level += Time.deltaTime * _fillSpeed;
        _waterShader.SetFloat("_fiil", _level);*/
        Debug.Log("pqnoprende");
        if (_level >= _minLevelB && _level <=_maxLevelA )//actualizar en el proceso
        {
            FillUpWater();
            Debug.Log("modo automatico wazaaaaaaaa");
        }
        else if (_level <= _minLevelB )//bool de encendido
        {
            Debug.Log("para iniciar wazaaaa");
            FillUpWater();
        }
        else if (_level >= _maxLevelA && _level <= _maxLevelB)//nofijoXD
        {
            // Debug.Log("mucha awa causa");
            UnfillWater();

        }
        else //estable
        {
            Debug.Log("sufiente agua, wazaaaaaaa");
        }

    }






















    void StopFill()
    {

    }
}
