using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Discard : IPopup
{
    [SerializeField] private Button agree;
    [SerializeField] private Button disagree;

    private void Awake()
    {
        agree.onClick.AddListener(Agree);
        disagree.onClick.AddListener(Disagree);
    }
    private void OnEnable()
    {
        fader.SetActive(true);
    }
    public override void Agree()
    {
        AudioManager.Instance.PlayUIInteraction();
        Callback();
        ClosePopup();
        UI_Manager.Instance.ShowMainScreen();
    }

    public override void Disagree()
    {
        AudioManager.Instance.PlayUIInteraction();
        ClosePopup();
    }

    public override void OnBackButtonPressed()
    {
        Disagree();
    }
}
