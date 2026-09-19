using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This is the universal interaction code, none of what happens when you interact with objects is handled here, so leave this unchanged.

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one/2f);
        RaycastHit hit;

        bool hitSomething = false;
        
        // Sends out a raycast to check if any interactable objects are in from of the player
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // If the raycasts hits an interactable object, brings up the interact prompt
            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                // If the interact button is pressed, tell the interactable object to run the code in its Interact function
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }

        interactionUI.SetActive(hitSomething);
    }
}
