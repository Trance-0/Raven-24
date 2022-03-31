using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistObject : MonoBehaviour
{
    // this script is used to change shape of objects based on time
    public TimeManager host;
    public List<GameObject> formOnSequence;
    public List<float> checkpoints;
    // Start is called before the first frame update
    void Start()
    {
        if (formOnSequence.Count!=checkpoints.Count)
        {
            throw new UnityException("Clock parameters count mismatch!");
        }
        reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentTime = host.SynchronizeTime();
        int index = -1;
        for (int i= checkpoints.Count-1; i>=0;i--) {
            if (checkpoints[i]<currentTime) {
                index = i;
                break;
            }
        }
        reset();
        if (index >= 0){
            formOnSequence[index].SetActive(true);
        }
    }
    private void reset() {
        foreach (GameObject i in formOnSequence)
        {
            i.SetActive(false);
        }
    }
}
