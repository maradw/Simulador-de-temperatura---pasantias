using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public static event Action OnFireOn;
    public static event Action OnSimulatorOn;
    public static event Action OnSimulatorStop;
    public static event Action OnAutomatic;

    public static event Action OnTemperatureHigh;// XDfantasmaXD

    public static event Action OnEmergency; //Solo lucecitas

    [SerializeField] private Light[] _panelLights;

    [SerializeField] private GameObject[] _controlButton;


    [SerializeField] TemperatureControl temperatureControl;
    [SerializeField] WatterLevel waterLevel;
    //boolpqsi
    bool _switchState = false;
    bool _isFillingWater;
    //estado triple wazaaaa
    float _stateType = 0;


    bool isOn = false;
    //switchers
    [SerializeField] private GameObject[] _switchers;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Debug.Log("olacausa");
        for (int i = 0; i < _panelLights.Length; i++)
        {
            _panelLights[i].enabled = false;
        }
    }

    void Update()
    {
        DetectButtonPress();
        if (_switchState)
        {
           // Debug.Log("prendio");//lo de prenderla temperatura // aqui para apapar si se sobrecalientala tmepratura
         
           // OnSimulatorOn?.Invoke();
            if (temperatureControl.isOverload() == true)//creo q vamos a tener q cambiar ese if x un while
            {
                _panelLights[1].enabled = true;
                //_panelLights[3].enabled = false; //y la luz para cuando
                Debug.Log("ymiluzamarillacausa");
            }
            else if(waterLevel.GetIsWaterLow() == true) //miedo terror ozuna
            {
                _panelLights[4].enabled = true;
                Debug.Log("ymiluzrojacausa"); 
            }
            else
            {
                _panelLights[4].enabled = false;
                _panelLights[1].enabled = false;
            }

            
        }
        
        if (temperatureControl._CurrentTemperture <= 115)
        {
            //apagar el fuego
        }

        void DetectButtonPress()
        {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {

                for (int i = 0; i < _controlButton.Length; i++)
                {
                    if (hit.collider.gameObject == _controlButton[i])
                    {

                        if (Input.GetMouseButtonDown(0))
                        {
                            OnButtonClick(i);
                        }
                        break;
                    }
                }
            }
        }


        void OnButtonClick(int buttonIndex)
        {

            switch (buttonIndex)
            {
                case 1:
                    Debug.Log("Bot�n 2 presionado - off/on \n prender el faro ese XD");
                    // _switchState = true;
                    if (_switchState)
                    {
                        //apagado//apagado//apagado//apagado//apagado//apagado//apagado//apagado
                        _switchers[0].transform.eulerAngles = new Vector3(0, 0, -27);
                        OnSimulatorStop?.Invoke();
                        // _panelLights[0].enabled = false;
                        _panelLights[4].enabled = false;
                    }
                    else
                    {
                        //encendido//encendido//encendido//encendido//encendido//encendido//encendido
                        _switchers[0].transform.eulerAngles = new Vector3(0, 0, 30);
                        OnFireOn?.Invoke();
                        //_panelLights[2].enabled = true;
                        Debug.Log("qfue");
                    }
                    _switchState = !_switchState;

                    _panelLights[0].enabled = !_panelLights[0].enabled;
                    _panelLights[2].enabled = !_panelLights[2].enabled;
                    //_switchers[0].transform.eulerAngles =new Vector3 (0,0,-27);
                    //cuando se enciende, se prende automaticamente el fuego
                    break;
                case 2:
                    Debug.Log("Bot�n 3 presionado - manual/oof/automatic");
                    if (_switchState)
                    {
                        switch (_stateType)
                        {
                            case 0:
                                //manual
                                _switchers[1].transform.eulerAngles = new Vector3(0, 0, -50);
                                Debug.Log("no");
                                break;
                            case 1:
                                //off
                                Debug.Log("oe");
                                _switchers[1].transform.eulerAngles = new Vector3(0, 0, 0);
                                break;

                            case 2:
                                //automatic
                                _switchers[1].transform.eulerAngles = new Vector3(0, 0, 50);
                                OnAutomatic?.Invoke();
                                Debug.Log("funciona"); // llamar a atomatic fill, falta condicion de apagado y eso
                                break;
                        }
                        _stateType = (_stateType + 1) % 3;
                    }
                    break;
                case 3:
                    Debug.Log("Bot�n 4 presionado - quemador");
                    //cambio al boton de encendido, prendido automatico
                    break;

                case 4:
                    Debug.Log("Bot�n 5 presionado - bomba agua");
                    //cuando el tanque se llen de agua
                    break;

                case 5:
                    Debug.Log("Bot�n 6 presionado - falla sobrecarga");
                    break;

                case 6:
                    Debug.Log("Bot�n 7 presionado - alarma");
                    break;

                case 7:
                    Debug.Log("Bot�n 8 presionado - parada de emergencia");
                   // OnEmergency?.Invoke();
                    OnSimulatorStop?.Invoke();//aquiseapaga falta a�adir el agua al mismo evento //agua y temp luces quemador
                    _panelLights[2].enabled = false;
                    break;
                default:
                    Debug.Log("novale wazaaaaaa");
                    break;
            }
        }
    }
}

