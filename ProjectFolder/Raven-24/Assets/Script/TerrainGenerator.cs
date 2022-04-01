using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // prefab setting
    public GameObject cubePF;
    public int x_scale;
    public int z_scale;

    // self
    public GameObject terrainGenerator;

    // range of generation
    public int x_start;
    public int x_end;
    public int z_start;
    public int z_end;
    public int y_start;
    public int y_base;
    public int y_end;
    // propensity to generate based on resolution
    public int threshold;
    public int resolution = 100;

    // Start is called before the first frame update
    void Start()
    {
        if (x_scale<=0 || z_scale<=0) {
            throw new Exception("scale of cube is illegal.");
        }
        int cubeCount = 0;
        for (int i=x_start;i<x_end;i+=x_scale) {
            for (int j = z_start; j < z_end; j += z_scale){
                float proposal = UnityEngine.Random.Range(0, resolution);
                if (proposal > threshold) {
                    //Debug.Log(string.Format("Creating cube {0}, with pos {1},{2}...", cubeCount, i, j));
                    int y_scale=Math.Abs( UnityEngine.Random.Range(10,(y_base- y_end)));
                    GameObject newCube = Instantiate(cubePF, new Vector3(i,y_start+y_scale/2, j), Quaternion.identity, terrainGenerator.transform);
                    Material temp = newCube.GetComponent<MeshRenderer>().material;
                    Color rgbC, hsvC;
                    float H, S, V;
                    rgbC = temp.color;
                    Color.RGBToHSV(rgbC, out H, out S, out V);
                    V=UnityEngine.Random.Range(0.5f,1.0f);
                    hsvC = Color.HSVToRGB(H, S, V);
                    temp.color = hsvC;
                    newCube.transform.localScale += new Vector3(x_scale-1, y_scale-1, z_scale-1);
                    cubeCount++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
