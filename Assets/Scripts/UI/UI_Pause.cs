using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pause : IPopup
{

    [SerializeField] private Button exitLevel;
    [SerializeField] private Button continuePlaying;

    private void Awake()
    {
        exitLevel.onClick.AddListener(Disagree);
        continuePlaying.onClick.AddListener(Agree);
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
        Callback();
    }
}
