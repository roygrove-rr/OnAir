using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LightFix : MonoBehaviour, IInteractable
{
    public MalfManager malfManager;
    public BossPatience boss;

    public GameObject stage;
    public GameObject eyes;

    private bool lightsOn;
    
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
        if (malfManager.lightsBroken == true)
        {
            stage.SetActive(true);
            eyes.SetActive(false);

            malfManager.lightsBroken = false;
            boss.killCounter = boss.killCounter - 3;
            malfManager.malfNum--;
        }
        else
        {

        }
    }
}
