using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        int targetWidth = 1920;
        int targetHeight = 1080;

        FullScreenMode screenMode = FullScreenMode.FullScreenWindow;
        Screen.SetResolution(targetWidth, targetHeight, screenMode);
    }
}
