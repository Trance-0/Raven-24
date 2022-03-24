using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public bool trap;
    public float x;
    public float z;
    public int blocklength;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trap)
        {
            if (player.transform.position.x > x + blocklength / 2)
            {
                player.transform.position = new Vector3(player.transform.position.x - blocklength, player.transform.position.y - 0.2f, player.transform.position.z);
                print("You cannot escape");
            }

            if (player.transform.position.x < x - blocklength / 2)
            {
                player.transform.position = new Vector3(player.transform.position.x + blocklength, player.transform.position.y - 0.2f, player.transform.position.z);
                print("You cannot escape");
            }
            if (player.transform.position.z > z + blocklength / 2)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.2f, player.transform.position.z - blocklength);
                print("You cannot escape");
            }
            if (player.transform.position.z < z - blocklength / 2)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.2f, player.transform.position.z + blocklength);
                print("You cannot escape");

            }
        }
    }
}

