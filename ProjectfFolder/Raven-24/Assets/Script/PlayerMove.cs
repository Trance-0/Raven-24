using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove: MonoBehaviour
{
    public bool freeze;
    // REMEMBER TO SET COLIDER WITH THE OBJECT WHERE SCRIPT IS IN!
    // DO NOT USE CAPSULE COLLIDER, USE BOX COLLIDER INSTEAD!
    public GameObject playerTransform;
    public Camera cameraMain;

    // For setting canvas, no default value settled, as long as you don't call the function, everything would work pretty fine.
    public Slider movingSpeedBar;
    public Text movingSpeedValueText;
    public Slider rotateSpeedBar;
    public Text rotateSpeedValueText;

    public float jumpStrength = 10f;
    public float waterFriction = 0.5f;
    public int startAngle = 180;
    public int rotateSpeed = 40;
    public int moveSpeed = 10;
    private float horizontalAngle;
    private float verticalAngle;
    // check if the player is in water or on ground
    public bool onGround;
    // check if the player is in the sky
    public bool grounded;
    // to avoid double jump
    public int cdMax;
    public int cd;
    // default water level
    public int waterLevel;

    // Start is called before the first frame update
    void Start()  
    {
        freeze = false;
        //lock the cursor to screen center and set it to invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!freeze) { }
        // exit on play
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            // move camera with cursor
            horizontalAngle += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            verticalAngle += Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
            if (verticalAngle > 80)
            {
                verticalAngle = 80;
            }
            else if (verticalAngle < -60)
            {
                verticalAngle = -60;
            }
        }


        // if the player is underwater
        if (playerTransform.GetComponent<Transform>().position.y <= waterLevel)
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }

        // move player with arrow keys
        //Debug.Log(string.Format("testing input: dx={0}, dy={1}", Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        playerTransform.transform.position += Input.GetAxis("Horizontal") * moveSpeed * transform.right * Time.deltaTime;
        playerTransform.transform.position += Input.GetAxis("Vertical") * moveSpeed * transform.forward * Time.deltaTime;
        playerTransform.transform.rotation = Quaternion.Euler(0, horizontalAngle + startAngle, 0);

        if (Input.GetKey(KeyCode.LeftShift)) {
            playerTransform.GetComponent<Rigidbody>().AddForce(Vector3.down*10);
        }

        // jumping counter
        if (cd >= 0)
        {
            cd--;
        }
        // if cd is cooled
        else
        {
            // if player wants to jump
            if (Input.GetKey(KeyCode.Space))
            {
                // jump on ground
                if (onGround && grounded)
                {
                    playerTransform.GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * jumpStrength);
                    cd = cdMax;
                }
                // jump in water
                if (!onGround)
                {
                    playerTransform.GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * jumpStrength * waterFriction);
                }
            }
        }
    }
    // rotate camera with some delay
    private void LateUpdate()
    {
        cameraMain.transform.rotation = Quaternion.Euler(-verticalAngle, horizontalAngle+startAngle, 0);
      
    }

    public void ChangeMovingSpeed() {
        moveSpeed =(int)movingSpeedBar.value;
        movingSpeedValueText.text = movingSpeedBar.value.ToString();
    }
    public void ChangeRotateSpeed()
    {
        rotateSpeed = (int)rotateSpeedBar.value;
        rotateSpeedValueText.text = rotateSpeedBar.value.ToString();
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("player is on ground");
        grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("player is flying");
        grounded = false;
    }
}
