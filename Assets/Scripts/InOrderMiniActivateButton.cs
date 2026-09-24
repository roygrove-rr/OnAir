using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOrderMiniActivateButton : MonoBehaviour, IInteractable
{
    public InOrderMini inOrder;
    
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
        return("In order");
    }

    public void Interact()
    {
        inOrder.codeMesh1.material = inOrder.defaultMaterial;
        inOrder.codeMesh2.material = inOrder.defaultMaterial;
        inOrder.codeMesh3.material = inOrder.defaultMaterial;
        
        inOrder.isDisplaying = true;
    }
}
