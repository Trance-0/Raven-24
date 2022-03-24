using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGenerator : MonoBehaviour
{
    // this script is used to generate books on bookshelf with random thickness.
    public List<Item> source;
    // in this context, width means thickness.
    public List<Transform> anchors;
    // we set y as default direction.
    public List<float> shelfLength;
    // Start is called before the first frame update
    void Start()
    {
        if (source.Count!=anchors.Count||source.Count!=shelfLength.Count) {
            throw new UnityException("BookGenerator parameters mismatch!");
        }
        GenerateBooks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateBooks() {
        for (int i=0;i<anchors.Count;i++) {
            Transform currentPos = anchors[i];
            Item nextBook= source[Random.Range(0,anchors.Count)];
            currentPos.Translate(new Vector3(0,nextBook._weight,0));
            while () {
            }
            }
        }
    }
}
