using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DefaultNamespace.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class SettingsPanelScript : UIPanel
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Slider gameSoundSlider;
        [SerializeField] private Slider musicSoundSlider;
        [SerializeField] private TextMeshProUGUI gameSoundValueText;
        [SerializeField] private TextMeshProUGUI musicSoundValueText;


        void Start()
        {
            mainMenuButton.onClick.AddListener(MainMenuButtonClicked);
            gameSoundSlider.onValueChanged.AddListener(OnGameSoundValueChanged);
            musicSoundSlider.onValueChanged.AddListener(OnMusicSoundValueChanged);
        }

        private void OnMusicSoundValueChanged(float value)
        {
            value = value * 100;
            musicSoundValueText.text = "%" + value.ToString("#.");
            EventManager.RaiseMusicSoundChanged(value);
        }

        private void OnGameSoundValueChanged(float value)
        {
            value = value * 100;
            gameSoundValueText.text = "%" + value.ToString("#.");
            EventManager.RaiseGameSoundChanged(value);
        }

        private void MainMenuButtonClicked()
        {
            EventManager.RaiseMainMenuButtonClicked();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
