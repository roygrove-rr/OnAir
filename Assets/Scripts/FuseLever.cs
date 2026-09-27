using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseLever : MonoBehaviour
{
    public GameObject moveTo;
    public GameObject moveFrom;
    public MalfManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.lightsBroken == true)
        {
            transform.position = moveTo.transform.position;
        }
        else
        {
            transform.position = moveFrom.transform.position;
        }
    }
}
