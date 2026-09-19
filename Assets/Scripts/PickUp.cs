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

    //public float holdDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity = controller.velocity.normalized;
        Debug.Log(playerVelocity);

        if (heldObj != null)
        {
            MoveObject();
            
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

    void MoveObject()
    {
        heldObj.transform.position = holdPos.transform.position;
    }

    void DropObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObjRb.velocity = playerVelocity;
        
        heldObj = null;
    }

    void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObjRb.velocity = playerVelocity;
        heldObjRb.AddForce(transform.forward * throwSpeed);

        heldObj = null;
    }
}
