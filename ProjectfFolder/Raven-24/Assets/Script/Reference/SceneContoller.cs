using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneContoller : MonoBehaviour
{
    public Image GodRay;
    public Image BG;
    public float aValue;
    // Start is called before the first frame update
    void Start()
    {
        aValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            InvokeRepeating("ShowGodray", 0, 0.1f);
            
        }
    }
    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    void ShowGodray() {
        GodRay.color = new Color(1f,1f,1f,aValue);
        BG.color = new Color(1f, 1f, 1f, aValue);
        if (aValue<1) {
            aValue += 0.05f;
        }
        else {
            StartCoroutine(LoadYourAsyncScene("Room1Sub1"));
        }
    }
}
