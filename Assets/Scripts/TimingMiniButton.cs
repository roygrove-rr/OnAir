using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingMiniButton : MonoBehaviour, IInteractable
{
    public TimingMini timingMini;
    public AudioSource timingAudio;
    public AudioClip buttonPress;
    public AudioClip correctInput;
    
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
        return ("Stop timer");
    }

    public void Interact()
    {
        if (timingMini.isActive == true)
        {
            if (timingMini.currentTarget == timingMini.randomTarget)
            {
                timingMini.success();
                timingAudio.PlayOneShot(correctInput);
            }
            else
            {
                timingMini.failure();
            }
            timingAudio.PlayOneShot(buttonPress);
        }
    }
}
