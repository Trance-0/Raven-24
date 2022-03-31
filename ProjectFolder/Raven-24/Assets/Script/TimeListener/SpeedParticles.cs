using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticles : MonoBehaviour
{
    // this script is used to change particle effect speed of the system with unitSpeed
    public TimeManager host;
    // Start is called before the first frame update
    private float speedModifierOri;
    private float rateOverTimeOri;
    private float startLifeTimeOri;
    void Start()
    {
        ParticleSystem.VelocityOverLifetimeModule targetSpeed = GetComponent<ParticleSystem>().velocityOverLifetime;
        speedModifierOri=targetSpeed.speedModifier.constant;
        ParticleSystem.EmissionModule targetEmission = GetComponent<ParticleSystem>().emission;
        rateOverTimeOri=targetEmission.rateOverTimeMultiplier;
        ParticleSystem.MainModule targetMain = GetComponent<ParticleSystem>().main;
        startLifeTimeOri=targetMain.startLifetimeMultiplier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ParticleSystem.VelocityOverLifetimeModule targetSpeed = GetComponent<ParticleSystem>().velocityOverLifetime;
        targetSpeed.speedModifier = host.SynchronizeSpeed()*speedModifierOri;
        ParticleSystem.EmissionModule targetEmission = GetComponent<ParticleSystem>().emission;
        targetEmission.rateOverTimeMultiplier= host.SynchronizeSpeed()*rateOverTimeOri;
        ParticleSystem.MainModule targetMain= GetComponent<ParticleSystem>().main;
        targetMain.startLifetimeMultiplier = (1/host.SynchronizeSpeed())*startLifeTimeOri;
    }
}
