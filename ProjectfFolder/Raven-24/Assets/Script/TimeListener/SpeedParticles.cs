using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticles : MonoBehaviour
{
    // this script is used to change particle effect speed of the system with unitSpeed
    public TimeManager host;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ParticleSystem.VelocityOverLifetimeModule target = GetComponent<ParticleSystem>().velocityOverLifetime;
        target.speedModifier = host.SynchronizeSpeed();
    }
}
