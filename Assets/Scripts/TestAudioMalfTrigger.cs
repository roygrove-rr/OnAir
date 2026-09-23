using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioMalfTrigger : MonoBehaviour, IInteractable
{
    public MalfManager malfManager;
    
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
        return("Trigger audio malfunction");
    }

    public void Interact()
    {
        malfManager.AudioMalfunction();
    }
}
