using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 90f;
    public bool isCountingDown = false;
    public int section = 1;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Increments the timer down every second and updates the section when it reaches 0
        if (isCountingDown == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 90;
                section++;
            }
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        // Formats the time and section display
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds) + "\nSection " + section;
    }
}
