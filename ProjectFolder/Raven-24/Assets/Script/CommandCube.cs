using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCube: MonoBehaviour
{
    public GameObject cube;
    public int jumpStrength;
    public List<KeyCode> activateList;
    private bool grounded;
    private bool activate=false;
    // Start is called before the first frame update
    void Start()
    {
        activate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        activate = true;
        foreach (KeyCode i in activateList)
        {
            if (Input.GetKey(i) == false)
            {
                activate = false;
                break;
            }
        }
        Material temp = cube.GetComponent<MeshRenderer>().material;
        if (activate && grounded) { 
            temp.color = UnityEngine.Random.ColorHSV();
            cube.GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * jumpStrength);
            grounded = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("player is on ground");
        grounded = true;
    }
}
