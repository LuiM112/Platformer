using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float accumulatedTime = 0f;
    public int totalTime = 300;
    public GameObject timeText;

    private const int TimeStops = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timeText.GetComponent<TextMeshProUGUI>().text = totalTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;

        if (accumulatedTime > 1f)
        {
            totalTime -= 1;
            accumulatedTime = 0f;
            timeText.GetComponent<TextMeshProUGUI>().text = totalTime.ToString();
            Debug.Log($"Time is {totalTime}");
        }

        else if (totalTime == TimeStops)
        {
            ResetTime();
            timeText.GetComponent<TextMeshProUGUI>().text = totalTime.ToString();
        }
    }

    private void ResetTime()
    {
        totalTime = 300;
    }
}
