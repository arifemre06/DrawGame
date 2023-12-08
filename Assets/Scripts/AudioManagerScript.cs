using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] private AudioSource collecting;
    [SerializeField] private AudioSource gameWon;
    [SerializeField] private AudioSource gameFailed;
    [SerializeField] private AudioSource backGroundMusic;
    private const float FirstSessionMusicVolume = 1;
    private const float FirstSessionGameSoundVolume = 1;

    private void Awake()
    {
        EventManager.StartHeistButtonClicked += PlayBackGroundAudio;
        EventManager.GameWon += PlayGameWonAudio;
        EventManager.GameFailed += PlayGameFailedAudio;
        EventManager.CollectablesCollected += PlayCollectablesCollectedAudio;
        EventManager.GameSoundChanged += OnGameSoundValueChanged;
        EventManager.MusicSoundChanged += OnMusicSoundValueChanged;


        int isFirstSession = PlayerPrefs.GetInt("IsFirstSession");
        if (isFirstSession == 0)
        {
            SetGameVolume(FirstSessionGameSoundVolume);
            backGroundMusic.volume = FirstSessionMusicVolume;
            PlayerPrefs.SetInt("IsFirstSession", 1);
            PlayerPrefs.SetFloat("MusicVolume", FirstSessionMusicVolume);
            PlayerPrefs.SetFloat("GameSoundVolume", FirstSessionGameSoundVolume);
        }
        else
        {
            SetGameVolume(PlayerPrefs.GetFloat("GameSoundVolume"));
            backGroundMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }

    private void OnDestroy()
    {
        EventManager.StartHeistButtonClicked -= PlayBackGroundAudio;
        EventManager.GameWon -= PlayGameWonAudio;
        EventManager.GameFailed -= PlayGameFailedAudio;
        EventManager.CollectablesCollected -= PlayCollectablesCollectedAudio;
        EventManager.GameSoundChanged -= OnGameSoundValueChanged;
        EventManager.MusicSoundChanged -= OnMusicSoundValueChanged;
    }

    private void OnMusicSoundValueChanged(float value)
    {
        backGroundMusic.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void OnGameSoundValueChanged(float value)
    {
        SetGameVolume(value);
        PlayerPrefs.SetFloat("GameSoundVolume", value);
    }

    private void PlayCollectablesCollectedAudio(int obj)
    {
        collecting.Play();
    }

    private void PlayGameFailedAudio()
    {
        gameFailed.Play();
    }

    private void PlayGameWonAudio()
    {
        gameWon.Play();
    }

    private void PlayBackGroundAudio()
    {
        backGroundMusic.Play();
    }

    private void SetGameVolume(float value)
    {
        gameFailed.volume = value;
        gameWon.volume = value;
        collecting.volume = value;
    }
}
