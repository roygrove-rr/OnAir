using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class MalfManager : MonoBehaviour
{
    public TextMeshProUGUI malfunctionUI;

    public Timer timer;
    
    public AudioSource tvAudio;
    public float audioDistortionMin = 0.5f;
    public float audioDistortionMax = 2f;
    public bool audioPitchLow = false;
    
    private float timef = 0f;
    public int secondsPassed = 0;
    private int malfTrigger = 0;
    public int malfNum = 0;

    public bool audioBroken = false;

    public bool isAdPlaying = false;
    
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
            if (audioBroken == false)
            {
                Debug.Log("Audio Malfunction Occured");
                AudioMalfunction();
                audioBroken = true;

                malfNum++;
            }
            else
            {
                Debug.Log("No possible malfunction");
            }
                timef = 0;
        }

        malfunctionUI.text = malfNum.ToString();
    }

    void LightingMalfunction()
    {

    }

    void AudioMalfunction()
    {
        if (tvAudio != null)
        {
            if (Random.value < 0.5)
            {
                tvAudio.pitch = audioDistortionMin;
                audioPitchLow = true;
            }
            else
            {
                tvAudio.pitch = audioDistortionMax;
                audioPitchLow = false;
            }
            audioBroken = true;
        }
    }
}
