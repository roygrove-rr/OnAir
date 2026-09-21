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

    public GameObject stage;
    public GameObject eyes;
    
    private float timef = 0f;
    public int secondsPassed = 0;
    private int malfTrigger = 0;
    public int malfNum = 0;
    public float malfRandom = 0f;

    public bool audioBroken = false;
    public bool lightsBroken = false;

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
                malfTrigger = 10;
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
            var malfTriggered = 0;
            malfRandom = Random.value;
            
            while (malfTriggered < 1)
                if (malfRandom <= 0.5)
                {
                    if (audioBroken == false)
                    {
                        Debug.Log("Audio Malfunction Occured");
                        AudioMalfunction();

                        malfNum++;

                        malfTriggered++;
                    }
                    else
                    {
                        Debug.Log("There is already a malfunction of this type");
                    }
                }
                else if (malfRandom > 0.5)
                {
                    if (lightsBroken == false)
                    {
                        Debug.Log("Lighting Malfunction Occured");
                        LightingMalfunction();

                        malfNum++;

                        malfTriggered++;
                    }
                    else
                    {
                        Debug.Log("There is already a malfunction of this type");
                    }
                }
                else
                {
                    malfRandom = Random.Range(0, 2);
                }

                timef = 0;
        }

        malfunctionUI.text = malfNum.ToString();
    }

    void LightingMalfunction()
    {
        stage.SetActive(false);
        eyes.SetActive(true);

        lightsBroken = true;
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
