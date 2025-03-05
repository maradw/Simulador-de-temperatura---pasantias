using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

public class particleController : MonoBehaviour
{

    [SerializeField] ParticleSystem _fireParticle;
    void Start()
    {
        
    }
    void OnEnable()
    {
        ControlPanel.OnFireOn += StartFire;
        ControlPanel.OnSimulatorStop += StopFire;
    }
    void OnDisable()
    {
        ControlPanel.OnFireOn -= StartFire;
        ControlPanel.OnSimulatorStop -= StopFire;
    }

    void Update()
    {
        
    }
    void StartFire()
    {
        _fireParticle.Play(true);
    }
    public void StopFire()
    {
        //este sera otro evnto
        _fireParticle.Stop(true);
    }
}
