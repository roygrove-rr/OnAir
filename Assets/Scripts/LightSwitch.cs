using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public MalfManager malfManager;
    
    public GameObject reporter;
    public GameObject desk;
    public GameObject stage;
    public GameObject eyes;
    public GameObject lights;
    private bool lightsOn = true;
    
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
        return ("Fix Lights");
    }

    public void Interact()
    {
        if (lightsOn == true)
        {
            reporter.SetActive(false);
            desk.SetActive(false);
            stage.SetActive(false);
            lights.SetActive(false);
            eyes.SetActive(true);

            lightsOn = false;
        }
        else
        {
            reporter.SetActive(true);
            desk.SetActive(true);
            stage.SetActive(true);
            lights.SetActive(true);
            eyes.SetActive(false);

            lightsOn = true;
        }
    }
}
