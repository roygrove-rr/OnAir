using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseLight : MonoBehaviour
{
    public MalfManager manager;
    public Material greenMat;
    public Material redMat;

    private MeshRenderer meshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Material[] materialsCopy = meshRenderer.materials;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.lightsBroken == true)
        {
            meshRenderer.materials[1] = redMat;
        }
        else
        {
            meshRenderer.materials[1] = greenMat;
        }
    }
}
