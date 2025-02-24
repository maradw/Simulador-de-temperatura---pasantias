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
                Debug.Log("Bot�n 1 presionado - energizado");
                break;
            case 1:
                Debug.Log("Bot�n 2 presionado - off/on \n prender el faro ese XD");
                OnSimulatorOnOff?.Invoke();
                break;

            case 2:
                Debug.Log("Bot�n 3 presionado - manual/oof/automatic");
                break;

            case 3:
                Debug.Log("Bot�n 4 presionado - quemador");
                OnButtonFirePressed?.Invoke();
                break;

            case 4:
                Debug.Log("Bot�n 5 presionado - bomba agua");
                break;

            case 5:
                Debug.Log("Bot�n 6 presionado - falla sobrecarga");
                break;

            case 6:
                Debug.Log("Bot�n 7 presionado - alarma");
                break;

            case 7:
                Debug.Log("Bot�n 8 presionado - parada de emergencia");
                OnEmergency?.Invoke();
                break;
            default:
                Debug.Log("novale wazaaaaaa");
                break;
        }
    }
}

