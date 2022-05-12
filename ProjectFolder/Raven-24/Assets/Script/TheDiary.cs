using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    // this scirpt is used to load datas and save progress.
    // Start is called before the first frame update
    public int progress;
    public Dictionary<string,Sprite> imageReference;
    // Store the state of pages, plots
    public List<Item> pages;
    public List<bool> pageState;
    public List<int> newPages;
    // UI elements
    public GameObject frontPage;
    public GameObject backPage;
    public List<GameObject> bookMarks;

    public KeyCode hostKey;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool OpenDiary() {
        return true;
    }
}
