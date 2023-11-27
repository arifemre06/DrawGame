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
    void Awake()
    {
        EventManager.StartHeistButtonClicked += PlayBackGroundAudio;
        EventManager.GameWon += PlayGameWonAudio;
        EventManager.GameFailed += PlayGameFailedAudio;
        EventManager.CollectablesCollected += PlayCollectablesCollectedAudio;
        EventManager.GameSoundChanged += OnGameSoundValueChanged;
        EventManager.MusicSoundChanged += OnMusicSoundValueChanged;
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
    }

    private void OnGameSoundValueChanged(float value)
    {
        gameFailed.volume = value;
        gameWon.volume = value;
        collecting.volume = value;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
