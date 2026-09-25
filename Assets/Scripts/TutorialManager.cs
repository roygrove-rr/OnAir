using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public MalfManager malfManager;
    public GameManager gameManager;
    public TextMeshProUGUI tutorialText;
    public float gap = 2.0f;
    public float delay = 5.0f;
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

    public TimingMini timingMini;
    public ProgressTracker progressTracker;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                    malfManager.videoBroken = true;
                    if (malfManager.videoBroken == true)
                    {
                        malfManager.VideoMalfunction();
                    }
                    else
                    {
                        timer = 0;
                        videoTutorial = false;
                        audioTutorial = true;
                    }
                    tutorialText.text = "Video Malfunction Tutorial";
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
