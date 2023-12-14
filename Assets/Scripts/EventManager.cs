using System;


public static class EventManager
{
    
    public static event Action<int> CollectablesCollected;
    public static event Action<GameState, GameState> GameStateChanged;

    public static event Action TutorialClosed;
    public static event Action TutorialOpened;
    public static event Action Tutorial2Closed;
    public static event Action Tutorial2Opened;
    public static event Action CheatSheetOpened;
    public static event Action CheatSheetClosed;
    public static event Action NewGameStartApproved;
    public static event Action StartHeistButtonClicked;
    public static event Action MainMenuButtonClicked;
    public static event Action ContinueButtonClicked;
    public static event Action RetryLevel;
    public static event Action NextLevel;
    public static event Action Quit;
    public static event Action GameFailed;
    public static event Action GameWon;
    public static event Action NewGameStart;
    public static event Action BallArrivedToFinish;
    public static event Action<float> GameSoundChanged;
    public static event Action<float> MusicSoundChanged;
    
    public static event Action<int> LevelCreated;
    
    
    
    
    public static void RaiseOnCollectablesCollected(int money)
    {
        CollectablesCollected?.Invoke(money);
    }

    public static void RaiseOnNewGameStart()
    {
        NewGameStart?.Invoke();
    }
    
    public static void RaiseOnGameStateChanged(GameState oldState, GameState newState)
    {
        GameStateChanged?.Invoke(oldState, newState);
    }
    
    public static void RaiseOnGameFailed()
    {
        GameFailed?.Invoke();
    }
    
    public static void RaiseGameWon()
    {
        GameWon?.Invoke();
    }
    
    public static void RaiseGameStartHeistButtonClicked()
    {
        StartHeistButtonClicked?.Invoke();
    }
    

    public static void RaiseMainMenuButtonClicked()
    {
        MainMenuButtonClicked?.Invoke();
    }

    public static void RaiseRetryLevel()
    {
        RetryLevel?.Invoke();
    }

    public static void RaiseNextLevel()
    {
        NextLevel?.Invoke();
    }

    public static void RaiseQuit()
    {
        Quit?.Invoke();
    }

    public static void RaiseBallArrivedToFinish()
    {
        BallArrivedToFinish?.Invoke();
    }

    public static void RaiseLevelCreated(int requiredMoneyForWin)
    {
        LevelCreated?.Invoke(requiredMoneyForWin);
    }

    public static void RaiseGameSoundChanged(float value)
    {
        GameSoundChanged?.Invoke(value);
    }

    public static void RaiseMusicSoundChanged(float value)
    {
        MusicSoundChanged?.Invoke(value);
    }

    public static void RaiseContinueButtonClicked()
    {
        ContinueButtonClicked?.Invoke();
    }

    public static void RaiseNewGameStartApproved()
    {
        NewGameStartApproved?.Invoke();
    }

    public static void RaiseCheatSheetOpened()
    {
        CheatSheetOpened?.Invoke();
    }

    public static void RaiseCheatSheetClosed()
    {
        CheatSheetClosed?.Invoke();
    }

    public static void RaiseTutorialOpened()
    {
        TutorialOpened?.Invoke();
    }

    public static void RaiseTutorialClosed()
    {
        TutorialClosed?.Invoke();
    }

    public static void RaiseTutorial2Closed()
    {
        Tutorial2Closed?.Invoke();
        
    }

    public static void RaiseTutorial2Opened()
    {
        Tutorial2Opened?.Invoke();
    }
}
