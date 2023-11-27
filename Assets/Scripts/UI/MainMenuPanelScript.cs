using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class MainMenuPanelScript : UIPanel
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button settingsButton;
        void Start()
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
            quitButton.onClick.AddListener(OnQuitButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsClicked);
        }

        private void OnSettingsClicked()
        {
            EventManager.RaiseOnGameStateChanged(GameState.MainMenu,GameState.Settings);
        }


        void Update()
        {
            
        }

        private void OnQuitButtonClicked()
        {
            EventManager.RaiseQuit();
        }

        private void OnStartButtonClicked()
        {
            EventManager.RaiseOnGameStart();
        }
    }
}