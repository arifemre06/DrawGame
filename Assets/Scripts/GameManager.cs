using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _money = 0;
    private int _requiredMoneyForWin;
    private int _levelIndex = 0;
    [SerializeField] private LevelManagerScript levelManager;
    [SerializeField] private DrawManagerScript drawManager;

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
        EventManager.NewGameStart += OnNewGameStart;
        EventManager.BallArrivedToFinish += OnBallArrivedToFinish;
        EventManager.LevelCreated += OnLevelCreated;
        EventManager.CollectablesCollected += UpdateMoneyWhenCollectablesCollected;
        EventManager.ContinueButtonClicked += OnContinueButtonClicked;
        EventManager.NewGameStartApproved += OnNewGameStartApproved;
        EventManager.CheatSheetOpened += OnCheatSheetOpened;
        EventManager.CheatSheetClosed += OnCheatSheetClosed;
        EventManager.TutorialOpened += OnTutorialOpened;
        EventManager.TutorialClosed += OnTutorialClosed;
        EventManager.Tutorial2Opened += OnTutorial2Opened;
      
        gameState = GameState.None;
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
        EventManager.NewGameStart -= OnNewGameStart;
        EventManager.BallArrivedToFinish -= OnBallArrivedToFinish;
        EventManager.LevelCreated -= OnLevelCreated;
        EventManager.CollectablesCollected -= UpdateMoneyWhenCollectablesCollected;
        EventManager.ContinueButtonClicked -= OnContinueButtonClicked;
        EventManager.NewGameStartApproved -= OnNewGameStartApproved;
        EventManager.CheatSheetOpened -= OnCheatSheetOpened;
        EventManager.CheatSheetClosed -= OnCheatSheetClosed;
        EventManager.TutorialOpened -= OnTutorialOpened;
        EventManager.TutorialClosed -= OnTutorialClosed;
        EventManager.Tutorial2Opened -= OnTutorial2Opened;
    }

    private void OnTutorial2Opened()
    {
        ChangeGameState(GameState.Tutorial2);
    }

    private void OnTutorialClosed()
    {
        ChangeGameState(GameState.MainMenu);
    }

    private void OnTutorialOpened()
    {
        ChangeGameState(GameState.Tutorial);
    }

    private void OnCheatSheetClosed()
    {
        ChangeGameState(GameState.DrawPhase);
        Time.timeScale = 1;
    }

    private void OnCheatSheetOpened()
    {   
        ChangeGameState(GameState.CheatSheet);
        Time.timeScale = 0;
    }

    private void OnNewGameStartApproved()
    {
        _levelIndex = 0;
        PlayerPrefs.SetInt("levelIndex",0);
        CreateLevel();
        ChangeGameState(GameState.DrawPhase);
    }

    private void OnContinueButtonClicked()
    {   
        _levelIndex = PlayerPrefs.GetInt("levelIndex");
        CreateLevel();
        ChangeGameState(GameState.DrawPhase);
    }

    private void OnLevelCreated(int requiredMoney)
    {
        _requiredMoneyForWin = requiredMoney;
    }

    private void OnBallArrivedToFinish()
    {
        if (_money >= _requiredMoneyForWin)
        {
            EventManager.RaiseGameWon();
        }
        else
        {
            EventManager.RaiseOnGameFailed();
        }
    }

    private void OnNewGameStart()
    {
        if (_levelIndex > 0)
        {
            ChangeGameState(GameState.AreYouSure);
        }
        else
        {
            _levelIndex = 0;
            CreateLevel();
            ChangeGameState(GameState.DrawPhase);
        }
    }

    private void Start()
    {
        _levelIndex = PlayerPrefs.GetInt("levelIndex");
        OnMainMenuButtonClicked();
    }

    private void UpdateMoneyWhenCollectablesCollected(int gainedmoney)
    {
        _money += gainedmoney;
        Debug.Log(_money);
    }
    
    private void OnArrivedToFinish()
    {   
        drawManager.DestroyAllLines();
        ChangeGameState(GameState.GameWon);
        
    }

    private void OnMainMenuButtonClicked()
    {
        drawManager.DestroyAllLines();
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
        drawManager.DestroyAllLines();
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
        _levelIndex = PlayerPrefs.GetInt("levelIndex");
        CreateLevel();
    }

    private void CreateLevel()
    {   
        drawManager.DestroyAllLines();
        levelManager.PrepareCurrentLevel(_levelIndex);

    }

    private void OnGameFailed()
    {   
        drawManager.DestroyAllLines();
        Time.timeScale = 0;
        ChangeGameState(GameState.GameFailed);
    }
    
    private void ChangeGameState(GameState newState)
    {
        EventManager.RaiseOnCollectablesCollected(-_money);
        var oldState = gameState;
        Debug.Log($"changing to state {oldState} - {newState}");
        gameState = newState;
        EventManager.RaiseOnGameStateChanged(oldState, newState);
    }
    
    
    private void OnStartHeistButtonClicked()
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
    Settings,
    AreYouSure,
    CheatSheet,
    Tutorial,
    Tutorial2

}
