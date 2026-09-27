using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysStartButton : MonoBehaviour, IInteractable
{
    public SimonSays simonSaysScript;
    public MalfManager malfManager;

    public AudioSource simonSaysAudio;
    public AudioClip click;
    
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
        return ("Start Simon Says");
    }

    public void Interact()
    {
        if (malfManager.videoBroken == true)
        {
            simonSaysScript.redMesh.material = simonSaysScript.defaultMaterial;
            simonSaysScript.blueMesh.material = simonSaysScript.defaultMaterial;
            simonSaysScript.greenMesh.material = simonSaysScript.defaultMaterial;
            simonSaysScript.yellowMesh.material = simonSaysScript.defaultMaterial;

            simonSaysScript.active = true;
            simonSaysScript.isDisplaying = true;
            simonSaysScript.isDelaying = false;

            simonSaysScript.awaitingInput = false;

            simonSaysScript.displayNum = 0;
        }

        simonSaysAudio.PlayOneShot(click);
    }
        
}
