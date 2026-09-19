using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        MainMenu,
        Gameplay,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Start()
    {
        UpdateState(GameState.MainMenu);
    }

    public void Update()
    {
        PauseUnpause();
    }

    public void UpdateState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;

            case GameState.Gameplay:
                HandleGameplay();
                break;

            case GameState.Paused:
                HandlePaused();
                break;

            case GameState.GameOver:
                HandleGameOver();
                break;
        }
    }

    private void HandleMainMenu()
    {
        Time.timeScale = 1f;
    }

    private void HandleGameplay()
    {
        Time.timeScale = 1f;
    }

    private void HandlePaused()
    {
        Time.timeScale = 0f;
    }

    private void HandleGameOver()
    {
        Time.timeScale = 1f;
    }

    // Public functions available to all scripts go here
    public void PauseUnpause()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CurrentState == GameState.Gameplay)
            {
                CurrentState = GameState.Paused;
            }
            else if (CurrentState == GameState.Paused)
            {
                CurrentState = GameState.Gameplay;
            }
        }
    }

    public void RestartGame()
    {
        UpdateState(GameState.Gameplay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
