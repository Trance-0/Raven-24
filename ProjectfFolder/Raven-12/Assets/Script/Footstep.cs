using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioSource footStepSound;
    public List<AudioClip> stepOnGrass;
    public List<AudioClip> stepOnSand;
    public List<AudioClip> stepOnGrassBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") != 0)&&!footStepSound.isPlaying) {
            AudioClip tempclip = stepOnGrass[(int)Random.Range(0,stepOnGrass.Count)];
            footStepSound.clip = tempclip;
            footStepSound.Play();
        }
        if (Input.GetAxis("Vertical") <0  && !footStepSound.isPlaying)
        {
            AudioClip tempclip = stepOnGrassBack[(int)Random.Range(0, stepOnGrass.Count)];
            footStepSound.clip = tempclip;
            footStepSound.Play();
        }
    }
}
