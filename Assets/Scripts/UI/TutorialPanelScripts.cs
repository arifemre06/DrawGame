using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{   
    
    public class TutorialPanelScripts : UIPanel
    {   
        [SerializeField] private Button close;
        [SerializeField] private Button nextPage;
       
        private void Awake()
        {
            close.onClick.AddListener(OnCloseButtonClicked);
            nextPage.onClick.AddListener(OnNextPageClicked);
        }

        private void OnNextPageClicked()
        {
            EventManager.RaiseTutorial2Opened();
        }

        private void OnCloseButtonClicked()
        {
            EventManager.RaiseTutorialClosed();
        }
        
    }
}
