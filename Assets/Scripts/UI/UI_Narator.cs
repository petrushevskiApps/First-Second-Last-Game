using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Narator : IPopup
{
    public override void Agree()
    {
        throw new System.NotImplementedException();
    }

    public override void Disagree()
    {
        throw new System.NotImplementedException();
    }

    public NarratorCanvas narrator;
    public BubbleCanvas bubble;

    private bool isBubbleActive = false;

    private void OnEnable()
    {
        fader.SetActive(false);
        CheckBubbleSettings();
        Initialized(GameManager.Instance.GetQuestion());
    }

    public void Initialized(int selection)
    {
        narrator.InitializeNarratorAvatar(selection);
        if(isBubbleActive) bubble.InitializeQuestion(selection);
        GameManager.Instance.levelManager.OnPlayerPick += Show;
    }

    private void OnDisable()
    {
        LevelManager levelManager = GameManager.Instance.levelManager;
        if (levelManager != null)
        {
            levelManager.OnPlayerPick -= Show;
        }
    }

    public void Show(bool playerPick)  
    {
        if (playerPick)
        {
            narrator.RightAnswer();
            if (isBubbleActive) bubble.Animate(true);
        }
        else
        {
            narrator.WrongAnswer();
            if (isBubbleActive) bubble.Animate(false);
           
        }
        
    }

    private void CheckBubbleSettings()
    {
        isBubbleActive = PlayerData.Instance.GetVisualQuestions();
        bubble.gameObject.SetActive(isBubbleActive);
    }
}
