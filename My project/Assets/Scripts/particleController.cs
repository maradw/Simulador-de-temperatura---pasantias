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
    }
    void OnDisable()
    {
        ControlPanel.OnButtonFirePressed -= StartFire;
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
        _fireParticle.Play(false);
    }
}
