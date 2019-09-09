using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    [SerializeField] private Music audioFiles;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffects;
    [SerializeField] private AudioSource narrator;
    [SerializeField] private AudioSource uiInteraction; 

    private void Awake()
    {
        base.Awake();
        SetupUiInteractionAudio();
        SetupBackgroundMusic();
    }
    private void Update()
    {
        if(!backgroundMusic.isPlaying)
        {
            PlayBackgroundMusic();
        }
    }
    private void SetupUiInteractionAudio()
    {
        uiInteraction.clip = audioFiles.uiInteractionAudio;
        uiInteraction.volume = 0.5f;
    }
    private void SetupNarrator(AudioClip soundEffect)
    {
        narrator.clip = soundEffect;
        narrator.volume = PlayerData.Instance.GetAudioQuestionsVolume();
    }
    private void SetupSoundEffects(AudioClip soundEffect)
    {
        soundEffects.clip = soundEffect;
        soundEffects.volume = PlayerData.Instance.GetSFXVolume();
    }
    private void SetupBackgroundMusic()
    {
        OnVolumeChange(backgroundMusic, PlayerData.Instance.GetBgMusicVolume());
    }
    public void AddBackgroundSong() 
    {
        backgroundMusic.clip = audioFiles.backgroundSongs[UnityEngine.Random.Range(0, audioFiles.backgroundSongs.Count)];
    }
    public void PlayBackgroundMusic()
    {
        AddBackgroundSong();
        backgroundMusic.Play();
    }
    public void PlaySFX(bool pick)
    {
        if(pick)
        {
            SetupSoundEffects(audioFiles.rightChoiceSFX);
        }
        else
        {
            SetupSoundEffects(audioFiles.wrongChoiceSFX);
        }
        soundEffects.Play();
    }
    public void PlayNarrator(bool pick)
    {
        if (pick)
        {
            SetupNarrator(audioFiles.rightChoiceAudio);
        }
        else
        {
            SetupNarrator(audioFiles.wrongChoiceAudio);
        }
        narrator.Play();
    }
    public void PlayNarratorQuestion(int questionNo)
    {
        SetupNarrator(audioFiles.questionsAudio[questionNo]);
        narrator.Play();
    }

    public void PlayUIInteraction()
    {
        uiInteraction.Play();

    }

    #region On Audio Settings Change
    public void OnVolumeChange(AudioSource source, float value)
    {
        source.volume = value;
    }
    public void BackgroundVolumeChange(float value)
    {
        OnVolumeChange(backgroundMusic, value);
    }
    public void SFXVolumeChange(float value)
    {
        SetupSoundEffects(audioFiles.wrongChoiceSFX);
        OnVolumeChange(soundEffects, value);
        soundEffects.Play();
    }
    public void NarratorVolumeChange(float value)
    {
        SetupNarrator(audioFiles.rightChoiceAudio);
        OnVolumeChange(narrator, value);
        narrator.Play();
    }
    #endregion
}
