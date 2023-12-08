using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class DrawPhasePanelScript : UIPanel
    {
        [SerializeField] private Button startHeistButton;
        [SerializeField] private Button resetButton;

        // Start is called before the first frame update
        private void Awake()
        {
            startHeistButton.onClick.AddListener(OnStartButtonClicked);
            resetButton.onClick.AddListener(OnResetButtonClicked);
            
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