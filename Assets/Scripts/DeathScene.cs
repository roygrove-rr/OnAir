using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;
    public AudioSource soundPlayer;

    public AudioClip load;
    public AudioClip shoot;
    public AudioClip creak;

    public GameObject blackScreen;

    public bool active = false;
    public bool loaded = false;
    public bool shotgun = false;
    public bool transition = false;

    public AnimationClip doorOpen;
    private PlayableGraph graph;

    private float shotgunCounter = 0.0f;
    private float shotgunTrigger = 7.0f;
    private float transitionCounter = 0.0f;
    private float transitionTrigger = 2.0f;
    
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
            var soundplayed = false;
            if (soundplayed == false)
            {
                soundPlayer.PlayOneShot(creak);
                soundPlayer.PlayDelayed(2.1f);
                soundplayed = true;
            }
            Debug.Log("Door Opening");
            shotgunCounter = Random.Range(0, 5);
            active = false;
            shotgun =  true;
        }

        if (shotgun == true)
        {
            shotgunCounter += Time.deltaTime;
            if (shotgunCounter >= shotgunTrigger)
            {
                soundPlayer.PlayOneShot(shoot);
                blackScreen.SetActive(true);
                shotgun = false;
                transition = true;
            }
        }

        if (transition == true)
        {
            transitionCounter += Time.deltaTime;
            if (transitionCounter >= transitionTrigger)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
