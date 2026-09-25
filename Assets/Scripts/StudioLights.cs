using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioLights : MonoBehaviour, IInteractable
{
    public GameObject lampLight1;
    public GameObject lampLight2;
    public GameObject lampLight3;
    public GameObject lampLight4;
    public GameObject lampLight5;
    public GameObject lampLight6;
    public GameObject studioLight;
    public GameObject illumination1;
    public GameObject illumination2;

    public GameObject switchLight;

    public MeshRenderer lampShade1;
    public MeshRenderer lampShade2;
    public MeshRenderer lampShade3;
    public GameObject ceilingLight;

    public Material lampShadeOnMat;
    public Material lampShadeOffMat;

    public bool lightsOn;

    public ReporterAnger reporter;
    public BossPatience boss;
    public MalfManager malfManager;
    
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
            lampLight1.SetActive(false);
            lampLight2.SetActive(false);
            lampLight3.SetActive(false);
            lampLight4.SetActive(false);
            lampLight5.SetActive(false);
            lampLight6.SetActive(false);
            switchLight.SetActive(true);

            lampShade1.material = lampShadeOffMat;
            lampShade2.material = lampShadeOffMat;
            lampShade3.material = lampShadeOffMat;
            ceilingLight.SetActive(false);

            if (reporter.isOutOfPlace == true)
            {
                reporter.isOutOfPlace = false;
                reporter.malfTriggered = false;
                boss.killCounter = boss.killCounter - 3;
                malfManager.malfNum--;
            }

            lightsOn = false;
        }
        else
        {
            studioLight.SetActive(true);
            lampLight1.SetActive(true);
            lampLight2.SetActive(true);
            lampLight3.SetActive(true);
            lampLight4.SetActive(true);
            lampLight5.SetActive(true);
            lampLight6.SetActive(true);
            switchLight.SetActive(true);

            lampShade1.material = lampShadeOnMat;
            lampShade2.material = lampShadeOnMat;
            lampShade3.material = lampShadeOnMat;
            ceilingLight.SetActive(true);

            lightsOn = true;
        }
    }
}
