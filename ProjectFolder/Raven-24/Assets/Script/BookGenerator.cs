using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{
    public GameObject self;
    // this script is used to generate books on bookshelf with random thickness.
    public List<Item> source;
    public GameObject itemHandlePF;
    // in this context, width means thickness.
    public List<Transform> anchors;
    // we set x as default direction.
    public List<float> shelfLength;
    // Start is called before the first frame update
    public List<GameObject> generatedBooks;
    // this is used for y axis
    public float transformRandomizerMax;
    public float transformRandomizerMin;
    // random scale by
    public float scaleRandomizerMax;
    public float scaleRandomizerMin;
    void Start()
    {
        if (anchors.Count!=shelfLength.Count) {
            throw new UnityException("BookGenerator parameters mismatch!");
        }
        GenerateBooks();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public string IndexGenerator(int length) {
        string chars= "0123456789abcdef";
        string result = "";
        for (int i =0;i<length;i++) {
            result += chars[Random.Range(0,16)];
        }
        return result;
    }

    public void GenerateBooks() {
        foreach (GameObject i in generatedBooks) {
            GameObject.Destroy(i);
        }
        for (int i=0;i<anchors.Count;i++) {
            Transform currentPos = anchors[i];
            float currentBookCount = 0f;
            while (currentBookCount<shelfLength[i]) {
                Item grabBook = source[Random.Range(0, source.Count)].DeepCopy();
                if (grabBook._weight<=0) {
                    throw new UnityException("weight of book is non positive value!");
                }
                Debug.Log(string.Format("Genenrating book {0}",grabBook.ToString()));

                // instantiate
                // instantiate object mesh
   // assign item value
                
                // Randomizer to randomize item!
                float transformRandomizer = Random.Range(transformRandomizerMin,transformRandomizerMax);
                float scaleRandomizerZ = Random.Range(scaleRandomizerMin, scaleRandomizerMax);
                float scaleRandomizerY = Random.Range(scaleRandomizerMin, scaleRandomizerMax);
                float scaleRandomizerX = Random.Range(scaleRandomizerMin, scaleRandomizerMax);
               // modify book data
                grabBook._weight *= scaleRandomizerY;
                grabBook._title = "Book of Unknown";
                grabBook._key = IndexGenerator(16);

                // modify item handle
                GameObject newItemHandle = Instantiate(itemHandlePF, self.transform);
                newItemHandle.transform.position = anchors[i].position;
                newItemHandle.transform.rotation = anchors[i].rotation;
                // reset item in handle
                newItemHandle.GetComponent<ItemHandle>().item=grabBook;
                newItemHandle.GetComponent<ItemHandle>().key = grabBook._key;
                foreach (Transform child in newItemHandle.transform) {
                    Destroy(child.gameObject);
                }

                // modify mesh of book
                GameObject newBook = Instantiate(grabBook._mesh,newItemHandle.transform);
                newItemHandle.GetComponent<ItemHandle>().keyshape = newBook;
                newBook.transform.localPosition =Vector3.zero;
               newBook.transform.localScale = new Vector3(scaleRandomizerX, scaleRandomizerY, scaleRandomizerZ);
                newBook.GetComponent<Rigidbody>().isKinematic = true;
                Material targetMaterial = newBook.GetComponent<MeshRenderer>().material;
                targetMaterial.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 0.5f);
                grabBook._mesh = newBook;

                // allocate newbook to current pos
                newItemHandle.transform.position = currentPos.position;
                newItemHandle.transform.Translate(new Vector3(transformRandomizer, 0, 0));

                // locate the data
                currentBookCount += grabBook._weight;
                generatedBooks.Add(newItemHandle);
                currentPos.Translate(new Vector3(grabBook._weight,0, 0));
            }
        }
        Invoke("FreeBooks",1f);
    }
    private void FreeBooks() {
        foreach (GameObject i in generatedBooks)
        {
            i.GetComponent<ItemHandle>().keyshape.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
