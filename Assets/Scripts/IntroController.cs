using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private UnityEngine.UI.RawImage displayImage;

    [Header("Video Clips")]
    [SerializeField] private VideoClip firstVideo;
    [SerializeField] private VideoClip secondVideo;

    [Header("Scene Transition")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private bool isWaitingForClick = false;
    private bool secondVideoStarted = false;

    void Start()
    {
        // 1. Hook into the event that fires when a video finishes playing
        videoPlayer.loopPointReached += OnVideoFinished;

        // 2. Start the first video
        PlayVideo(firstVideo);
    }

    void Update()
    {
        // 3. Listen for a mouse click or screen tap only when the first video ends
        if (isWaitingForClick && Input.GetMouseButtonDown(0))
        {
            isWaitingForClick = false;
            secondVideoStarted = true;
            PlayVideo(secondVideo);
        }
    }

    void PlayVideo(VideoClip clip)
    {
        if (clip == null) return;

        videoPlayer.clip = clip;
        videoPlayer.Prepare();

        // Wait until the video is prepared before showing it to avoid a green/black flash
        videoPlayer.prepareCompleted += (vp) => 
        {
            displayImage.texture = vp.texture;
            vp.Play();
        };
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // If the first video just finished, stop and wait for a user click
        if (!secondVideoStarted)
        {
            isWaitingForClick = true;
        }
        // If the second video just finished, move to the main menu
        else
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}