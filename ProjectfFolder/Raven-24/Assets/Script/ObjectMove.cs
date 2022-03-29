using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // To move object using Animator
    public Animator target = null;
    public List<string> stateNames;
    public int currentState;
    // true for Active
    public bool isActive;
    void Start()
    {
        currentState = 0;
    }

    public void Move() {
        if (isActive) {
            target.Play(stateNames[currentState], 0,0f);
            currentState = (currentState+1)%stateNames.Count;
        }
    }
}
