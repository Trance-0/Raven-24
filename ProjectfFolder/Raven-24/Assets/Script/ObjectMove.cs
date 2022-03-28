using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // To move object with unit of move
    public Transform unitTransform;
    public float transformMultiplierMax;
    public float transformMultiplierMin;
    // true for moving
    public bool state;
    public float currentMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        currentMultiplier = transformMultiplierMin;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state) {
            currentMultiplier += Time.deltaTime;
            if (currentMultiplier>transformMultiplierMax) {
                state = false;
                currentMultiplier = transformMultiplierMin;
            }
            GetComponent<Transform>().transform.Translate(new Vector3(unitTransform.position.x * currentMultiplier, unitTransform.position.y * currentMultiplier, unitTransform.position.z * currentMultiplier));
            GetComponent<Transform>().transform.Rotate(new Vector3(unitTransform.rotation.x * currentMultiplier, unitTransform.rotation.y * currentMultiplier, unitTransform.rotation.z * currentMultiplier));
            transform.localScale = new Vector3(unitTransform.localScale.x * currentMultiplier, unitTransform.localScale.y * currentMultiplier, unitTransform.localScale.z * currentMultiplier);
        }
    }
    public void Move() {
        state =true;
    }
}
