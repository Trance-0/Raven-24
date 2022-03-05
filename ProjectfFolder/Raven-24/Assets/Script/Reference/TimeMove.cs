using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMove : MonoBehaviour
{
    public GameObject cube;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material temp = cube.GetComponent<MeshRenderer>().material;
        Color rgbC, hsvC;
        float H, S, V;
        rgbC = temp.color;
        Color.RGBToHSV(rgbC, out H, out S, out V);
        //Debug.Log("H: " + H + " S: " + S + " V: " + V);
        if (Input.GetKey(KeyCode.J))
        {
            V +=  Time.deltaTime*speed;
            hsvC = Color.HSVToRGB(H, S, V);
            temp.color = hsvC;
        }
        if (Input.GetKey(KeyCode.K))
        {
            V -= Time.deltaTime * speed;
            hsvC = Color.HSVToRGB(H, S, V);
            //temp.color = hsvC;
            temp.SetVector("_Color", hsvC);
        }
    }
}
