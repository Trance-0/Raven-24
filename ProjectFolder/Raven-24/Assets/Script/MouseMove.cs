using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMove: MonoBehaviour
{
    // This script is used to
    // move camera to focused position. object with tag <AccessPoint>
    // interact with other objects

    public bool isActive = true;
    public GameObject mouseMove;
    public PlayerMove playerMove;
    public InventoryManager inventoryManager;
    // transform to restore from moving
    public Transform originalTransform;
    public Transform targetTransform;
    // when focus, stop moving (player move)
    public bool isFocus;
    // when moving, stop everything (mouse and playermove)
    public bool isMoving;
    public int focusSpeed;

    // info grabber
    public Text title;
    public float textShowTimer;
    public float textShowTimeMax;

    // ray cast objects
    Ray mouseRay;
    RaycastHit rayHit;
    // max distance to raycast
    public int distance = 100;
    // Start is called before the first frame update
    void Start()
    {
        originalTransform = mouseMove.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            if (textShowTimer > 0)
            {
                textShowTimer -= Time.deltaTime;
            }
            else
            {
                title.text = "";
            }
            if (isMoving)
            {
                playerMove.transform.position = Vector3.Lerp(playerMove.transform.position, targetTransform.position, Time.deltaTime * focusSpeed);
                mouseMove.transform.LookAt(targetTransform);
                if (playerMove.transform.position.Equals(targetTransform.position))
                {
                    isMoving = false;
                }
            }
            else
            {
                mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out rayHit, distance))
                {
                    //rayHit.transform.gameObject.GetComponent<HighlightEffect>().highlighted = true;

                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject hit = rayHit.transform.gameObject;
                        Debug.Log(string.Format("Mouse raycast on object {0}, with tag {1}", hit.name, hit.tag));

                        if (hit.tag == "AccessPoint")
                        {
                            isFocus = true;
                            isMoving = true;
                            originalTransform = mouseMove.transform;
                            targetTransform = hit.transform;
                            playerMove.isActive = false;
                        }
                        else if (hit.tag == "ItemHandle")
                        {
                            ItemHandle parentHandle = hit.GetComponentInParent<ItemHandle>();
                            inventoryManager.PutItem(parentHandle);
                        }
                        else if (hit.tag == "Item")
                        {
                            ItemHandle parentHandle = hit.GetComponentInParent<ItemHandle>();
                            inventoryManager.AddItem(parentHandle);
                        }
                        else if (hit.tag == "ObjectMove")
                        {
                            hit.GetComponentInParent<ObjectMove>().Move();
                        }
                        else
                        {
                            textShowTimer = textShowTimeMax;
                        }
                    }
                }
            }
            // listener to exit focus mode
            if (Input.GetKey(KeyCode.E))
            {
                isFocus = false;
                transform.position = Vector3.Lerp(transform.position, originalTransform.position, Time.deltaTime * focusSpeed);
                targetTransform = null;
                playerMove.isActive = true;
            }
        }
    }
}
