using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioLights : MonoBehaviour, IInteractable
{
    public GameObject studioLight;
    public bool lightsOn;
    
    // Start is called before the first frame update
    void Start()
    {
        lightsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDescription()
    {
        return ("Light switch");
    }

    public void Interact()
    {
        if (lightsOn == true)
        {
            studioLight.SetActive(false);
            lightsOn = false;
        }
        else
        {
            studioLight.SetActive(true);
            lightsOn = true;
        }
    }
}
