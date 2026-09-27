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
    public Material redMaterial;
    public Material unlitMaterial;

    public int scrollCounter;

    private float scrollTimer = 0.0f;
    private float scrollSpeed = 0.1f;
    private GameObject scrollIndicatorLast;
    private MeshRenderer scrollMeshLast;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollCounter = progressCount;
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

            if (scrollCounter < progressMax)
            {
                scrollTimer += Time.deltaTime;

                if (scrollTimer >= scrollSpeed)
                {
                    var scrollIndicator = progressTracker.transform.GetChild(scrollCounter).gameObject;
                    var scrollMesh = scrollIndicator.GetComponent<MeshRenderer>();

                    if (scrollCounter != progressCount)
                    {
                        scrollIndicatorLast = progressTracker.transform.GetChild(scrollCounter - 1).gameObject;
                        scrollMeshLast = scrollIndicatorLast.GetComponent<MeshRenderer>();
                    }
                    else
                    {
                        scrollIndicatorLast = progressTracker.transform.GetChild(71).gameObject;
                        scrollMeshLast = scrollIndicatorLast.GetComponent<MeshRenderer>();
                    }

                    scrollMesh.material = redMaterial;
                    scrollMeshLast.material = unlitMaterial;
                    scrollTimer = 0;
                    scrollCounter++;
                }
            }
            else
            {
                scrollCounter = progressCount;
            }
        }

        if (progressCount >= progressMax)
        {
            Win();
        }
    }

    public void Win()
    {

    }
}
