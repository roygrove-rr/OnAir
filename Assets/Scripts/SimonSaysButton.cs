using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysButton : MonoBehaviour, IInteractable
{
    public string color;
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
        return ("SimonSays");
    }

    public void Interact()
    {  
        if (simonSaysScript.awaitingInput == true)
        {
            for (int i = 0; i <= simonSaysScript.inputLength;)
            {
                if (i == simonSaysScript.inputLength)
                {
                    Debug.Log(i);
                    addInput(i);
                    
                    simonSaysScript.awaitingInput = false;
                    simonSaysScript.inputCooldown = true;
                    simonSaysScript.cooldownTimer = 0;
                }

                i++;
            }

            simonSaysScript.inputLength++;
        }

        Debug.Log("interacted with!");
    }

    public void addInput(int i)
    {
        switch (color)
        {
            case "red":
                simonSaysScript.userInput[i] = 0;
                break;

            case "blue":
                simonSaysScript.userInput[i] = 1;
                break;

            case "green":
                simonSaysScript.userInput[i] = 2;
                break;

            case "yellow":
                simonSaysScript.userInput[i] = 3;
                break;
        }
    }
}
