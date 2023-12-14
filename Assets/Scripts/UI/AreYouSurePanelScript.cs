using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DefaultNamespace.UI
{
    public class AreYouSurePanelScript : UIPanel
    {
        [SerializeField] private Button yes;
        [SerializeField] private Button no;
        void Start()
        {
            yes.onClick.AddListener(OnYesClicked);
            no.onClick.AddListener(OnNoClicked);
        }

        private void OnNoClicked()
        {
            EventManager.RaiseMainMenuButtonClicked();
        }

        private void OnYesClicked()
        {
            EventManager.RaiseNewGameStartApproved();
            
        }
        
    }
}
