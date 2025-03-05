using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public static event Action OnButtonFirePressed;
    public static event Action OnSimulatorOn;
    public static event Action OnSimulatorStop;

    
    public static event Action OnTemperatureHigh;

    public static event Action OnEmergency;

    [SerializeField] private Light[] _panelLights;

    [SerializeField] private GameObject[] _controlButton;


    [SerializeField] TemperatureControl temperatureControl;

    //boolpqsi
    bool _switchState = false;
    //estado triple wazaaaa
    float _stateType = 0;

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
            OnSimulatorOn?.Invoke();
            if (temperatureControl.isOverload() == true)//creo q vamos a tener q cambiar ese if x un while
            {
                _panelLights[1].enabled = true;
                //_panelLights[3].enabled = false; //y la luz para cuando
                Debug.Log("ymiluzamarillacausa");
            }
            
        }
        else
        {

           // Debug.Log("ta apagao");
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
                case 0:
                    Debug.Log("Botón 1 presionado - energizado");
                    break;
                case 1:
                    Debug.Log("Botón 2 presionado - off/on \n prender el faro ese XD");
                    // _switchState = true;
                    if (_switchState)
                    {
                        _switchers[0].transform.eulerAngles = new Vector3(0, 0, -27);

                        OnSimulatorStop?.Invoke();
                    }
                    else
                    {
                        _switchers[0].transform.eulerAngles = new Vector3(0, 0, 30);
                        OnButtonFirePressed?.Invoke();
                       
                        Debug.Log("qfue");
                    }
                    _switchState = !_switchState;

                    _panelLights[0].enabled = !_panelLights[0].enabled;
                    _panelLights[2].enabled = !_panelLights[2].enabled;
                    //_switchers[0].transform.eulerAngles =new Vector3 (0,0,-27);
                    //cuando se enciende, se prende automaticamente el fuego


                    break;

                case 2:
                    Debug.Log("Botón 3 presionado - manual/oof/automatic");
                    switch (_stateType)
                    {
                        case 0:
                            //off
                            Debug.Log("oe");
                            _switchers[1].transform.eulerAngles = new Vector3(0, 0, 0);
                            break;
                        case 1:
                            //manual
                            _switchers[1].transform.eulerAngles = new Vector3(0, 0, -50);
                            Debug.Log("no");
                            break;
                        case 2:
                            //automatic
                            _switchers[1].transform.eulerAngles = new Vector3(0, 0, 50);
                            Debug.Log("funciona");
                            break;



                    }
                    _stateType = (_stateType + 1) % 3;
                    break;



                case 3:
                    Debug.Log("Botón 4 presionado - quemador");
                    //cambio al boton de encendido, prendido automatico
                    break;

                case 4:
                    Debug.Log("Botón 5 presionado - bomba agua");
                    //cuando el tanque se llen de agua
                    break;

                case 5:
                    Debug.Log("Botón 6 presionado - falla sobrecarga");
                    break;

                case 6:
                    Debug.Log("Botón 7 presionado - alarma");
                    break;

                case 7:
                    Debug.Log("Botón 8 presionado - parada de emergencia");
                   // OnEmergency?.Invoke();
                    OnSimulatorStop?.Invoke();
                    break;
                default:
                    Debug.Log("novale wazaaaaaa");
                    break;
            }
        }
    }
}

