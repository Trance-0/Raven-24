using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove: MonoBehaviour
{
    // This script is used to
    // move camera to focused position. object with tag <AccessPoint>
    // interact with other objects
  
    public GameObject mouseMove;
    public PlayerMove playerMove;
    // transform to restore from moving
    public Transform originalTransform;
    public Transform targetTransform;
    // when focus, stop moving (player move)
    public bool isFocus;
    // when moving, stop everything (mouse and playermove)
    public bool isMoving;
    public int focusSpeed;

    // ray cast objects
    Ray mouseRay;
    RaycastHit rayHit;
    // max distance to raycast
    public int distance = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            playerMove.transform.position = Vector3.Lerp(playerMove.transform.position, targetTransform.position, Time.deltaTime*focusSpeed);
            mouseMove.transform.LookAt(targetTransform);
            if (playerMove.transform.position.Equals(targetTransform.position))
            {
                isMoving = false;
            }
        }
        else {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out rayHit, distance))
            {
                //rayHit.transform.gameObject.GetComponent<HighlightEffect>().highlighted = true;

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject hit = rayHit.transform.gameObject;
                    string name = hit.name;
                    Debug.Log(string.Format("Mouse raycast on object {0}", name));

                    if (hit.tag == "AccessPoint") {
                        isFocus = true;
                        originalTransform = mouseMove.transform;
                        targetTransform = hit.transform;
                        playerMove.freeze = true;
                    }

                }
            }
            // listener to exit focus mode
            if (Input.GetKey(KeyCode.E)) {
                isFocus = false;
                transform.position = Vector3.Lerp(transform.position, originalTransform.position, Time.deltaTime * focusSpeed);
                targetTransform = null;
                playerMove.freeze = false;
            }
        }
    }

}
