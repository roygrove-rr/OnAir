using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is the universal interact script for all objects in the game
// To make an object able to be interacted with this simply change the public class to "public class NumberGenerator : MonoBehaviour, IInteractable"
// and then outside of the start or update functions add a function "public void Interact()"
// then add all of the code you want to run when interacting with it inside of that function.
// If at all possible avoid changing this code.

interface IInteractable
{
    public void Interact();
}
public class Interact : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
