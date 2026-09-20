using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void HandleGameplay()
    {
        var malfunctionCounter = 0;
        
        switch (timerScript.section)
        {
            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            default:
                break;
        }
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
    Gameplay,
    Paused,
    GameOver,
    GameWin
}
