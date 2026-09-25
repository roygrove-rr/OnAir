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

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        if (isActive == true)
        {
            myRenderer.material = invisMaterial;
            isActive = false;
        }
        else
        {
            myRenderer.material = darkMaterial;
        }
    }
}
