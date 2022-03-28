using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    public Item item;
    public string key;
    // transparent material for item handel
    public Material NullMaterial;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool PutItem(Item sourceItem) {
        if (key.Contains(sourceItem._key)&&item==null) {
            item = sourceItem;
            GameObject itemMesh = Instantiate(item._mesh,transform);
            Mesh selfMesh = GetComponent<Mesh>();
            selfMesh= itemMesh.GetComponent<Mesh>();
            MeshRenderer selfMeshRenderer = GetComponent<MeshRenderer>();
            for (int i=0;i< selfMeshRenderer.materials.Length;i++) {
                selfMeshRenderer.materials[i] = NullMaterial;
            }
            selfMeshRenderer = itemMesh.GetComponent<MeshRenderer>();

            return true;
        }
        return false;
    }
    public Item PickItem() {
        Item result = item.DeepCopy();
        item = null;
        Destroy(GetComponent<Transform>().GetChild(0).gameObject);
        return result;
    }
}
