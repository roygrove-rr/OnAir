using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoFix : MonoBehaviour, IInteractable
{
    public MalfManager malfManager;
    public BossPatience boss;
    
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
        return("Fix video");
    }

    public void Interact()
    {
        malfManager.videoBroken = false;
        boss.killCounter = boss.killCounter - 3;
        malfManager.malfNum--;
    }
}
