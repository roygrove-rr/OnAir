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

    public float displayLength = 1f;
    public float delayLength = 1f;
    public float timer = 0.0f;

    private int[] randomOrder = new int[4];

    public bool active;
    public bool isDisplaying;
    public bool isDelaying;
    
    // Start is called before the first frame update
    void Start()
    {
        randomOrder[0] = Random.Range(4, 0);
        randomOrder[1] = Random.Range(4, 0);
        randomOrder[2] = Random.Range(4, 0);
        randomOrder[3] = Random.Range(4, 0);

        redMesh = redButton.GetComponent<MeshRenderer>();
        blueMesh = blueButton.GetComponent<MeshRenderer>();
        greenMesh = greenButton.GetComponent<MeshRenderer>();
        yellowMesh = yellowButton.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            DisplayCode();
        }
    }

    public void DisplayCode ()
    {
        isDisplaying = true;
        isDelaying = false;

        var displayTime = 0;
        var delayTime = 0;

        for (int i = 0; i < randomOrder.Length; i++)
        {
            if (isDisplaying == true)
            {
                while (displayTime < 1)
                {
                    switch (randomOrder[i])
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
                            greenMesh.material = greenMaterial;
                            break;
                    }

                    timer += Time.deltaTime;
                    Debug.Log("Displaying");
                    if (timer >= displayLength)
                    {
                        isDisplaying = false;
                        isDelaying = true;

                        timer = 0;
                        displayTime++;
                    }
                }
                displayTime = 0;
            }
            else
            {
                while (delayTime < 1)
                {
                    redMesh.material = defaultMaterial;
                    blueMesh.material = defaultMaterial;
                    greenMesh.material = defaultMaterial;
                    yellowMesh.material = defaultMaterial;

                    timer += Time.deltaTime;
                    Debug.Log("Cooldown");
                    if (timer >= delayLength)
                    {
                        isDisplaying = true;
                        isDelaying = false;

                        timer = 0;
                        displayTime++;
                    }
                }
                delayTime = 0;
            }


        }

        active = false;
    }
}
