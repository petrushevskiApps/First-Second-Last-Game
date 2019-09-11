using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Narator : MonoBehaviour
{
   
    public NarratorCanvas narrator;
    public BubbleCanvas bubble;

    private bool isBubbleActive = false;

    private void Awake()
    {
        narrator.gameObject.SetActive(false);
        bubble.gameObject.SetActive(false);
        GameManager.Instance.levelManager.ShowNarrator += OnShowNarrator;
    }
    public void OnShowNarrator( )
    {
        int selection = GameManager.Instance.GetQuestion();
        CheckBubbleSettings();

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

        narrator.gameObject.SetActive(false);
        bubble.gameObject.SetActive(false);
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
