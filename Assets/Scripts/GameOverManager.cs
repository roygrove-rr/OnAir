using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOverManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject buttonsPanel;

    void Start()
    {
        buttonsPanel.SetActive(false);

        // When video finishes, call ShowButtons
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        buttonsPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Studio_decorating"); // your gameplay scene
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // your main menu scene
    }
}