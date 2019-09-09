using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelComplete : IPopup
{
    [SerializeField] private Button back;
    [SerializeField] private Button play;

    private void Awake()
    {
        back.onClick.AddListener(Disagree);
        play.onClick.AddListener(Agree);
    }
    private void OnEnable()
    {
        fader.SetActive(true);
    }

    public override void Agree()
    {
        AudioManager.Instance.PlayUIInteraction();
        ClosePopup();
        Callback();
    }

    public override void Disagree()
    {
        AudioManager.Instance.PlayUIInteraction();
        GameManager.Instance.LevelExited();
        ClosePopup();
    }
}
