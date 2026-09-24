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

    public float delayLength = 0.3f;
    private float displayTimer = 0.0f;

    public int[] randomCode = new int[3];
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateCode();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisplaying == true)
        {
            DisplayCode();
            isDisplaying = false;
            awaitingInput = true;
        }

        if (awaitingInput == true)
        {
            
        }
    }

    void DisplayCode()
    {
        
    }

    void GenerateCode()
    {
        var storedCodeTry = 5;
        
        for (int i = 0; i < 3; i++)
        {
            var codeTry = Random.Range(0, 2);
            if (codeTry != storedCodeTry)
            {
                randomCode[i] = codeTry;
                storedCodeTry = codeTry;
            }
        }
    }

    void success()
    {
        GenerateCode();
    }

    void failure()
    {
        
    }
}
