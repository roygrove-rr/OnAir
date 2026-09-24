using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InOrderMini : MonoBehaviour
{
    public bool isDisplaying = false;
    public bool awaitingInput = false;

    public GameObject codeLight1;
    public GameObject codeLight2;
    public GameObject codeLight3;

    public GameObject indicator1;
    public GameObject indicator2;
    public GameObject indicator3;

    public MeshRenderer indicatorMesh1;
    public MeshRenderer indicatorMesh2;
    public MeshRenderer indicatorMesh3;
    public MeshRenderer codeMesh1;
    public MeshRenderer codeMesh2;
    public MeshRenderer codeMesh3;

    public Material redMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;
    public Material defaultMaterial;
    public Material successMaterial;

    public float delayLength = 0.3f;
    private float displayTimer = 0.0f;
    private int displaySect = 0;

    public int[] randomCode = new int[3];
    public int[] userInput = new int[3];
    public int inputCounter = 0;

    public bool isInactive = true;
    public bool isPaused = false;
    public bool isCorrect = false;
    public bool isWrong = false;
    public float pauseLength = 0.8f;
    public float pauseCounter = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateCode();
        
        indicatorMesh1 = indicator1.GetComponent<MeshRenderer>();
        indicatorMesh2 = indicator2.GetComponent<MeshRenderer>();
        indicatorMesh3 = indicator3.GetComponent<MeshRenderer>();

        codeMesh1 = codeLight1.GetComponent<MeshRenderer>();
        codeMesh2 = codeLight2.GetComponent<MeshRenderer>();
        codeMesh3 = codeLight3.GetComponent<MeshRenderer>();

        indicatorMesh1.material = defaultMaterial;
        indicatorMesh2.material = defaultMaterial;
        indicatorMesh3.material = defaultMaterial;
        
        codeMesh1.material = defaultMaterial;
        codeMesh2.material = defaultMaterial;
        codeMesh3.material = defaultMaterial;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isInactive == true)
        {
            indicatorMesh1.material = defaultMaterial;
            indicatorMesh2.material = defaultMaterial;
            indicatorMesh3.material = defaultMaterial;
        
            codeMesh1.material = defaultMaterial;
            codeMesh2.material = defaultMaterial;
            codeMesh3.material = defaultMaterial;
        }

        if (isPaused == true)
        {
            if (isCorrect == true)
            {
                codeMesh1.material = successMaterial;
                codeMesh2.material = successMaterial;
                codeMesh3.material = successMaterial;

                indicatorMesh1.material = successMaterial;
                indicatorMesh2.material = successMaterial;
                indicatorMesh3.material = successMaterial;
                
                pauseCounter += Time.deltaTime;

                if (pauseCounter >= pauseLength)
                {
                    isPaused = false;
                    isCorrect = false;

                    awaitingInput = false;
                    isInactive = true;
                }
            }
            else if (isWrong == true)
            {
                codeMesh1.material = redMaterial;
                codeMesh2.material = redMaterial;
                codeMesh3.material = redMaterial;

                indicatorMesh1.material = redMaterial;
                indicatorMesh2.material = redMaterial;
                indicatorMesh3.material = redMaterial;
                
                pauseCounter += Time.deltaTime;

                if (pauseCounter >= pauseLength)
                {
                    isPaused = false;
                    isCorrect = false;

                    awaitingInput = false;
                    isInactive = true;
                }
            }
        }
        
        if (isDisplaying == true)
        {
            isInactive = false;
            
            var codeTry = Random.Range(0, 2);
            displayTimer += Time.deltaTime;

            if (displayTimer >= delayLength)
            {
                switch (displaySect)
                {
                    case 0:
                        codeMesh1.material = redMaterial;
                        codeMesh2.material = defaultMaterial;
                        codeMesh3.material = defaultMaterial;

                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 1:
                        codeMesh1.material = defaultMaterial;
                        codeMesh2.material = redMaterial;
                        codeMesh3.material = defaultMaterial;
                        
                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 2:
                        codeMesh1.material = defaultMaterial;
                        codeMesh2.material = defaultMaterial;
                        codeMesh3.material = redMaterial;

                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 3:
                        lightUp(codeMesh1, 0);
                        lightUp(codeMesh2, 1);
                        lightUp(codeMesh3, 2);

                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 4:
                        indicatorMesh1.material = redMaterial;
                        indicatorMesh2.material = blueMaterial;
                        indicatorMesh3.material = yellowMaterial;

                        Debug.Log("Finished displaying");

                        displayTimer = 0;
                        displaySect = 0;
                        isDisplaying = false;
                        awaitingInput = true;
                        break;
                }
            }
        }

        if (awaitingInput == true)
        {
            if (inputCounter >= 3)
            {
                if (userInput[0] == randomCode[0] &&
                    userInput[1] == randomCode[1] &&
                    userInput[2] == randomCode[2])
                {
                    success();
                }
                else
                {
                    failure();
                }
            }
        }
    }

    void GenerateCode()
    {
        var RNG = Random.Range(6, 0);
        switch (RNG)
        {
            case 1:
                randomCode[0] = 0;
                randomCode[1] = 1;
                randomCode[2] = 2;
                break;

            case 2:
                randomCode[0] = 0;
                randomCode[1] = 2;
                randomCode[2] = 1;
                break;

            case 3:
                randomCode[0] = 1;
                randomCode[1] = 0;
                randomCode[2] = 2;
                break;

            case 4:
                randomCode[0] = 1;
                randomCode[1] = 2;
                randomCode[2] = 0;
                break;

            case 5:
                randomCode[0] = 2;
                randomCode[1] = 0;
                randomCode[2] = 1;
                break;

            case 6:
                randomCode[0] = 2;
                randomCode[1] = 1;
                randomCode[2] = 0;
                break;
        }
    }

    void lightUp(MeshRenderer codeMesh, int i)
    {
        switch (randomCode[i])
        {
            case 0:
                codeMesh.material = redMaterial;
                break;

            case 1:
                codeMesh.material = blueMaterial;
                break;

            case 2:
                codeMesh.material = yellowMaterial;
                break;
        }
    }

    void success()
    {
        Debug.Log("Success!");
        Debug.Log(userInput[0] + " " + userInput[1] + " " + userInput[2]);
        Debug.Log(randomCode[0] + " " + randomCode[1] + " " + randomCode[2]);
        
        randomCode[0] = 5;
        randomCode[1] = 5;
        randomCode[2] = 5;
        GenerateCode();

        userInput[0] = 5;
        userInput[1] = 5;
        userInput[2] = 5;
        inputCounter = 0;

        isPaused = true;
        isCorrect = true;
    }

    void failure()
    {
        Debug.Log("Failure");
        Debug.Log(userInput[0] + " " + userInput[1] + " " + userInput[2]);
        Debug.Log(randomCode[0] + " " + randomCode[1] + " " + randomCode[2]);

        userInput[0] = 5;
        userInput[1] = 5;
        userInput[2] = 5;
        inputCounter = 0;

        isPaused = true;
        isWrong = true;
    }
}
