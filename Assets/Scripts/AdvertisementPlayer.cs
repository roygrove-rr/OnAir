using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class AdvertisementPlayer : MonoBehaviour, IInteractable
{
    public GameObject tv;
    public VideoClip newsChannel;
    public VideoClip adChannel_1;
    public VideoClip adChannel_2;
    public VideoClip adChannel_3;
    private VideoPlayer tvPlayer;
    public TVPlayer tvScript;
    
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
            tvScript.savedTime = tvPlayer.time;

            var randomAd = Random.Range(0, 4);
            tvPlayer.clip = adChannel_1;

            switch (randomAd)
            {
                case 1:
                    tvPlayer.clip = adChannel_1;
                    break;

                case 2:
                    tvPlayer.clip = adChannel_2;
                    break;

                case 3:
                    tvPlayer.clip = adChannel_3;
                    break;
            }

            tvPlayer.playbackSpeed = 1;
        }
    }
}
