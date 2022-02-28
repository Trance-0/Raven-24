using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerTransform;
    public Camera cameraMain;
    public float jumpStrength = 10f;
    public float waterFriction = 0.5f;
    public int startAngle = 180;
    public int rotateSpeed = 40;
    public int moveSpeed = 10;
    private float horizontalAngle;
    private float verticalAngle;
    private bool onGround = true;
    public bool grounded;
    public int cdMax;
    public int cd;
    public int waterLevel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform.GetComponent<Transform>().position.y <= waterLevel)
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }
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
        playerTransform.transform.position += Input.GetAxis("Horizontal") * moveSpeed * transform.right * Time.deltaTime;
        playerTransform.transform.position += Input.GetAxis("Vertical") * moveSpeed * transform.forward * Time.deltaTime;
        playerTransform.transform.rotation = Quaternion.Euler(0, horizontalAngle + startAngle, 0);

        //if (isStart) {
        //playerTransform.transform.Rotate(0f, 1f, 0f);
        //    isStart = false;
        //}
        if (cd >= 0)
        {
            cd--;
        }
        else
        {

            if (onGround)
            {
                if (Input.GetKey(KeyCode.Space) && grounded)
                {
                    playerTransform.GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * jumpStrength);
                    grounded = false;
                    cd = cdMax;
                }
            }
            else
            {
                playerTransform.GetComponent<Rigidbody>().AddForce(Vector3.up * 100 * jumpStrength * waterFriction);
            }
        }
    }
    private void LateUpdate()
    {
        cameraMain.transform.rotation = Quaternion.Euler(-verticalAngle, horizontalAngle + startAngle, 0);

    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colided");
        grounded = true;
    }
}
