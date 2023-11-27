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
        void Start()
        {
            startHeistButton.onClick.AddListener(OnStartButtonClicked);
            resetButton.onClick.AddListener(OnResetButtonClicked);
            
        }

        private void OnResetButtonClicked()
        {
            //bi bakmak gerekebilir
            EventManager.RaiseRetryLevel();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnStartButtonClicked()
        {
            EventManager.RaiseGameStartHeistButtonClicked();
        }
    }
}