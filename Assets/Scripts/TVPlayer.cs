using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Video;

public class TVPlayer : MonoBehaviour
{
    public VideoPlayer tv;
    public VideoClip newsChannel;
    public AudioClip audioChannel;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (malfManager.audioBroken == true)
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
        else
        {
            tv.playbackSpeed = 1f;
        }

        if (isAdPlaying == true)
        {
            //tv.audioOutputMode = VideoAudioOutputMode.AudioSource;
        }
        else
        {
            //tv.audioOutputMode = VideoAudioOutputMode.None;
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // After the ad is finished the videoplayer returns to playing the news channel
        isAdPlaying = false;

        tv.clip = newsChannel;
        tv.time = savedTime;

        audioSource.clip = audioChannel;
        audioSource.time = savedAudio;
    }

    private void OnDestroy()
    {
        if (tv != null)
        {
            tv.loopPointReached -= OnVideoFinished;
        }
    }
}
