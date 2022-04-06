using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DebugWindow : MonoBehaviour
{
    // Adjust via the Inspector
    public int maxLines = 8;
    private Queue<string> queue = new Queue<string>();
    public GameObject output;
    public bool isActive;

    void OnEnable()
    {
        Application.logMessageReceivedThreaded += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceivedThreaded -= HandleLog;
    }
    public void SetActive() {
        isActive = !isActive;
        output.SetActive(isActive);
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (isActive)
        {
            // Delete oldest message
            if (queue.Count >= maxLines) queue.Dequeue();

            queue.Enqueue(logString);

            var builder = new StringBuilder();
            foreach (string st in queue)
            {
                builder.Append(st).Append("\n");
            }
            output.GetComponent<Text>().text = builder.ToString();
        }
    }
   
}
