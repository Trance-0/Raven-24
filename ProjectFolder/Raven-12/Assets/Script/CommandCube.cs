using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCube: MonoBehaviour
{
    public GameObject cube;
    public int jumpStrength;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material temp = cube.GetComponent<MeshRenderer>().material;
        if (Input.GetKey(KeyCode.K)&&grounded)
        {
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
