using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysStartButton : MonoBehaviour, IInteractable
{
    public SimonSays simonSaysScript;
    
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
        simonSaysScript.active = true;
        if (simonSaysScript.awaitingInput == true)
        {
            simonSaysScript.isDelaying = true;
            simonSaysScript.isDisplaying = false;
        }
        else
        {
            simonSaysScript.isDisplaying = true;
            simonSaysScript.isDelaying = false;
        }
        
        simonSaysScript.awaitingInput = false;

        simonSaysScript.displayNum = 0;
    }
        
}
