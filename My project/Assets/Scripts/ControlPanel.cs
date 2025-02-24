using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public static event Action OnButtonFirePressed;
    public static event Action OnSimulatorOnOff;

    public static event Action OnEmergency;


    [SerializeField] private GameObject[] _controlButton; 
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;  
        Debug.Log("olacausa");
    }

    void Update()
    {
        DetectButtonPress();
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
                OnSimulatorOnOff?.Invoke();
                break;

            case 2:
                Debug.Log("Botón 3 presionado - manual/oof/automatic");
                break;

            case 3:
                Debug.Log("Botón 4 presionado - quemador");
                OnButtonFirePressed?.Invoke();
                break;

            case 4:
                Debug.Log("Botón 5 presionado - bomba agua");
                break;

            case 5:
                Debug.Log("Botón 6 presionado - falla sobrecarga");
                break;

            case 6:
                Debug.Log("Botón 7 presionado - alarma");
                break;

            case 7:
                Debug.Log("Botón 8 presionado - parada de emergencia");
                OnEmergency?.Invoke();
                break;
            default:
                Debug.Log("novale wazaaaaaa");
                break;
        }
    }
}

