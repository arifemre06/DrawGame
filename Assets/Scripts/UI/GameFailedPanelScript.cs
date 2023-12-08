using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class GameFailedPanelScript : UIPanel
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button retryButton;
        private void Awake()
        {
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            retryButton.onClick.AddListener(OnRetryButtonClicked);
        }


        private void OnRetryButtonClicked()
        {
            EventManager.RaiseRetryLevel();
        }

        private void OnMainMenuButtonClicked()
        {
            EventManager.RaiseMainMenuButtonClicked();
        }
    }
}
