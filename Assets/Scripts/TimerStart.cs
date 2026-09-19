using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : MonoBehaviour, IInteractable
{
    [SerializeField] private Timer timerScript;
    public GameObject timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDescription()
    {
        return ("Start Timer");
    }

    public void Interact()
    {
        if (timerScript.isCountingDown == false)
        {
            timerScript.isCountingDown = true;
        }
        else
        {
            timerScript.isCountingDown = false;
            timerScript.timeRemaining = 90;
            timerScript.section = 1;
        }
        
    }
}
