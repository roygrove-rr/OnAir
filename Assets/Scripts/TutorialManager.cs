using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public MalfManager malfManager;
    public GameManager gameManager;
    public TextMeshProUGUI tutorialText;
    public float gap = 15.0f;
    public float delay = 15.0f;
    public float timer = 0.0f;

    private bool lightingTutorial = false;
    private bool audioTutorial = false;
    private bool videoTutorial = false;
    private bool offScriptTutorial = false;
    private bool batteryTutorial = false;
    public bool progressTutorial = false;
    private bool attackTutorial = false;

    public bool tutorialActive = false;

    public bool tvBroken = false;
    public bool stereoBroken = false;
    public bool spotBroken = false;

    public TimingMini timingMini;
    public ProgressTracker progressTracker;
    public AudioSource phone;

    public AudioClip tutorialVoice;
    
    // Start is called before the first frame update
    void Start()
    {
        phone.clip = tutorialVoice;
        phone.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialActive == true)
        {
            if (progressTutorial == true)
            {
                timer += Time.deltaTime;

                if (timer >= delay)
                {
                    if (progressTracker.progressCount < 1)
                    {
                        timingMini.isActive = true;
                    }
                    else
                    {
                        timingMini.isActive = false;
                        timer = 0;
                        phone.clip = tutorialVoice;
                        phone.Play();

                        progressTutorial = false;
                        batteryTutorial = true;
                    }
                    tutorialText.text = "Progress Meter Tutorial";
                }
                
            }

            if (batteryTutorial == true)
            {
                batteryTutorial = true;
                videoTutorial = true;
            }

            if (videoTutorial == true)
            {
                timer += Time.deltaTime;

                if (timer >= gap)
                {
                    if (tvBroken == false)
                    {
                        malfManager.VideoMalfunction();
                        tvBroken = true;
                    }

                    if (tvBroken == true && malfManager.videoBroken == false)
                    {
                        timer = 0;
                        malfManager.malfNum++;
                        phone.clip = tutorialVoice;
                        phone.Play();

                        videoTutorial = false;
                        audioTutorial = true;
                    }
                    tutorialText.text = "Video Malfunction Tutorial";
                }
            }

            if (audioTutorial == true)
            {
                timer += Time.deltaTime;

                if (timer >= gap)
                {
                    if (stereoBroken == false)
                    {
                        malfManager.AudioMalfunction();
                        stereoBroken = true;
                    }

                    if (stereoBroken == true && malfManager.audioBroken == false)
                    {
                        timer = 0;
                        malfManager.malfNum++;
                        phone.clip = tutorialVoice;
                        phone.Play();

                        audioTutorial = false;
                        lightingTutorial = true;
                    }
                    tutorialText.text = "Audio Malfunction Tutorial";
                }
            }

            if (lightingTutorial == true)
            {
                timer += Time.deltaTime;

                if (timer >= gap)
                {
                    if (spotBroken == false)
                    {
                        malfManager.LightingMalfunction();
                        spotBroken = true;
                    }

                    if (spotBroken == true && malfManager.lightsBroken == false)
                    {
                        timer = 0;
                        malfManager.malfNum++;
                        phone.clip = tutorialVoice;
                        phone.Play();

                        lightingTutorial = false;
                        attackTutorial = true;
                    }
                    tutorialText.text = "Lighting Malfunction Tutorial";
                }
            }
        }
    }

    void LightingTutorial()
    {
        
    }

    void AudioTutorial()
    {
        
    }

    void VideoTutorial()
    {
        
    }

    void OffScriptTutorial()
    {
        
    }

    void BatteryTutorial()
    {
        
    }

    void ResetTutorial()
    {
        
    }

    void AttackTutorial()
    {
        
    }
}
