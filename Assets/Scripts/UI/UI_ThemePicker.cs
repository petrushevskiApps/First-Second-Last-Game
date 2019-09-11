using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ThemePicker : IPopup
{
    [SerializeField] private Button themeAnimals;
    [SerializeField] private Button themeToys;
    [SerializeField] private Button themeFruits;
    [SerializeField] private Button back;

    private void Awake()
    {
        themeFruits.onClick.AddListener(() => { OnThemeSelected(0); });
        themeToys.onClick.AddListener(() => { OnThemeSelected(1); });
        themeAnimals.onClick.AddListener(() => { OnThemeSelected(2); });

        back.onClick.AddListener(Disagree);
    }

    private void OnEnable()
    {
        fader.SetActive(true);
    }

    private void SetTheme(int themeIndex)
    {
        GameManager.Instance.SetThemeIndex(themeIndex);
        ClosePopup();
        Callback();
    }
    public override void Agree()
    {
        throw new System.NotImplementedException();
    }

    public override void Disagree()
    {
        AudioManager.Instance.PlayUIInteraction();
        ClosePopup();
        UI_Manager.Instance.ShowMainScreen();
    }

    private void OnThemeSelected(int index)
    {
        AudioManager.Instance.PlayUIInteraction();
        SetTheme(index);
    }
    public override void OnBackButtonPressed()
    {
        Disagree();
    }
}
