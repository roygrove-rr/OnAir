using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    private MeshRenderer myRenderer;

    public GameObject boss;
    
    public Material darkMaterial;
    public Material invisMaterial;

    public bool isActive = false;
    public bool isNotActive = true;

    private float counter = 0.0f;
    private float trigger = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        counter = Random.Range(0, 90);
        
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material = invisMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            counter += Time.deltaTime;
            
            if (counter >= trigger)
            {
                isActive = true;
            }
        }
        else
        {
            counter = Random.Range(0, 90);
        }
    }

    private void OnBecameInvisible()
    {
        if (isActive == true)
        {
            myRenderer.material = darkMaterial;
            isActive = false;
        }
        else
        {
            myRenderer.material = invisMaterial;
        }
    }
}
