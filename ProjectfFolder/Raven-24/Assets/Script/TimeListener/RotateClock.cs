using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour
{
    public TimeManager host;
    public List<GameObject> arms;
    public List<float> multipliers;
    public List<Transform> unitRotates;
    // Start is called before the first frame update
    void Start()
    {
        if (arms.Count!=multipliers.Count||arms.Count!=unitRotates.Count) {
            throw new UnityException("Clock parameters count mismatch!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp=Time.deltaTime*host.SynchronizeSpeed();
        for (int i =0;i<arms.Count;i++) {
            temp *= multipliers[i];
            arms[i].transform.Rotate(new Vector3(unitRotates[i].rotation.x*temp,unitRotates[i].rotation.y*temp,unitRotates[i].rotation.z*temp));
        }
    }
}
