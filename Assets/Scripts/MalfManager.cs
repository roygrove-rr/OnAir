using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class MalfManager : MonoBehaviour
{
    public bool active = false;
    
    public TextMeshProUGUI malfunctionUI;

    public Timer timer;
    public TVPlayer tvPlayer;
    
    // Audio malfunction resources
    public AudioSource tvAudio;
    public float audioDistortionMin = 0.5f;
    public float audioDistortionMax = 2f;
    public bool audioPitchLow = false;
    public float lastDistortion = 1f;

    // Lighting malfunction resources
    public GameObject stage;
    public GameObject eyes;

    public MeshRenderer tvMesh;
    private MeshRenderer overlayMesh;

    public GameObject tvOverlay;
    public VideoPlayer tvOverlayPlayer;
    public VideoClip tvStatic;
    public VideoClip tvDark;
    public VideoClip tvOffScript;
    
    private float timef = 0f;
    public int secondsPassed = 0;

    private int malfTrigger = 0;
    private int malfTriggerMax;
    private int malfTriggerMin;

    private int maxMalfunctions;
    public int malfNum = 0;
    public float malfRandom = 0f;

    public bool audioBroken = false;
    public bool lightsBroken = false;
    public bool videoBroken = false;
    public bool offScript = false;
    public bool malfHappening = false;
    
    // Start is called before the first frame update
    void Start()
    {
        tvMesh = tvPlayer.GetComponent<MeshRenderer>();
        overlayMesh = tvOverlayPlayer.GetComponent<MeshRenderer>();

        //overlayMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (malfNum < maxMalfunctions)
        {
            timef += Time.deltaTime;
            secondsPassed = Mathf.FloorToInt(timef);
        }
        else
        {
            
        }

        switch (timer.section)
        {
            case 1:
                malfTriggerMax = 20;
                malfTriggerMin = 15;
                maxMalfunctions = 1;
                break;

            case 2:
                malfTriggerMax = 15;
                malfTriggerMin = 10;
                maxMalfunctions = 1;
                break;

            case 3:
                malfTriggerMax = 15;
                malfTriggerMin = 10;
                maxMalfunctions = 2;
                break;

            case 4:
                malfTriggerMax = 12;
                malfTriggerMin = 7;
                maxMalfunctions = 2;
                break;

            case 5:
                malfTriggerMax = 12;
                malfTriggerMin = 7;
                maxMalfunctions = 3;
                break;

            default:
                malfTriggerMax = 10;
                malfTriggerMin = 5;
                maxMalfunctions = 3;
                break;

        }

        malfTrigger = Random.Range(malfTriggerMax, malfTriggerMin);
        
        if (secondsPassed >= malfTrigger && malfNum < maxMalfunctions)
        {
            var malfTriggered = 0;
            malfRandom = Random.Range(4, 0);

            while (malfTriggered < 1)
                if (malfNum >= maxMalfunctions)
                {
                    break;
                }
                else if (malfRandom == 1)
                {
                    if (audioBroken == false)
                    {
                        if (tvPlayer.isAdPlaying == false)
                        {
                            Debug.Log("Audio Malfunction Occured");
                            AudioMalfunction();

                            malfNum++;

                            malfTriggered++;
                        }
                    }
                    else
                    {
                        Debug.Log("There is already a malfunction of type audio");
                        malfRandom = Random.Range(4, 0);
                    }
                }
                else if (malfRandom == 2)
                {
                    if (lightsBroken == false)
                    {
                        Debug.Log("Lighting Malfunction Occured");
                        tvOverlay.SetActive(true);
                        LightingMalfunction();

                        malfNum++;

                        malfTriggered++;
                    }
                    else
                    {
                        Debug.Log("There is already a malfunction of type lighting");
                        malfRandom = Random.Range(4, 0);
                    }
                }
                else if (malfRandom == 3)
                {
                    if (videoBroken == false)
                    {
                        Debug.Log("Video Malfunction Occured");
                        //tvOverlay.SetActive(true);
                        //VideoMalfunction();

                        malfNum++;

                        malfTriggered++;
                    }
                    else
                    {
                        Debug.Log("There is already a malfunction of type video");
                        tvOverlay.SetActive(true);
                        malfRandom = Random.Range(4, 0);
                    }
                        
                }
                else if (malfRandom == 4)
                {
                    if (offScript == false)
                    {
                        Debug.Log("Off Script Malfunction Occured");
                        //OffScriptMalfunction();

                        malfNum++;

                        malfTriggered++;
                    }
                    else
                    {
                        Debug.Log("There is already a malfunction of type off script");
                        malfRandom = Random.Range(4, 0);
                    }
                        
                }
                else
                {
                    malfRandom = Random.Range(4, 0);
                }

                timef = 0;
        }

        // if (offScript == true)
        // {
        //     overlayMesh.enabled = true;
        //     tvOverlayPlayer.clip = tvOffScript;
        // }
        
        // if (lightsBroken == true)
        // {
        //     overlayMesh.enabled = true;
        //     tvOverlayPlayer.clip = tvDark;
        // }

        // if (videoBroken == true)
        // {
        //     overlayMesh.enabled = true;
        //     tvOverlayPlayer.clip = tvStatic;
        // }

        // if (offScript == false &&
        //     lightsBroken == false &&
        //     videoBroken == false)
        // {
        //      tvOverlay.SetActive(false);   
        // }

        if (malfNum > 0)
        {
            malfHappening = true;
        }
        malfunctionUI.text = malfNum.ToString();
        }
    }

    public void LightingMalfunction()
    {
        stage.SetActive(false);
        eyes.SetActive(true);

        lightsBroken = true;
    }

    public void AudioMalfunction()
    {
        if (tvAudio != null && tvPlayer.isAdPlaying == false)
        {
            if (Random.value < 0.5)
            {
                tvAudio.pitch = audioDistortionMin;
                lastDistortion = tvAudio.pitch;
                audioPitchLow = true;
            }
            else
            {
                tvAudio.pitch = audioDistortionMax;
                lastDistortion = tvAudio.pitch;
                audioPitchLow = false;
            }
            audioBroken = true;
        }
    }

    public void VideoMalfunction()
    {
        overlayMesh.enabled = true;
        tvOverlayPlayer.clip = tvStatic;
        
        videoBroken = true;
    }

    public void OffScriptMalfunction()
    {
        offScript = true;
    }
}
