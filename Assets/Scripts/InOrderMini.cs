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

    public float delayLength = 0.3f;
    private float displayTimer = 0.0f;
    private int displaySect = 0;

    public int[] randomCode = new int[3];
    public int[] userInput = new int[3];
    
    // Start is called before the first frame update
    void Start()
    {
indicatorMesh1 = indicator1.GetComponent<MeshRenderer>();
        indicatorMesh2 = indicator2.GetComponent<MeshRenderer>();
        indicatorMesh3 = indicator3.GetComponent<MeshRenderer>();

        codeMesh1 = codeLight1.GetComponent<MeshRenderer>();
        codeMesh2 = codeLight2.GetComponent<MeshRenderer>();
        codeMesh3 = codeLight3.GetComponent<MeshRenderer>();

        codeMesh1.material = defaultMaterial;
        codeMesh2.material = defaultMaterial;
        codeMesh3.material = defaultMaterial;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisplaying == true)
        {
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
                        randomCode[0] = codeTry;
                        codeTry = Random.Range(0, 2);

                        Debug.Log(randomCode[0]);
                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 1:
                        codeMesh1.material = defaultMaterial;
                        codeMesh2.material = redMaterial;
                        codeMesh3.material = defaultMaterial;
                        while(codeTry == randomCode[0])
                        {
                            codeTry = Random.Range(0, 2);
                        }
                        randomCode[1] = codeTry;
                        codeTry = Random.Range(0, 2);

                        Debug.Log(randomCode[1]);
                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 2:
                        codeMesh1.material = defaultMaterial;
                        codeMesh2.material = defaultMaterial;
                        codeMesh3.material = redMaterial;
                        while(codeTry == randomCode[0] || codeTry == randomCode[1])
                        {
                            codeTry = Random.Range(0, 2);
                        }
                        randomCode[2] = codeTry;
                        codeTry = Random.Range(0, 2);

                        Debug.Log(randomCode[2]);
                        displayTimer = 0;
                        displaySect++;
                        break;

                    case 3:
                        lightUp(codeMesh1, 0);
                        lightUp(codeMesh2, 1);
                        lightUp(codeMesh3, 2);
                        Debug.Log(randomCode[0] + " " + randomCode[1] + " " + randomCode[2]);

                        displayTimer = 0;
                        isDisplaying = false;
                        awaitingInput = true;
                        break;
                }
            }
        }

        if (awaitingInput == true)
        {
            
        }
    }

    void GenerateCode()
    {
        randomCode[0] = Random.Range(0, 2);
        Debug.Log("1: " + randomCode[0]);

        var _codeTry = Random.Range(0, 2);
        while (_codeTry == randomCode[0])
        {
            Debug.Log("2: " + _codeTry);
            _codeTry = Random.Range(0, 2);
        }
        randomCode[1] = _codeTry;
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
        randomCode[1] = 5;
        randomCode[2] = 5;
        randomCode[3] = 5;
        GenerateCode();
        awaitingInput = false;
    }

    void failure()
    {
        
    }
}
