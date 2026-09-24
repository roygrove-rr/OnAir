using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporterMove : MonoBehaviour
{
    public Transform moveSpot1;
    public Transform moveSpot2;
    public Transform reporter;

    private bool pos1 = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        if (pos1 == true)
        {
            reporter.transform.position = moveSpot2.transform.position;
            pos1 = false;
        }
        else
        {
            reporter.transform.position = moveSpot1.transform.position;
            pos1 = true;
        }
    }
}
