using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStretch : MonoBehaviour
{
    // Start is called before the first frame update
    public TimeManager host;
    public bool haveAnimation;
    public Animator animationOnPlay;
    public AudioSource sound;

    public float realPlayTime;
    public float timer;
    public bool isActive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sound!=null) {
            if (timer <= 0)
            {
                sound.Pause();
            }
            else {
                timer -= Time.deltaTime * Math.Abs(host.SynchronizeSpeed());
                if (haveAnimation)
                {
                    animationOnPlay.SetFloat("multiplier", host.SynchronizeSpeed());
                }
                sound.pitch = host.SynchronizeSpeed();
            }
        }
    }
    public void Play(float duration) {
        if (isActive)
        {
            realPlayTime = duration;
            timer = realPlayTime;
            sound.loop = true;
            sound.time = sound.clip.length - 0.01f;
         
            // normal update
            if (haveAnimation)
            {
                animationOnPlay.SetFloat("multiplier", host.SynchronizeSpeed());
            }
            sound.pitch = host.SynchronizeSpeed();

            sound.Play();
        }
    }
}
