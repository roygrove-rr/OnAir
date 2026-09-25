using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingMini : MonoBehaviour
{
    private GameObject display1;
    private GameObject display2;
    private GameObject display3;
    private GameObject display4;
    private GameObject display5;
    private GameObject display6;
    private GameObject display7;
    private GameObject display8;
    private GameObject display9;
    private GameObject display10;

    public ProgressTracker progressTracker;

    public int randomTarget;
    public int currentTarget;
    private GameObject currentLight;

    public float timerInterval;
    private float timer = 0.0f;
    private int counter = 0;

    private float pauseLength = 1;
    private float pauseTimer;
    private bool isPaused;
    public bool isActive;

    public Material litMaterial;
    public Material unlitMaterial;
    public Material targetMaterial;
    private Material oldMaterial;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        display1 = transform.GetChild(0).gameObject;
        display2 = transform.GetChild(1).gameObject;
        display3 = transform.GetChild(2).gameObject;
        display4 = transform.GetChild(3).gameObject;
        display5 = transform.GetChild(4).gameObject;
        display6 = transform.GetChild(5).gameObject;
        display7 = transform.GetChild(6).gameObject;
        display8 = transform.GetChild(7).gameObject;
        display9 = transform.GetChild(8).gameObject;
        display10 = transform.GetChild(9).gameObject;

        randomTarget = Random.Range(10, 0);

        isPaused = false;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused == true)
        {
            pauseTimer += Time.deltaTime;
            
            if (pauseTimer >= pauseLength)
            {
                isPaused = false;

                updateMaterial(display1, unlitMaterial);
                updateMaterial(display2, unlitMaterial);
                updateMaterial(display3, unlitMaterial);
                updateMaterial(display4, unlitMaterial);
                updateMaterial(display5, unlitMaterial);
                updateMaterial(display6, unlitMaterial);
                updateMaterial(display7, unlitMaterial);
                updateMaterial(display8, unlitMaterial);
                updateMaterial(display9, unlitMaterial);
                updateMaterial(display10, unlitMaterial);

                pauseTimer = 0;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= timerInterval)
            {
                if (counter < 9)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                timer = 0;
            }
        }

        if (isPaused == false && isActive == true)
        {
            switch (counter)
            {
                case 0:
                    updateMaterial(display1, litMaterial);
                    returnMaterial(display10, unlitMaterial);
                    currentTarget = 1;
                    currentLight = display1;
                    break;

                case 1:
                    updateMaterial(display2, litMaterial);
                    returnMaterial(display1, unlitMaterial);
                    currentTarget = 2;
                    currentLight = display2;
                    break;

                case 2:
                    updateMaterial(display3, litMaterial);
                    returnMaterial(display2, unlitMaterial);
                    currentTarget = 3;
                    currentLight = display3;
                    break;

                case 3:
                    updateMaterial(display4, litMaterial);
                    returnMaterial(display3, unlitMaterial);
                    currentTarget = 4;
                    currentLight = display4;
                    break;

                case 4:
                    updateMaterial(display5, litMaterial);
                    returnMaterial(display4, unlitMaterial);
                    currentTarget = 5;
                    currentLight = display5;
                    break;

                case 5:
                    updateMaterial(display6, litMaterial);
                    returnMaterial(display5, unlitMaterial);
                    currentTarget = 6;
                    currentLight = display6;
                    break;

                case 6:
                    updateMaterial(display7, litMaterial);
                    returnMaterial(display6, unlitMaterial);
                    currentTarget = 7;
                    currentLight = display7;
                    break;

                case 7:
                    updateMaterial(display8, litMaterial);
                    returnMaterial(display7, unlitMaterial);
                    currentTarget = 8;
                    currentLight = display8;
                    break;

                case 8:
                    updateMaterial(display9, litMaterial);
                    returnMaterial(display8, unlitMaterial);
                    currentTarget = 9;
                    currentLight = display9;
                    break;

                case 9:
                    updateMaterial(display10, litMaterial);
                    returnMaterial(display9, unlitMaterial);
                    currentTarget = 10;
                    currentLight = display10;
                    break;
            }

            switch (randomTarget)
            {
                case 1:
                    updateMaterial(display1, targetMaterial);
                    break;

                case 2:
                    updateMaterial(display2, targetMaterial);
                    break;

                case 3:
                    updateMaterial(display3, targetMaterial);
                    break;

                case 4:
                    updateMaterial(display4, targetMaterial);
                    break;

                case 5:
                    updateMaterial(display5, targetMaterial);
                    break;

                case 6:
                    updateMaterial(display6, targetMaterial);
                    break;

                case 7:
                    updateMaterial(display7, targetMaterial);
                    break;

                case 8:
                    updateMaterial(display8, targetMaterial);
                    break;

                case 9:
                    updateMaterial(display9, targetMaterial);
                    break;

                case 10:
                    updateMaterial(display10, targetMaterial);
                    break;
            }

            if (currentTarget == randomTarget)
            {
                updateMaterial(currentLight, litMaterial);
            }
        }
        //else
        //{
        //    updateMaterial(display1, unlitMaterial);
        //    updateMaterial(display2, unlitMaterial);
        //    updateMaterial(display3, unlitMaterial);
        //    updateMaterial(display4, unlitMaterial);
        //    updateMaterial(display5, unlitMaterial);
        //    updateMaterial(display6, unlitMaterial);
        //    updateMaterial(display7, unlitMaterial);
        //    updateMaterial(display8, unlitMaterial);
        //    updateMaterial(display9, unlitMaterial);
        //    updateMaterial(display10, unlitMaterial);
        //}
    }

    void updateMaterial(GameObject display, Material matType)
    {
        meshRenderer = display.GetComponent<MeshRenderer>();

        if (matType != null && meshRenderer != null)
        {
            meshRenderer.material = matType;
        }
    }
    void returnMaterial(GameObject display, Material matType)
    {
        meshRenderer = display.GetComponent<MeshRenderer>();

        if (matType != null && meshRenderer != null)
        {
            meshRenderer.material = matType;
        }
    }

    public void success()
    {
        randomTarget = Random.Range(10, 0);

        progressTracker.isAdding = true;
        progressTracker.progressCount++;

        updateMaterial(display1, litMaterial);
        updateMaterial(display2, litMaterial);
        updateMaterial(display3, litMaterial);
        updateMaterial(display4, litMaterial);
        updateMaterial(display5, litMaterial);
        updateMaterial(display6, litMaterial);
        updateMaterial(display7, litMaterial);
        updateMaterial(display8, litMaterial);
        updateMaterial(display9, litMaterial);
        updateMaterial(display10, litMaterial);
        counter = 0;

        PauseTimer();
    }

    public void failure()
    {
        updateMaterial(display1, targetMaterial);
        updateMaterial(display2, targetMaterial);
        updateMaterial(display3, targetMaterial);
        updateMaterial(display4, targetMaterial);
        updateMaterial(display5, targetMaterial);
        updateMaterial(display6, targetMaterial);
        updateMaterial(display7, targetMaterial);
        updateMaterial(display8, targetMaterial);
        updateMaterial(display9, targetMaterial);
        updateMaterial(display10, targetMaterial);
        counter = 0;

        PauseTimer();
    }

    private void PauseTimer()
    {
        isPaused = true;
    }
}
