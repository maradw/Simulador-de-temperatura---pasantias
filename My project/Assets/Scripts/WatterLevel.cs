using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterLevel : MonoBehaviour
{
    Material _waterShader;
    float _level;
    // Start is called before the first frame update
    void Start()
    {
        _waterShader.SetFloat("_WaterLevel", _level);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
