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
            ClearChange();
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
    private void SetText(Text text, float value)
    {
        text.text = ValueToPercentString(value);
    }

    private void SetAudioQuestions()
    {
        float value = PlayerData.Instance.GetAudioQuestionsVolume();
        audioQuestionsSlider.value = value;
        SetText(audioQuestionsValueText, value);

        audioQuestionsSlider.onValueChanged.AddListener(v => { SetText(audioQuestionsValueText, v); });
        audioQuestionsSlider.onValueChanged.AddListener(SetSettingsChanged);
        audioQuestionsSlider.onValueChanged.AddListener(AudioManager.Instance.NarratorVolumeChange);
        
    }
    
    private void SetSFX()
    {
        float value = PlayerData.Instance.GetSFXVolume();
        sfxSlider.value = value;
        SetText(sfxValueText, value);

        sfxSlider.onValueChanged.AddListener(v => { SetText(sfxValueText, v); });
        sfxSlider.onValueChanged.AddListener(SetSettingsChanged);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SFXVolumeChange);
    }

    private void SetBackgroundMusic()
    {
        float value = PlayerData.Instance.GetBgMusicVolume();
        backgroundMusicSlider.value = value;
        SetText(backgroundMusicValueText, value);

        backgroundMusicSlider.onValueChanged.AddListener(v => { SetText(backgroundMusicValueText, v); });
        backgroundMusicSlider.onValueChanged.AddListener(SetSettingsChanged);
        backgroundMusicSlider.onValueChanged.AddListener(AudioManager.Instance.BackgroundVolumeChange);
        
    }

    private string ValueToPercentString(float value)
    {
        float valueInPercents = Mathf.Round(value * 100);
        return valueInPercents.ToString() + "%";
    }
    
    public override void DiscardChanges()
    {
        backgroundMusicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
        audioQuestionsSlider.onValueChanged.RemoveAllListeners();

        InitalizeSettings();
    }

    public void SetSettingsChanged(float value)
    {
        isSettingsChanged = true;
    }
    public override bool IsSettingsChanged()
    {
        return isSettingsChanged;
    }

    public override void ClearChange()
    {
        isSettingsChanged = false;
    }
}
