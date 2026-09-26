using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScene : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;
    public AudioSource soundPlayer;

    public AudioClip load;
    public AudioClip shoot;

    public bool active = false;
    public bool shotgun = false;

    private float shotgunCounter = 0.0f;
    private float shotgunTrigger = 7.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            door.GetComponent<Animator>().Play("DoorOpening", 0, 0.0f);
            Debug.Log("Door Open");
            active = false;
            shotgun = true;
            shotgunCounter = Random.Range(0, 5);
        }
        else
        {
            door.GetComponent<Animator>().Play("Idle");
        }

        if (shotgun == true)
        {
            shotgunCounter += Time.deltaTime;
            if (shotgunCounter >= shotgunTrigger)
            {
                soundPlayer.PlayOneShot(shoot);
                shotgun = false;
            }
        }
    }
}
