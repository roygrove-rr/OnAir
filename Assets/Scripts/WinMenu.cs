using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class WinMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public CanvasGroup buttonsGroup;   // CanvasGroup on your buttons panel
    public float fadeDuration = 1.5f;  // how long the fade takes

    void Start()
    {
        // Start with buttons invisible
        buttonsGroup.alpha = 0f;
        buttonsGroup.interactable = false;
        buttonsGroup.blocksRaycasts = false;

        StartCoroutine(ShowButtonsHalfway());
    }

    IEnumerator ShowButtonsHalfway()
    {
        // Wait until video is prepared so we know its length
        while (!videoPlayer.isPrepared)
            yield return null;

        double halfTime = videoPlayer.length / 2.0;

        // Wait until halfway through the video
        yield return new WaitForSeconds((float)halfTime);

        // Fade in the buttons
        yield return StartCoroutine(FadeInButtons());
    }

    IEnumerator FadeInButtons()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            buttonsGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        buttonsGroup.alpha = 1f;
        buttonsGroup.interactable = true;
        buttonsGroup.blocksRaycasts = true;
    }

    // Button functions
    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
