using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.UI;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{   
    
    [SerializeField] private UIPanel drawPhasePanel;
    [SerializeField] private UIPanel inGamePanel;
    [SerializeField] private UIPanel mainMenuPanel;
    [SerializeField] private UIPanel gameFailedPanel;
    [SerializeField] private UIPanel gameWonPanel;
    [SerializeField] private UIPanel settingsPanel;
    
    private void Awake()
    {
        EventManager.GameStateChanged += OnGameStateChanged;
        DeActivateAllPanels();
            
    }

    private void OnDestroy()
    {
        EventManager.GameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState oldState, GameState newState)
    {   
        
        DeActivateAllPanels();
        if (newState == GameState.MainMenu)
        {

            ActivateMainMenuPanel();
        }
        else if (newState == GameState.DrawPhase)
        {

            ActivateDrawPhasePanel();

        }
        else if (newState == GameState.InGameMenu)
        {
            ActivateInGamePanel();
        }
        else if (newState == GameState.GameFailed)
        {

            ActivateGameFailedPanel();
        }
        else if (newState == GameState.GameWon)
        {   
                
            ActivateGameWonPanel();
        }
        else if (newState == GameState.Settings)
        {
            ActivateSettingsPanel();
        }
    }

    private void DeActivateAllPanels()
    {   
        
        mainMenuPanel.DeActivatePanel();
        drawPhasePanel.DeActivatePanel();
        inGamePanel.DeActivatePanel();
        gameFailedPanel.DeActivatePanel();
        gameWonPanel.DeActivatePanel();
        settingsPanel.DeActivatePanel();
    }

    private void ActivateSettingsPanel()
    {
        settingsPanel.ActivatePanel();
    }
    private void ActivateMainMenuPanel()
    {
        mainMenuPanel.ActivatePanel();
    }
    private void ActivateDrawPhasePanel()
    {
        drawPhasePanel.ActivatePanel();
    }

    private void ActivateInGamePanel()
    {
        inGamePanel.ActivatePanel();
    }
    
    private void ActivateGameFailedPanel()
    {
        gameFailedPanel.ActivatePanel();
    }

    private void ActivateGameWonPanel()
    {
        gameWonPanel.ActivatePanel();
    }
}
