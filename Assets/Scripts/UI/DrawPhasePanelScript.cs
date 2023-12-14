using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class DrawPhasePanelScript : UIPanel
    {
        [SerializeField] private Button startHeistButton;
        [SerializeField] private Button resetButton;
        [SerializeField] private Button cheatSheetButton;
        [SerializeField] private TextMeshProUGUI requiredMoney;

        // Start is called before the first frame update
        private void Awake()
        {   
            EventManager.LevelCreated += OnLevelCreatedLearnRequiredMoneyForWin;
            startHeistButton.onClick.AddListener(OnStartButtonClicked);
            resetButton.onClick.AddListener(OnResetButtonClicked);
            cheatSheetButton.onClick.AddListener(OnCheatSheetClicked);
            
        }

        private void OnLevelCreatedLearnRequiredMoneyForWin(int obj)
        {
            requiredMoney.text = "0/" +obj.ToString() + "$";
        }

        private void OnDestroy()
        {
            EventManager.LevelCreated -= OnLevelCreatedLearnRequiredMoneyForWin;
        }
        

        private void OnCheatSheetClicked()
        {
            EventManager.RaiseCheatSheetOpened();
        }

        private void OnResetButtonClicked()
        {
            EventManager.RaiseRetryLevel();
          
        }

     

        private void OnStartButtonClicked()
        {
            EventManager.RaiseGameStartHeistButtonClicked();
        }
    }
}