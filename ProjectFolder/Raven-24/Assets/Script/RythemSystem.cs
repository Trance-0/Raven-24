using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythemSystem : MonoBehaviour
{
    // music source
    public List<AudioStretch> notes;
    // input methods
    public List<KeyCode> keyNotes;
    public List<GameObject> buttonNotes;
    // self
    public GameObject self;
    // note array
    public GameObject notePF;
    public List<GameObject> noteArray;

    public int mode;
    public float duration;

    private int noteCount;
    // Start is called before the first frame update
    void Start()
    {
        if (notes.Count!=keyNotes.Count|| buttonNotes.Count!=keyNotes.Count) {
            throw new UnityException("Note number mismatch!");
        }
        noteCount = notes.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<keyNotes.Count;i++) {
            if (Input.GetKeyDown(keyNotes[i])==true) {
                CallKey(i);
            }
        }
    }
    public void SetButtonsActivate(bool value) {
        foreach (GameObject i in buttonNotes) {
            i.SetActive(value);
        }
    }
    public void CallKey(int index) {
        notes[index].GetComponent<AudioStretch>().Play(duration);
    }
}
