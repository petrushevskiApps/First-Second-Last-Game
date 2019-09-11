using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GraphicsSettings : ISettings
{
    [SerializeField] private Text backgroundValueText;
    [SerializeField] private Text decorationValueText;
    [SerializeField] private Toggle vfxToggle;
    [SerializeField] private Toggle questionsToggle;
    [SerializeField] private Slider backgroundFader;
    [SerializeField] private Slider decorationFader;

    private Text currentValueText;
    private bool isSettingsChanged;

    public override void DiscardChanges()
    {
        InitalizeSettings();
    }

    public override void SaveSettings()
    {
        if(isSettingsChanged)
        {
            PlayerData.Instance.SaveVFX(vfxToggle.isOn);
            PlayerData.Instance.SaveBackgroundFader(backgroundFader.value);
            PlayerData.Instance.SaveDecorationFader(decorationFader.value);
            PlayerData.Instance.SaveTextQuestionsState(questionsToggle.isOn);
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
        vfxToggle.isOn = PlayerData.Instance.GetVFX();
        vfxToggle.onValueChanged.AddListener(SettingsChanged);
        vfxToggle.onValueChanged.AddListener((x) => { AudioManager.Instance.PlayUIInteraction(); });
        questionsToggle.isOn = PlayerData.Instance.GetVisualQuestions();

        backgroundFader.value = PlayerData.Instance.GetBackgroundFader();
        backgroundFader.onValueChanged.AddListener(OnBackgroundFadeChange);

        decorationFader.value = PlayerData.Instance.GetDecorationFader();
        decorationFader.onValueChanged.AddListener(OnDecorationFadeChange);

        SetBgValueText(backgroundFader.value);
        SetDecorationValueText(decorationFader.value);
    }
    private void SettingsChanged(bool value)
    {
        isSettingsChanged = true;
    }
    private void OnBackgroundFadeChange(float value)
    {
        GameManager.Instance.OnGraphicsBFade(value);
        SetBgValueText(value);
        SettingsChanged(true);
    }
    private void OnDecorationFadeChange(float value)
    {
        GameManager.Instance.OnGraphicsDFade(value);
        SetDecorationValueText(value);
        SettingsChanged(true);
    }

    private void SetBgValueText(float value)
    {
        backgroundValueText.text = GetValueToPercents(value) + "%";
    }
    private void SetDecorationValueText(float value)
    {
        decorationValueText.text = GetValueToPercents(value) + "%";
    }

    private string GetValueToPercents(float value)
    {
        return Mathf.Round(value * 100).ToString();
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
