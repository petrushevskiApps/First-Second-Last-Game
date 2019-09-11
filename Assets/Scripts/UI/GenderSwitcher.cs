using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenderSwitcher : ISettings
{
    private const string SETTINGS_KEY = "GenderSettings";

    [SerializeField] private GameObject gSwitchMale;
    [SerializeField] private GameObject gSwitchFemale;

    private Toggle maleToggle;
    private Toggle femaleToggle;

    private void Awake()
    {
        InitalizeSettings();
    }
    private void InitalizeSettings()
    {
        maleToggle = gSwitchMale.GetComponent<Toggle>();
        femaleToggle = gSwitchFemale.GetComponent<Toggle>();

        maleToggle.onValueChanged.AddListener(SwitchMale);
        femaleToggle.onValueChanged.AddListener(SwitchFemale);

        SetSelection();
    }
    private void SwitchFemale(bool isOn)
    {
        if(isOn && maleToggle.isOn)
        {
            maleToggle.isOn = false;
        }
    }
    private void SwitchMale(bool isOn)
    {
        if (isOn && femaleToggle.isOn)
        {
            femaleToggle.isOn = false;
        }
    }

    private void SetSelection()
    {

        if (PlayerData.Instance.GetGender() == 1)
        {
            maleToggle.isOn = true;
        }
        else femaleToggle.isOn = true;
    }

    public override void SaveSettings()
    {
        int gender = maleToggle.isOn ? 1 : 2;
        PlayerData.Instance.SaveGender(gender);
    }

    public override void DiscardChanges()
    {
        InitalizeSettings();
    }

    public override bool IsSettingsChanged()
    {
        return false;
    }

    public override void ClearChange()
    {
        throw new NotImplementedException();
    }
}
