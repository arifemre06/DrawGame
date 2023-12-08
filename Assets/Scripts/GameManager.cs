using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int money = 0;
    private int requiredMoneyForWin;
    [SerializeField] private LevelManagerScript levelManager;
    [SerializeField] private DrawManagerScript _drawManager;

    public static GameState gameState{get; private set;}
    
    private void Awake()
    {
        EventManager.GameFailed += OnGameFailed;
        EventManager.StartHeistButtonClicked += OnStartHeistButtonClicked;
        EventManager.GameWon += OnArrivedToFinish;
        EventManager.RetryLevel += OnRetry;
        EventManager.NextLevel += OnNextLevel;
        EventManager.Quit += OnQuit;
        EventManager.MainMenuButtonClicked += OnMainMenuButtonClicked;
        EventManager.GameStart += OnGameStart;
        EventManager.BallArrivedToFinish += OnBallArrivedToFinish;
        EventManager.LevelCreated += OnLevelCreated;
        EventManager.CollectablesCollected += UpdateMoneyWhenCollectablesCollected;
      
        gameState = GameState.None;
    }

    private void OnLevelCreated(int requiredMoney)
    {
        requiredMoneyForWin = requiredMoney;
    }

    private void OnBallArrivedToFinish()
    {
        if (money >= requiredMoneyForWin)
        {
            EventManager.RaiseGameWon();
        }
        else
        {
            EventManager.RaiseOnGameFailed();
        }
    }

    private void OnGameStart()
    {   
        CreateLevel();
        ChangeGameState(GameState.DrawPhase);
        
    }

    void Start()
    {
        
        OnMainMenuButtonClicked();
    }

    void UpdateMoneyWhenCollectablesCollected(int gainedmoney)
    {
        money += gainedmoney;
        Debug.Log(money);
    }

    private void OnDestroy()
    {
        EventManager.GameFailed -= OnGameFailed;
        EventManager.StartHeistButtonClicked -= OnStartHeistButtonClicked;
        EventManager.GameWon -= OnArrivedToFinish;
        EventManager.RetryLevel -= OnRetry;
        EventManager.NextLevel -= OnNextLevel;
        EventManager.Quit -= OnQuit;
        EventManager.MainMenuButtonClicked -= OnMainMenuButtonClicked;
        EventManager.GameStart -= OnGameStart;
        EventManager.BallArrivedToFinish -= OnBallArrivedToFinish;
        EventManager.LevelCreated -= OnLevelCreated;
        EventManager.CollectablesCollected -= UpdateMoneyWhenCollectablesCollected;
    }

    private void OnArrivedToFinish()
    {   
        _drawManager.DestroyAllLines();
        ChangeGameState(GameState.GameWon);
        
    }

    private void OnMainMenuButtonClicked()
    {
        _drawManager.DestroyAllLines();
        //CreateLevel();
        ChangeGameState(GameState.MainMenu);
        Time.timeScale = 1;
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    private void OnNextLevel()
    {   
        _drawManager.DestroyAllLines();
        IncreaseLevelIndexAndCreateNextLevel();
        ChangeGameState(GameState.DrawPhase);
    }
    

    private void OnRetry()
    {
        CreateLevel();
        ChangeGameState(GameState.DrawPhase);
    }

    private void IncreaseLevelIndexAndCreateNextLevel()
    {
        levelManager.SetLevelIndexToNextLevel();
        CreateLevel();
    }

    private void CreateLevel()
    {   
        _drawManager.DestroyAllLines();
        levelManager.PrepareCurrentLevel();
        //playerManager = levelManager.GetPlayerManager();
        
    }

    private void OnGameFailed()
    {   
        _drawManager.DestroyAllLines();
        Time.timeScale = 0;
        ChangeGameState(GameState.GameFailed);
    }
    
    private void ChangeGameState(GameState newState)
    {
        EventManager.RaiseOnCollectablesCollected(-money);
        var oldState = gameState;
        Debug.Log($"changing to state {oldState} - {newState}");
        gameState = newState;
        EventManager.RaiseOnGameStateChanged(oldState, newState);
    }
    
    /*
    private void StartGamePlay()
    {
        Time.timeScale = 1;
        ChangeGameState(GameState.Gameplay);
        playerManager.StartGame();
    }
    */
    
    public void OnStartHeistButtonClicked()
    {
        ChangeGameState(GameState.InGameMenu);
        Time.timeScale = 1;
    }
}

public enum GameState
{   
    None,
    MainMenu,
    DrawPhase,
    InGameMenu,
    GameFailed,
    GameWon,
    Settings
    
}
