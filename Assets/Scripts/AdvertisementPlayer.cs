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
    public AudioClip adMusic;
    public AudioSource audioSource;
    public MalfManager malfManager;
    private VideoPlayer tvPlayer;
    private int randomAd = 1;
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
        
        // If the tv is not already playing an ad, it starts playing one
        if (tvPlayer.clip == null || tvPlayer.clip == newsChannel)
        {
            if (tvPlayer.clip == newsChannel)
            {
                tvScript.savedTime = tvPlayer.time;
                tvScript.savedAudio = audioSource.time;
            }

            // Picks from a random ad to display, and checks to make sure that it's not the same as the last one
            var previousAd = randomAd;
            var adPlayed = 0;

            while (adPlayed < 1)
            {
                randomAd = Random.Range(0, 3);

                if (randomAd != previousAd)
                {
                    switch (randomAd)
                    {
                        case 0:
                            tvPlayer.clip = adChannel_1;
                            audioSource.clip = adMusic;
                            audioSource.Play();
                            tvScript.isAdPlaying = true;
                            adPlayed++;
                            break;

                        case 1:
                            tvPlayer.clip = adChannel_2;
                            audioSource.clip = adMusic;
                            audioSource.Play();
                            tvScript.isAdPlaying = true;
                            adPlayed++;
                            break;

                        case 2:
                            tvPlayer.clip = adChannel_3;
                            audioSource.clip = adMusic;
                            audioSource.Play();
                            tvScript.isAdPlaying = true;
                            adPlayed++;
                            break;
                    }
                }
                else
                {
                    randomAd = Random.Range(0, 3);
                }

                
            }
        }
    }
}
