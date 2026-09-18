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
    public void OnHover();
    public void OnHoverExit();
}
public class Interact : MonoBehaviour
{
    public Camera cam;
    public float interactDistance = 2f;
    public Color hoverColor = Color.yellow;

    private IInteractable current;
    private Renderer r;
    private Color originalColor;
    
    
    //public Transform interactorSource;
    //public float interactRange = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance) && hit.collider.TryGetComponent(out IInteractable i))
            {
                if (current != i)
                {
                    Clear();
                    current = i;
                    current.OnHover();

                    r = hit.collider.GetComponent<Renderer>();
                    if (r)
                    {
                        originalColor = r.material.color;
                        r.material.color = hoverColor;
                    }
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    current.Interact();
                }
            }
            else
            {
                Clear();
            }
            
            
            //Debug.Log("Raycast Sent");
            //Ray r = new Ray(interactorSource.position, interactorSource.forward);
            //if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            //{
            //    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            //    {
            //        interactObj.Interact();
            //        Debug.Log("Raycast Return");
            //    }
            //}
        }
    }

    void Clear()
    {
        if (current != null)
        {
            current.OnHoverExit();
            if (r) r.material.color = originalColor;
            current = null;
            r = null;
        }
    }
}
