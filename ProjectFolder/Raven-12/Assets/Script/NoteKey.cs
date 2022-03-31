using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject defaultState;
    
    public GameObject activeState;
    public AudioSource sound;

    public int state;

    public int timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            activeState.SetActive(false);
            sound.Pause();
        }
        else {
            timer--;
        }
    }
    public void Play(int duration) {
        timer = duration;
        sound.Play(0);
        activeState.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        state = 1;
    }
    private void OnCollisionExit(Collision collision)
    {
        state = 0;
    }
}
