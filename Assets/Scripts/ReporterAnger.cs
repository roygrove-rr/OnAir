using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporterAnger : MonoBehaviour
{
    public float angerCounter = 0.0f;
    public float angerTrigger = 35.0f;

    public bool isOutOfPlace = false;
    
    public Timer timer;
    public AdvertisementPlayer adPlayer;
    public MalfManager malfManager;

    public bool malfTriggered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        angerCounter = Random.Range(10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOutOfPlace == false)
        {
            if (timer.section > 3)
            {
                angerCounter += Time.deltaTime;
                if (angerCounter >= angerTrigger)
                {
                    angerCounter = Random.Range(10, 0);
                    isOutOfPlace = true;
                }
            }
        }
    }

    private void OnBecameVisible()
    {
        if (isOutOfPlace == true)
        {
            if (malfTriggered == false)
            {
                malfManager.malfNum++;
                malfTriggered = true;
            }
        }
    }
}
