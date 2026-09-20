using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFix : MonoBehaviour, IInteractable
{
    public MalfManager malfManager;
    public AudioSource tvAudio;
    private AudioDistortionFilter distortionFilter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDescription()
    {
        return ("Fix Audio");
    }

    public void Interact()
    {
        if (malfManager.audioBroken == true)
        {
            if (tvAudio != null)
            {
                distortionFilter = tvAudio.gameObject.GetComponent<AudioDistortionFilter>();

                distortionFilter.enabled = false;
                tvAudio.volume = 1;

                malfManager.audioBroken = false;
            }
        }
    }
}
