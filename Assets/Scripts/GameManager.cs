using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game Manager code, this handles switching between game states. Generally do not touch this unless you need to add a publically available function.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;
    
    private void Awake()
    {
        {
            Instance = this;
        }
    }

    public Timer timerScript;
    
    private void Start()
    {
        UpdateGameState(GameState.Gameplay);
    }

    private void Update()
    {
        //Debug.Log(State);
    }


    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;

            case GameState.Tutorial:
                HandleTutorial();
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

            case GameState.GameWin:
                HandleGameWin();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMainMenu()
    {

    }

    private void HandleTutorial()
    {

    }


    private void HandleGameplay()
    {

    }

    private void HandlePaused()
    {

    }

    private void HandleGameOver()
    {

    }

    private void HandleGameWin()
    {

    }

    public void LightingMalfunction()
    {

    }
}

public enum GameState
{
    MainMenu,
    Tutorial,
    Gameplay,
    Paused,
    GameOver,
    GameWin
}
