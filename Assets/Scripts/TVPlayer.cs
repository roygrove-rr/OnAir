using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVPlayer : MonoBehaviour
{
    public VideoPlayer tv;
    public VideoClip newsChannel;
    public VideoClip adChannel;
    
    // Start is called before the first frame update
    void Start()
    {
        tv.loopPointReached += OnVideoFinished;
    }

    // Update is called once per frame
    void Update()
    {
        //if (tv.clip == null)
        //{
        //    tv.clip = newsChannel;
        //}
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        tv.clip = newsChannel;
        tv.playbackSpeed = 1;
    }

    private void OnDestroy()
    {
        if (tv != null)
        {
            tv.loopPointReached -= OnVideoFinished;
        }
    }
}
