using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public MalfManager malfManager;
    public TextMeshProUGUI tutorialText;
    public int gap = 1;
    public int delay = 2;

    private bool lightingTutorial = false;
    private bool audioTutorial = false;
    private bool videoTutorial = false;
    private bool offScriptTutorial = false;
    private bool batteryTutorial = false;
    private bool resetTutorial = false;
    private bool attackTutorial = false;

    public bool tutorialActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialActive = true)
        {

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
