using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public float time;
    public float timeSpeed=1f;
    public float maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime * timeSpeed;
        timeText.text = time.ToString("0.");
        // for m, n key to change speed
        if (Input.GetKeyDown(KeyCode.M)) {
            changeSpeed(1);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            changeSpeed(-1);
        }
        Physics.gravity = new Vector3(0f,-Mathf.Abs(timeSpeed)*9.8f,0f) ;
    }
    public void changeSpeed(float delta) {
        if (Mathf.Abs(timeSpeed + delta) < maxSpeed)
        {
            timeSpeed += delta;
        }
        else {
            throw new UnityException("Time overflow!");
        }
    }
    // call time
    public float SynchronizeTime() {
        return time;
    }
    public float SynchronizeSpeed() {
        return timeSpeed;
    }
}
