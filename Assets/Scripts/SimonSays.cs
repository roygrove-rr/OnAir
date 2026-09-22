using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float timer = 0.0f;

    private int[] randomOrder = new int[4];

    public bool active;
    public bool isDisplaying;
    public bool isDelaying;
    
    // Start is called before the first frame update
    void Start()
    {
        randomOrder[0] = UnityEngine.Random.Range(4, 0);
        randomOrder[1] = UnityEngine.Random.Range(4, 0);
        randomOrder[2] = UnityEngine.Random.Range(4, 0);
        randomOrder[3] = UnityEngine.Random.Range(4, 0);

        redMesh = redButton.GetComponent<MeshRenderer>();
        blueMesh = blueButton.GetComponent<MeshRenderer>();
        greenMesh = greenButton.GetComponent<MeshRenderer>();
        yellowMesh = yellowButton.GetComponent<MeshRenderer>();

        isDisplaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true) 
        {
            isDisplaying = true;
            isDelaying = false;

            for (int i = 0; i < 2; i++)
            {
                if (isDisplaying == true)
                {
                    timer += Time.deltaTime;
                    Debug.Log("Displaying");
                    if (timer >= displayLength)
                    {
                        isDisplaying = false;
                        isDelaying = true;

                        timer = 0;
                    }
                }
                else
                {
                    timer += Time.deltaTime;
                    Debug.Log("Cooldown");
                    if (timer >= delayLength)
                    {
                        isDisplaying = true;
                        isDelaying = false;

                        timer = 0;
                    }
                }
            }
        }
        
        //if (active == true)
        //{
        //    isDisplaying = true;
        //    isDelaying = false;

        //    for (int i = 0; i < randomOrder.Length; i++)
        //    {
        //        if (isDisplaying == true)
        //        {
        //            switch (randomOrder[i])
        //            {
        //                case 0:
        //                    redMesh.material = redMaterial;
        //                    break;

        //                case 1:
        //                    blueMesh.material = blueMaterial;
        //                    break;

        //                case 2:
        //                    greenMesh.material = greenMaterial;
        //                    break;

        //                case 3:
        //                    greenMesh.material = greenMaterial;
        //                    break;
        //            }

        //            timer += Time.deltaTime;
        //            Debug.Log("Displaying");
        //            if (timer >= displayLength)
        //            {
        //                isDisplaying = false;
        //                isDelaying = true;

        //                timer = 0;
        //            }
        //        }
                
        //        if (isDelaying == true)
        //        {
        //            redMesh.material = defaultMaterial;
        //            blueMesh.material = defaultMaterial;
        //            greenMesh.material = defaultMaterial;
        //            yellowMesh.material = defaultMaterial;

        //            timer += Time.deltaTime;
        //            Debug.Log("Cooldown");
        //            if (timer >= delayLength)
        //            {
        //                isDisplaying = true;
        //                isDelaying = false;

        //                timer = 0;
        //            }
        //        }
        //    }

        //    isDisplaying = false;
        //    active = false;
        //}
    }
}
