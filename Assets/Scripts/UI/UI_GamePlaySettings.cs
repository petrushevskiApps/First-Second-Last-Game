using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePlaySettings : ISettings
{
    [SerializeField] private Dropdown speedSelector;
    [SerializeField] private Toggle audioQuestionsToggle;
    [SerializeField] private Toggle textQuestionsToggle;
    [SerializeField] private Toggle helpModeToggle;
    [SerializeField] private NotificationsData data;

    private bool isSettingsChanged;

    
    private void Awake()
    {
       
        InitalizeSettings();
    }

    

    private void OnEnable()
    {
        isSettingsChanged = false;
    }
    public override void DiscardChanges()
    {
        InitalizeSettings();
    }

    public override void SaveSettings()
    {
       if(isSettingsChanged)
        {
            PlayerData.Instance.SaveAudioQuestionsState(audioQuestionsToggle.isOn);
            PlayerData.Instance.SaveTextQuestionsState(textQuestionsToggle.isOn);
            PlayerData.Instance.SaveHelpModeState(helpModeToggle.isOn);
            PlayerData.Instance.SaveSpeedMode(speedSelector.value);
            ClearChange();
        }
    }
    private void InitalizeSettings()
    {
        audioQuestionsToggle.isOn = PlayerData.Instance.GetAudioQuestionsState();
        textQuestionsToggle.isOn = PlayerData.Instance.GetVisualQuestions();
        helpModeToggle.isOn = PlayerData.Instance.GetHelpModeState();
        speedSelector.value = PlayerData.Instance.GetSpeedMode();

        audioQuestionsToggle.onValueChanged.AddListener(AudioSwitchValidation);
        textQuestionsToggle.onValueChanged.AddListener(TextSwitchValidation);
        helpModeToggle.onValueChanged.AddListener((x)=> { SetSettingsChanged(); });
        speedSelector.onValueChanged.AddListener((x) => { SetSettingsChanged(); });
    }

    private void AudioSwitchValidation(bool value)
    {
        if(!value && !textQuestionsToggle.isOn)
        {
            audioQuestionsToggle.isOn = true;
            UI_Manager.Instance.ShowNotification(data);
        }
        SetSettingsChanged();
    }
    private void TextSwitchValidation(bool value)
    {
        if (!value && !audioQuestionsToggle.isOn)
        {
            textQuestionsToggle.isOn = true;
            UI_Manager.Instance.ShowNotification(data);
        }
        SetSettingsChanged();
    }

    public void SetSettingsChanged()
    {
        AudioManager.Instance.PlayUIInteraction();
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

