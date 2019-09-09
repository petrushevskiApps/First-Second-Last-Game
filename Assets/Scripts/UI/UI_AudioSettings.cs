using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AudioSettings : ISettings
{

    [SerializeField] private Text backgroundMusicValueText;
    [SerializeField] private Text sfxValueText;
    [SerializeField] private Text audioQuestionsValueText;
     
    [SerializeField] private Slider backgroundMusicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider audioQuestionsSlider;

    private bool isSettingsChanged;

    public override void SaveSettings()
    {
        if(isSettingsChanged)
        {
            PlayerData.Instance.SaveBgMusicVolume(backgroundMusicSlider.value);
            PlayerData.Instance.SaveSFXVolume(sfxSlider.value);
            PlayerData.Instance.SaveAudioQuestionsVolume(audioQuestionsSlider.value);
        }
    }

    private void Awake()
    {
        InitalizeSettings();
    }
    private void OnEnable()
    {
        isSettingsChanged = false;
    }
    private void InitalizeSettings()
    {
        SetBackgroundMusic();
        SetSFX();
        SetAudioQuestions();
    }
    private void SetAudioQuestions()
    {
        audioQuestionsSlider.onValueChanged.AddListener(SetAQuestionsText);
        audioQuestionsSlider.value = PlayerData.Instance.GetAudioQuestionsVolume();
        audioQuestionsSlider.onValueChanged.AddListener(AudioManager.Instance.NarratorVolumeChange);
        
    }
    private void SetAQuestionsText(float value)
    {
        audioQuestionsValueText.text = ValueToPercentString(value);
        SetSettingsChanged();
    }

    private void SetSFX()
    {
        sfxSlider.onValueChanged.AddListener(SetSFXText);
        sfxSlider.value = PlayerData.Instance.GetSFXVolume();
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SFXVolumeChange);
    }
    private void SetSFXText(float value)
    {
        sfxValueText.text = ValueToPercentString(value);
        SetSettingsChanged();
    }

    private void SetBackgroundMusic()
    {
        backgroundMusicSlider.onValueChanged.AddListener(SetBgMusicText);
        backgroundMusicSlider.value = PlayerData.Instance.GetBgMusicVolume();
        backgroundMusicSlider.onValueChanged.AddListener(AudioManager.Instance.BackgroundVolumeChange);
        
    }
    private void SetBgMusicText(float value)
    {
        backgroundMusicValueText.text = ValueToPercentString(value);
        SetSettingsChanged();
    }

    private string ValueToPercentString(float value)
    {
        float valueInPercents = Mathf.Round(value * 100);
        return valueInPercents.ToString() + "%";
    }
    
    public override void DiscardChanges()
    {
        InitalizeSettings();
    }

    public void SetSettingsChanged()
    {
        isSettingsChanged = true;
    }
    public override bool IsSettingsChanged()
    {
        return isSettingsChanged;
    }
}
