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

    float _minLevel = -4f;
    float _maxLevel = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
       // _waterShader.SetFloat("_WaterLevel", _level);
      // _level = _waterShader.GetFloat("_fiil"); esto guarda automaticamnete el valor de fill en la sesion anteroir un scriptableobj gratis wazaaaaa
    }
    void FillUpWater()
    {
        _level += Time.deltaTime * _fillSpeed;
        _waterShader.SetFloat("_fiil", _level);
        // Debug.Log(_level);
        if (_level <= _minLevel)
        {
            // Debug.Log("se esta secando causa");
        }
        else if (_level >= _maxLevel)
        {
            //Debug.Log("mucha awa causa");
        }
        _waterLevel.text = "water level: " + _level;
    }
    void UnfillWater()
    {
        //activarcuando el agua esta demasiado llena
        _level -= Time.deltaTime * _fillSpeed;
        //Debug.Log("waza, se va el agua" + _level);
    }
    void Update()
    {
        //FillUpWater();
        UnfillWater();
    }
    void OnEnable()
    {
        ControlPanel.OnSimulatorOn += FillUpWater;
    }
    void OnDisable()
    {
        ControlPanel.OnSimulatorOn -= FillUpWater;

    }
}
