using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudCheck : MonoBehaviour
{
    public GameObject FirstPersonMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("adsfadsf");
        FirstPersonMove.GetComponent<FirstPersonMove>().grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("adsfadsf");
        FirstPersonMove.GetComponent<FirstPersonMove>().grounded = false;
    }
}
