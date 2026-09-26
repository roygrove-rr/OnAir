using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SensitivityController : MonoBehaviour
{
    public Slider sensitivitySlider;
    private MouseLookScript mouseLook;

    private void Start()
    {
        // Only apply sensitivity in gameplay scenes
        if (SceneManager.GetActiveScene().name != "studio_decorating")
        {
            Debug.Log("SensitivityController: No MouseLookScript in this scene.");
            return;
        }

        mouseLook = FindObjectOfType<MouseLookScript>();

        if (mouseLook == null)
        {
            Debug.LogError("MouseLookScript not found in the loaded scenes!");
            return;
        }

        float savedSensitivity = PlayerPrefs.GetFloat("Sensitivity", 100f);
        sensitivitySlider.value = savedSensitivity;
        SetSensitivity(savedSensitivity);
    }

    public void SetSensitivity(float value)
    {
        if (mouseLook != null)
        {
            mouseLook.mouseSensitivity = value;
            PlayerPrefs.SetFloat("Sensitivity", value);
        }
    }
}
