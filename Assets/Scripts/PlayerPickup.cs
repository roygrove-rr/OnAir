using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform playerCamera;
    public float pickupDistance = 2f;
    public LayerMask pickupLayerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
            {
                Debug.Log(raycastHit.transform);
            }
        }
    }
}
