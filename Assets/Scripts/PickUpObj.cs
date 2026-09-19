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
        Physics.IgnoreCollision(this.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        selfRigidbody.isKinematic = true;
        this.layer = pickupScript.LayerNumber;
        
        pickupScript.heldObj = this.gameObject;
        pickupScript.heldObjRb = selfRigidbody;
    }
}
