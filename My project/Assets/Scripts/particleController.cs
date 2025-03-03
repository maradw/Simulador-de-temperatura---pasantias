using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class particleController : MonoBehaviour
{

    [SerializeField] ParticleSystem _fireParticle;
    void Start()
    {
        
    }
    void OnEnable()
    {
        ControlPanel.OnButtonFirePressed += StartFire;
        ControlPanel.OnSimulatorStop += StopFire;
    }
    void OnDisable()
    {
        ControlPanel.OnButtonFirePressed -= StartFire;
        ControlPanel.OnSimulatorStop -= StopFire;
    }

    void Update()
    {
        
    }
    void StartFire()
    {
        _fireParticle.Play(true);
    }
    void StopFire()
    {
        //este sera otro evnto
        _fireParticle.Stop(true);
    }
}
