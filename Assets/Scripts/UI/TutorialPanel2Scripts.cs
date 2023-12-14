using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class TutorialPanel2Scripts : UIPanel
    {
        [SerializeField] private Button close;
        [SerializeField] private Button previousPage;
        void Awake()
        {
            close.onClick.AddListener(OnCloseClicked);
            previousPage.onClick.AddListener(OnPreviousPageClicked);
        }

        private void OnPreviousPageClicked()
        {
            EventManager.RaiseTutorialOpened();
        }

        private void OnCloseClicked()
        {
            EventManager.RaiseTutorialClosed();
        }
        
    }
}
