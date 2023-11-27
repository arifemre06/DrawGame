using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class InGamePanelScript : UIPanel
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button retryButton;

        private int money = 0;

        private int _requiredMoneyForWin = 0;
        // Start is called before the first frame update
        void Start()
        {   
            EventManager.CollectablesCollected += OnMoneyChangedUpdateGoldText;
            EventManager.LevelCreated += OnLevelCreatedLearnRequiredMoneyForWin;
            goldText.text = money.ToString() + "$";
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            retryButton.onClick.AddListener(OnRetryButtonClicked);
        }

        private void OnDestroy()
        {
            EventManager.CollectablesCollected -= OnMoneyChangedUpdateGoldText;
            EventManager.LevelCreated -= OnLevelCreatedLearnRequiredMoneyForWin;
        }

        private void OnLevelCreatedLearnRequiredMoneyForWin(int requiredMoney)
        {
            _requiredMoneyForWin = requiredMoney;
            goldText.text = "/" + _requiredMoneyForWin + "$";
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnRetryButtonClicked()
        {
            EventManager.RaiseRetryLevel();
        }

        private void OnMainMenuButtonClicked()
        {
            EventManager.RaiseMainMenuButtonClicked();
        }

        void OnMoneyChangedUpdateGoldText(int gainedMoney)
        {
            money += gainedMoney;
            
            goldText.text = money.ToString() + "$/" + _requiredMoneyForWin + "$";
        }

    }
}