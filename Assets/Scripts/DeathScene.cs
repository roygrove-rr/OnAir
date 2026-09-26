using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScene : MonoBehaviour
{
    public GameObject door;

    public float rotationSpd = 90.0f;
    public bool active = false;
    public bool opening = false;
    public float doorCounter = 0.0f;
    public float doorTimer = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        active = true;
        opening = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (opening == true)
            {
                door.transform.Rotate(Vector3.up * rotationSpd * Time.deltaTime);
            
                doorCounter += Time.deltaTime;
                if (doorCounter >= doorTimer)
                {
                    opening = false;
                }
            }
        }
    }
}
