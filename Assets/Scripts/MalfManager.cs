using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class MalfManager : MonoBehaviour
{
    public Timer timer;
    
    public AudioSource tvAudio;
    public float wobbleSpeed = 5f;
    public float wobbleIntensity = 1f;
    
    private float timef = 0f;
    public int secondsPassed = 0;
    private int malfTrigger = 0;
    private int malfNum = 0;

    public bool audioBroken = false;
    
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
            Debug.Log("Audio Malfunction Occured");
            if (audioBroken == false)
            {
                audioBroken = true;
            }
            timef = 0;
        }

        while (audioBroken == true)
        {
            AudioMalfunction();
        }
    }

    void LightingMalfunction()
    {

    }

    void AudioMalfunction()
    {
        if (tvAudio != null)
        {
            float sineWobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleIntensity;
            tvAudio.pitch = 1.0f + sineWobble;
        }
    }
}
