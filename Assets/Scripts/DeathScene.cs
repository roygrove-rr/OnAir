using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class DeathScene : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;
    public AudioSource soundPlayer;

    public AudioClip load;
    public AudioClip shoot;
    public AudioClip creak;

    public bool active = false;
    public bool shotgun = false;

    public AnimationClip doorOpen;
    private PlayableGraph graph;

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
            GetComponent<Animator>().Play("DoorOpening", 0, 0.0f);
            soundPlayer.PlayOneShot(creak);
            active = false;
            shotgun =  true;
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

    void OnDestroy()
    {
        // Crucial: Destroy the graph to prevent memory leaks
        if (graph.IsValid())
        {
            graph.Destroy();
        }
    }
}
