using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingMiniButton : MonoBehaviour, IInteractable
{
    public TimingMini timingMini;
    
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
        return ("Stop timer");
    }

    public void Interact()
    {
        if (timingMini.isActive == true)
        {
            if (timingMini.currentTarget == timingMini.randomTarget)
            {
                timingMini.success();
            }
            else
            {
                timingMini.failure();
            }
        }
    }
}
