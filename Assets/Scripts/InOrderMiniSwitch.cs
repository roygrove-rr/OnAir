using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class InOrderMiniSwitch : MonoBehaviour, IInteractable
{
    public string color;

    public InOrderMini inOrder;
    public MalfManager malfManager;
    public GameObject switchPos;
    public GameObject switchBack;
    private bool flipped = false;
    private bool unflipped = false;

    public AudioSource inOrderAudio;
    public AudioClip click;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (malfManager.audioBroken)
        {
            if (flipped == false)
            {
                transform.position = switchPos.transform.position;
                flipped = true;
            }   
        }
        else
        {
            flipped = false;
        }
        
    }

    public string GetDescription()
    {
        return("Flip switch");
    }

    public void Interact()
    {
        if (malfManager.audioBroken)
        {
            AddInput(inOrder.inputCounter);
            transform.position = switchBack.transform.position;
            inOrderAudio.PlayOneShot(click);
        }  
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
