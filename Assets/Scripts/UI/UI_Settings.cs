using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : IScreen
{
    [SerializeField] public List<ISettings> settings;

    [SerializeField] private Button save;
    [SerializeField] private Button discard;
    [SerializeField] private Button graphics;
    [SerializeField] private Button audio;
    [SerializeField] private Button gameplay;

    private void Awake()
    {
        AddButtonListeners();
    }
    private void OnEnable()
    {
        DisableAll();
        ShowSettings<UI_GamePlaySettings>();
    }
    private void AddButtonListeners()
    {
        save.onClick.AddListener(OnSaveClicked);
        discard.onClick.AddListener(OnDiscardClicked);
        graphics.onClick.AddListener(ShowSettings<UI_GraphicsSettings>);
        audio.onClick.AddListener(ShowSettings<UI_AudioSettings>);
        gameplay.onClick.AddListener(ShowSettings<UI_GamePlaySettings>);
    }

    private void DisableAll()
    {
        foreach (ISettings set in settings)
        {
            set.gameObject.SetActive(false);
        }
    }
    private void ShowSettings<T>() where T : ISettings
    {
        AudioManager.Instance.PlayUIInteraction();
        foreach (ISettings set in settings)
        {
            if (set.GetComponent<T>() != null)
            {
                set.gameObject.SetActive(true);
            }
            else set.gameObject.SetActive(false);
        }
    }
    private void OnDiscardClicked()
    {
        AudioManager.Instance.PlayUIInteraction();

        if (IsChangesAvailable())
        {
            UI_Manager.Instance.ShowDiscardPopup(DiscardSettings);
        }
        else GoBack();
    }
    private void OnSaveClicked()
    {
        AudioManager.Instance.PlayUIInteraction();

        if (IsChangesAvailable())
        {
            UI_Manager.Instance.ShowSavePopup(SaveSettings);
        }
        else GoBack();
        
    }
    private void DiscardSettings()
    {
        foreach (ISettings s in settings)
        {
            s.DiscardChanges();
        }
        GoBack();
    }

    private void SaveSettings()
    {
        foreach(ISettings s in settings)
        {
            s.SaveSettings();
        }
        GoBack();
    }

    private void GoBack()
    {
        UI_Manager.Instance.ShowMainScreen();
    }

    private bool IsChangesAvailable()
    {
        foreach (ISettings s in settings)
        {
            if (s.IsSettingsChanged()) return true;
        }
        return false;
    }

    public override void OnBackButtonPressed()
    {
        OnDiscardClicked();
    }
}
