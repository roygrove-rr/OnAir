using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject settingsMenuCanvas;

    public void ShowMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        settingsMenuCanvas.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        mainMenuCanvas.SetActive(false);
        settingsMenuCanvas.SetActive(true);
    }

    
}
