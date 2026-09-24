using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject holdPos;
    public GameObject heldObj;
    public Rigidbody heldObjRb;
    public float throwSpeed = 500;
    public int LayerNumber;
    private CharacterController controller;
    private float currentPlayerV;
    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // This code is so I can attempt to implement better physics later
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heldObj != null)
        {
            MoveObject();
            heldObj.transform.localRotation = Quaternion.identity;
            
            if (Input.GetMouseButtonDown(1))
            {
                DropObject();
            }

            if (Input.GetMouseButtonDown(2))
            {
                ThrowObject();
            }
        }
    }

    // Updates the objects position to match the hold position in front of the camera
    void MoveObject()
    {
        heldObj.transform.position = holdPos.transform.position;
    }

    // Removes the object from heldObj and returns it to its usual physics settings
    void DropObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        
        heldObj = null;
    }

    // Same as drop object but it adds some force
    void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObjRb.AddForce(transform.forward * throwSpeed);

        heldObj = null;
    }
    
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the cliprange
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }
}
