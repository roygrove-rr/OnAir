using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public GameObject progressTracker;

    public int progressCount = 0;
    public int progressMax = 18;
    public bool isAdding = false;

    public Material litMaterial;
    public Material unlitMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (progressCount < progressMax)
        {
            if (isAdding == true)
            {
                for (int i = 0; i <= progressCount - 1; i++)
                {
                    var latestIndicator = progressTracker.transform.GetChild(i).gameObject;
                    var indicatorMesh = latestIndicator.GetComponent<MeshRenderer>();

                    indicatorMesh.material = litMaterial;
                }

                isAdding =  false;
            }
        }
    }
}
