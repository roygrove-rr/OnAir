using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class SimonSays : MonoBehaviour
{
    public MalfManager malfManager;
    public BossPatience boss;
    public TutorialManager tutorial;
    
    public GameObject redButton;
    public GameObject blueButton;
    public GameObject greenButton;
    public GameObject yellowButton;
    public GameObject indicator;

    public Material redMaterial;
    public Material blueMaterial;
    public Material greenMaterial;
    public Material yellowMaterial;
    public Material defaultMaterial;

    public MeshRenderer redMesh;
    public MeshRenderer blueMesh;
    public MeshRenderer greenMesh;
    public MeshRenderer yellowMesh;
    public MeshRenderer indicatorMesh;

    public float displayLength = 5f;
    public float delayLength = 5f;
    public float displayTimer = 0.0f;
    public float delayTimer = 0.0f;

    private int[] randomOrder = new int[4];

    public bool needsFixing = false;
    public bool successCooldown = false;

    public bool active;
    public bool isDisplaying;
    public bool isDelaying;
    public int displayNum;
    public int codeLength = 4;

    public bool awaitingInput;
    public int[] userInput = new int[4];
    public int inputLength;
    public int whichIndexOn;
    public bool inputCooldown;
    public float inputCooldownTime = 0.5f;
    public float cooldownTimer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        randomOrder[0] = UnityEngine.Random.Range(0, 4);
        randomOrder[1] = UnityEngine.Random.Range(0, 4);
        randomOrder[2] = UnityEngine.Random.Range(0, 4);
        randomOrder[3] = UnityEngine.Random.Range(0, 4);
        codeLength = randomOrder.Length;

        Debug.Log(randomOrder);

        redMesh = redButton.GetComponent<MeshRenderer>();
        blueMesh = blueButton.GetComponent<MeshRenderer>();
        greenMesh = greenButton.GetComponent<MeshRenderer>();
        yellowMesh = yellowButton.GetComponent<MeshRenderer>();
        indicatorMesh = indicator.GetComponent<MeshRenderer>();

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

                    if (displayNum >= codeLength)
                    {
                        active = false;
                        isDelaying = false;
                        isDisplaying = false;
                        awaitingInput = true;
                        inputLength = 0;
                        userInput[0] = 5;
                        userInput[1] = 5;
                        userInput[2] = 5;
                        userInput[3] = 5;

                        Debug.Log("Display complete");
                    }
                    delayTimer = 0;
                }
            }
            else
            {
                displayTimer += Time.deltaTime;

                switch (randomOrder[displayNum])
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
                    displayNum++;
                    displayTimer = 0;
                }
            }
        }
        else if (awaitingInput == true)
        {
            redMesh.material = redMaterial;
            blueMesh.material = blueMaterial;
            greenMesh.material = greenMaterial;
            yellowMesh.material = yellowMaterial;


            if (inputLength == randomOrder.Length)
            {
                if (userInput[0] == randomOrder[0] &&
                    userInput[1] == randomOrder[1] &&
                    userInput[2] == randomOrder[2] &&
                    userInput[3] == randomOrder[3])
                {
                    Debug.Log("Success!");
                    awaitingInput = false;
                    success();
                }
                else
                {
                    Debug.Log("Wrong");
                    awaitingInput = false;
                    failure();
                }
            }
        }
        else if (inputCooldown == true)
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
        else if (successCooldown == true)
        {
            cooldownTimer += Time.deltaTime;

            indicatorMesh.material = greenMaterial;

            if (cooldownTimer >= inputCooldownTime)
            {
                awaitingInput = true;
                successCooldown = false;
                inputCooldownTime = 0.5f;
            }
        }
        else
        {
            redMesh.material = defaultMaterial;
            blueMesh.material = defaultMaterial;
            greenMesh.material = defaultMaterial;
            yellowMesh.material = defaultMaterial;
            indicatorMesh.material = defaultMaterial;
        }

        if (malfManager.videoBroken)
        {
            indicatorMesh.material = redMaterial;
        }
        else
        {
            indicatorMesh.material = greenMaterial;
        }
    }

    public void success()
    {
        indicatorMesh.material = greenMaterial;

        randomOrder[0] = UnityEngine.Random.Range(0, 4);
        randomOrder[1] = UnityEngine.Random.Range(0, 4);
        randomOrder[2] = UnityEngine.Random.Range(0, 4);
        randomOrder[3] = UnityEngine.Random.Range(0, 4);

        malfManager.videoBroken = false;
        boss.killCounter = boss.killCounter - 3;
        malfManager.malfNum--;

        inputCooldownTime = 1;
        successCooldown = true;
        active = false;
    }

    public void failure()
    {
        redMesh.material = redMaterial;
        blueMesh.material = redMaterial;
        greenMesh.material = redMaterial;
        yellowMesh.material = redMaterial;
    }
}
