using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterLevel : MonoBehaviour
{
    [SerializeField] private Material _waterShader;
    float _level;
    // Start is called before the first frame update
    void Start()
    {
       // _waterShader.SetFloat("_WaterLevel", _level);
       _level = _waterShader.GetFloat("_fiil");
    }
    void FillUpWater()
    {
        _level += Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        FillUpWater();
        _waterShader.SetFloat("_fiil", _level);
        Debug.Log(_level);
    }
}
