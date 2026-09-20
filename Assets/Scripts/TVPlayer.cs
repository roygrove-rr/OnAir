using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Video;

public class TVPlayer : MonoBehaviour
{
    public VideoPlayer tv;
    public VideoClip newsChannel;
    public VideoClip adChannel;
    public double savedTime = 0.0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Event that detects when the advertisement has finished
        tv.loopPointReached += OnVideoFinished;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // After the ad is finished the videoplayer returns to playing the news channel
        tv.clip = newsChannel;
        tv.playbackSpeed = 1;
        tv.time = savedTime;
    }

    private void OnDestroy()
    {
        if (tv != null)
        {
            tv.loopPointReached -= OnVideoFinished;
        }
    }
}
