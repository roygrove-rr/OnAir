using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an example code for an interaction script, reference this when adding new objects.
// Make sure to add the "IInteractable" at the end of the public class, that way the game knows this object is able to be interacted with.
// After that, add the functions "public string GetDescription()" and "public void Interact()".
// The GetDescription function should simply return a string stating what the action does. See the example below.
// The Interact function should contain all of the code that runs when the object is interacted with. You can also add any other code to the Start and Update functions, or any new functions, as needed.

public class ChangeColor : MonoBehaviour, IInteractable
{
    Material mat;
    
    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        
    }

    public string GetDescription()
    {
        return "Change to a random color.";
    }

    // This is the code that runs when the player presses the interact key on this object
    public void Interact()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }
}
