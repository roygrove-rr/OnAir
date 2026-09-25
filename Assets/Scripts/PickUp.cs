using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    public GameObject holdPos;
    public GameObject heldObj;
    public GameObject interactionUI;
    public Rigidbody heldObjRb;
    public float throwSpeed = 700;
    public int LayerNumber = 8;
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
                //StopClipping();
                DropObject();
                StopClipping();
            }

            if (Input.GetMouseButtonDown(2))
            {
                //StopClipping();
                ThrowObject();
                StopClipping();
            }

            interactionUI.SetActive(false);
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
        heldObj.transform.parent = null;

        heldObj = null;
    }

    // Same as drop object but it adds some force
    void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObjRb.AddForce(transform.forward * throwSpeed);
        heldObj.transform.parent = null;

        heldObj = null;
    }
    
    void StopClipping()
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.1f, 0f);
        }
    }
}
