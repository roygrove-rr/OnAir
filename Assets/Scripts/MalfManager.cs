using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalfManager : MonoBehaviour
{
    public Timer timer;
    private float timef = 0f;
    public int secondsPassed = 0;
    private int malfTrigger = 0;
    private int malfNum = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timef += Time.deltaTime;
        secondsPassed = Mathf.FloorToInt(timef);

        switch (timer.section)
        {
            case 1:
                malfTrigger = 10;
                break;

            case 2:
                malfTrigger = 5;
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            default:
                break;

        }

        if (secondsPassed == malfTrigger)
        {
            Debug.Log("Malfunction Occured");
            timef = 0;
        }
    }
}
