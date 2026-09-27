using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float sectionLength = 90f;
    public bool isCountingDown = true;
    public int section = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        isCountingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Increments the timer down every second and updates the section when it reaches 0
        if (isCountingDown == true)
        {
            if (sectionLength > 0)
            {
                sectionLength -= Time.deltaTime;
            }
            else
            {
                sectionLength = 90;
                section++;
            }
        }

        DisplayTime(sectionLength);
    }

    void DisplayTime(float timeToDisplay)
    {
        // Formats the time and section display
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds) + "\nSection " + section;
    }
}
