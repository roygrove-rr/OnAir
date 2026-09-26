using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public MouseLookScript mouseLook;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        container.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
