using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class GameWonPanelScript : UIPanel
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button mainMenuButton;
        private void Awake()
        {
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        }

        private void OnMainMenuClicked()
        {
            EventManager.RaiseMainMenuButtonClicked();
        }

        private void OnNextLevelClicked()
        {
            EventManager.RaiseNextLevel();
        }
    }
}
