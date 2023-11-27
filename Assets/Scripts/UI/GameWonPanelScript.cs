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
        void Start()
        {
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        }

        // Update is called once per frame
        void Update()
        {
            
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
