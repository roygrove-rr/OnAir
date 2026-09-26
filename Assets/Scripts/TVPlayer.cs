using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Video;

public class TVPlayer : MonoBehaviour
{
    public GameObject tvOverlay;
    private VideoPlayer tvOverlayPlayer;

    public VideoPlayer tv;

    public VideoClip newsChannel;
    public VideoClip newsIntro;
    public VideoClip tvStatic;
    public VideoClip tvDark;
    public VideoClip tvOffScript;

    public AudioClip audioChannel;
    public AudioClip newsIntroAudio;
    public AudioClip adMusic;
    public AudioSource audioSource;
    public MalfManager malfManager;
    public double savedTime = 0.0;
    public float savedAudio = 0.0f;

    public bool isAdPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Event that detects when the advertisement has finished
        tv.loopPointReached += OnVideoFinished;
        tvOverlayPlayer = tvOverlay.GetComponent<VideoPlayer>();

        tv.clip = newsIntro;
        tv.time = 1;
        audioSource.clip = newsIntroAudio;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (malfManager.audioBroken == true && isAdPlaying == false)
        {
            if (malfManager.audioPitchLow == true)
            {
                tv.playbackSpeed = 0.5f;
            }
            else
            {
                tv.playbackSpeed = 2f;
            }
        }
        else if (isAdPlaying)
        {
            audioSource.pitch = 1f;
            tv.playbackSpeed = 1f;
        }
        else
        {
            audioSource.pitch = 1f;
            tv.playbackSpeed = 1f;
        }

        if (malfManager.videoBroken == true)
        {
            tvOverlay.SetActive(true);
            tvOverlayPlayer.clip = tvStatic;
        }
        else if (malfManager.lightsBroken == true && isAdPlaying == false)
        {
            tvOverlay.SetActive(true);
            tvOverlayPlayer.clip = tvDark;
        }
        else if (malfManager.offScript == true && isAdPlaying == false)
        {
            tvOverlay.SetActive(true);
            tvOverlayPlayer.clip = tvOffScript;
        }
        else
        {
            tvOverlay.SetActive(false);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // After the ad is finished the videoplayer returns to playing the news channel
        
        if (tv.clip != newsChannel)
        {
            isAdPlaying = false;

            tv.clip = newsChannel;
            tv.time = savedTime;

            audioSource.clip = audioChannel;
            audioSource.time = savedAudio;

            audioSource.pitch = malfManager.lastDistortion;

            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        if (tv != null)
        {
            tv.loopPointReached -= OnVideoFinished;
        }
    }
}
