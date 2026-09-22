using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class SimonSays : MonoBehaviour
{
    public GameObject redButton;
    public GameObject blueButton;
    public GameObject greenButton;
    public GameObject yellowButton;

    public Material redMaterial;
    public Material blueMaterial;
    public Material greenMaterial;
    public Material yellowMaterial;
    public Material defaultMaterial;

    private MeshRenderer redMesh;
    private MeshRenderer blueMesh;
    private MeshRenderer greenMesh;
    private MeshRenderer yellowMesh;

    public float displayLength = 5f;
    public float delayLength = 5f;
    public float displayTimer = 0.0f;
    public float delayTimer = 0.0f;

    private int[] randomOrder = new int[4];

    public bool active;
    public bool isDisplaying;
    public bool isDelaying;
    public int displayNum;
    public int codeLength = 4;

    public bool awaitingInput;
    public int[] userInput = new int[4];
    public int inputLength;
    public bool inputCooldown;
    public float inputCooldownTime = 0.5f;
    public float cooldownTimer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        randomOrder[0] = UnityEngine.Random.Range(4, 0);
        randomOrder[1] = UnityEngine.Random.Range(4, 0);
        randomOrder[2] = UnityEngine.Random.Range(4, 0);
        randomOrder[3] = UnityEngine.Random.Range(4, 0);
        codeLength = randomOrder.Length;

        Debug.Log(randomOrder);

        redMesh = redButton.GetComponent<MeshRenderer>();
        blueMesh = blueButton.GetComponent<MeshRenderer>();
        greenMesh = greenButton.GetComponent<MeshRenderer>();
        yellowMesh = yellowButton.GetComponent<MeshRenderer>();

        isDisplaying = false;
        isDelaying = false;
        awaitingInput = false;
        inputCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true) 
        {
            if (isDelaying == true)
            {
                delayTimer += Time.deltaTime;

                redMesh.material = defaultMaterial;
                blueMesh.material = defaultMaterial;
                greenMesh.material = defaultMaterial;
                yellowMesh.material = defaultMaterial;


                if (delayTimer >= delayLength)
                {
                    isDelaying = false;
                    isDisplaying = true;

                    if (displayNum >= codeLength - 1)
                    {
                        active = false;
                        isDelaying = false;
                        isDisplaying = false;
                        awaitingInput = true;

                        Debug.Log("Display complete");
                    }

                    displayNum++;
                    delayTimer = 0;
                }
            }
            else
            {
                displayTimer += Time.deltaTime;

                switch (randomOrder[displayNum] - 1)
                {
                    case 0:
                        redMesh.material = redMaterial;
                        break;

                    case 1:
                        blueMesh.material = blueMaterial;
                        break;

                    case 2:
                        greenMesh.material = greenMaterial;
                        break;

                    case 3:
                        yellowMesh.material = yellowMaterial;
                        break;
                }

                if (displayTimer >= displayLength)
                {
                    isDelaying = true;
                    isDisplaying = false;

                    displayTimer = 0;
                }
            }
        }
        
        if (awaitingInput == true)
        {
            inputLength = 0;
            
            redMesh.material = redMaterial;
            blueMesh.material = blueMaterial;
            greenMesh.material = greenMaterial;
            yellowMesh.material = yellowMaterial;


                if (userInput == randomOrder)
                {
                    awaitingInput = false;
                    success();
                }
        }

        if (inputCooldown == true)
        {
            cooldownTimer += Time.deltaTime;

            redMesh.material = defaultMaterial;
            blueMesh.material = defaultMaterial;
            greenMesh.material = defaultMaterial;
            yellowMesh.material = defaultMaterial;

            if (cooldownTimer >= inputCooldownTime)
            {
                awaitingInput = true;
                inputCooldown = false;
            }
        }
    }

    public void success()
    {
        Debug.Log("success!");
    }

    public void failure()
    {
        Debug.Log("failure...");
    }
}
