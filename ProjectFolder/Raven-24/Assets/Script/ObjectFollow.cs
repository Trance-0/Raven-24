using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().transform.position = Vector3.Lerp(GetComponent<Transform>().transform.position, target.transform.position, Time.deltaTime * speed);
    }
}
