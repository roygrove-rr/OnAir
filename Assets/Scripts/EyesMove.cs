using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMove : MonoBehaviour
{
    public Transform targetPosition;
    public Transform resetPosition;
    private Vector3 targetVector;
    public MalfManager malfManager;
    public float speed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        targetVector = targetPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (malfManager.lightsBroken == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
        }
        else
        {
            transform.position = resetPosition.position;
        }
    }
}
