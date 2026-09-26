using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporterMove : MonoBehaviour
{
    public Timer timer;
    public MalfManager malfManager;
    public BossPatience boss;
    public ReporterAnger reporterAI;

    public GameObject reporterReset;
    public GameObject reporterWindow;
    
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
        if (reporterAI.isOutOfPlace == false)
        {
            reporterWindow.SetActive(false);
            reporterReset.SetActive(true);
            pos1 = true;
        }
    }

    private void OnBecameInvisible()
    {
        if (reporterAI.isOutOfPlace == true)
        {
            reporterWindow.SetActive(true);
            reporterReset.SetActive(false);
            pos1 = false;
        }
        else
        {
            
        }
    }
}
