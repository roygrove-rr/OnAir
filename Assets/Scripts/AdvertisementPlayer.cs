using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AdvertisementPlayer : MonoBehaviour, IInteractable
{
    public GameObject tv;
    public VideoClip newsChannel;
    public VideoClip adChannel;
    private VideoPlayer tvPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        tvPlayer = tv.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDescription()
    {
        return ("Play Advertisement");
    }

    public void Interact()
    {
        if (tvPlayer.clip == null || tvPlayer.clip == newsChannel)
        {
            tvPlayer.clip = adChannel;
            tvPlayer.playbackSpeed = 1;
        }
    }
}
