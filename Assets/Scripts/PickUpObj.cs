using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpObj : MonoBehaviour, IInteractable
{
    [SerializeField] private PickUp pickupScript;
    public GameObject player;
    public LayerMask layer;
    private Rigidbody selfRigidbody;

    public bool fuse = false;
    
    // Start is called before the first frame update
    void Start()
    {
        selfRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDescription()
    {
        return("Pick Up");
    }
    
    public void  Interact()
    {
        // Assigns the object to the players heldObj and disables its physics
        pickupScript.heldObj = this.gameObject;
        pickupScript.heldObjRb = selfRigidbody;
        selfRigidbody.isKinematic = true;

        pickupScript.heldObjRb.transform.parent = pickupScript.holdPos.transform;
        pickupScript.heldObj.layer = 8;
        Physics.IgnoreCollision(pickupScript.heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }

    public void OnCollissionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision Trigger"))
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            layer = 0;
            selfRigidbody.isKinematic = false;

            pickupScript.heldObj = null;
        }
    }
}
