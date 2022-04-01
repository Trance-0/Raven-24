using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    // this script should put on an empty object, when init, the code would generate key and lock together if item is assigned
    // this item is used to genenrate key and lock together.
    public Item item;
    public string key;
    // transparent material for item handel
    public Material NullMaterial;
    // these object are only used for reference
    public GameObject keyshape=null;
    public GameObject lockshape=null;
    public bool instantiateOnStart = false;
    // set lock and key with same mesh.
    void Start() {
        if (instantiateOnStart) {
            ResetItem(item);
        }
    }
    void Update() {
    }
    public void ClearItem() {
        item = null;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void ResetItem(Item sourceItem) {
        ClearItem();
        key = sourceItem._key;
        PutItem(sourceItem);
    }
    public bool PutItem(Item sourceItem) {
        // if the key is valid and no other object is placed.
        if (key.Contains(sourceItem._key)&&item==null) {
            // if there is no lock
            if (lockshape == null)
            {
                ClearItem();
                item = sourceItem;
                keyshape = Instantiate(item._mesh, transform);
                keyshape.tag = "Item";
            }
            else {
                ClearItem();
                item = sourceItem;
                keyshape = Instantiate(item._mesh, transform);
                keyshape.tag = "Item";
                keyshape.transform.position=lockshape.transform.position;
                keyshape.transform.rotation=lockshape.transform.rotation;
                keyshape.transform.localScale=lockshape.transform.localScale;
            }
            return true;
        }
        return false;
    }
    public Item PickItem() {
        Item result = item.DeepCopy();
        ClearItem();
        lockshape = Instantiate(result._mesh, transform);
        lockshape.tag = "ItemHandle";
        // set texture of lock to null material;
        MeshRenderer lockRenderer = lockshape.GetComponent<MeshRenderer>();
        for (int i = 0; i < lockRenderer.materials.Length; i++)
        {
            lockRenderer.materials[i] = NullMaterial;
        }
        lockshape.transform.position = keyshape.transform.position;
        lockshape.transform.rotation = keyshape.transform.rotation;
        lockshape.transform.localScale = keyshape.transform.localScale;
        lockshape.GetComponent<Rigidbody>().isKinematic = true;
        //lockshape.GetComponent<BoxCollider>().isTrigger = true;
        return result;
    }
}
