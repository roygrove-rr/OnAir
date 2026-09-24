using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class InOrderMiniSwitch : MonoBehaviour, IInteractable
{
    public string color;

    public InOrderMini inOrder;
    
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
        return("Flip switch");
    }

    public void Interact()
    {
        AddInput(inOrder.inputCounter);
    }

    public void AddInput(int i)
    {
        switch(color)
        {
            case "red":
                inOrder.userInput[i] = 0;
                Debug.Log(inOrder.userInput[i]);
                inOrder.indicatorMesh1.material = inOrder.defaultMaterial;
                inOrder.inputCounter++;
                break;

            case "blue":
                inOrder.userInput[i] = 1;
                Debug.Log(inOrder.userInput[i]);
                inOrder.indicatorMesh2.material = inOrder.defaultMaterial;
                inOrder.inputCounter++;
                break;

            case "yellow":
                inOrder.userInput[i] = 2;
                Debug.Log(inOrder.userInput[i]);
                inOrder.indicatorMesh3.material = inOrder.defaultMaterial;
                inOrder.inputCounter++;
                break;
        }
    }
}
