using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public LevelManager levelManager { get; private set; }

    public Action OnGameStart = () => { };
    public Action OnGameEnd = () => { };
    public Action OnLevelExited = () => { };

    public Action<float> OnGraphicsBFade = (fade) => { };
    public Action<float> OnGraphicsDFade = (fade) => { };

    private GameObject panel;
    private GameObject timer;

    private GameObject buttons;
    private Button playAgainButton;
    private Button backButton;

    private GameObject bubble;
    private GameObject narrator;

    private int level = 0;
    private int maxLevel = 2;

    private int questionNumber = 1;
    private int themeIndex = 0;

    private void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }
    private void Start()
    {
        //AudioManager.Instance.PlayBackgroundMusic();
    }

    public void StartGame()
    {
        UI_Manager.Instance.ShowTimer(LevelStart);
    }
    public void LevelStart() 
    {
        OnGameStart();
        SelectQuestion();
        levelManager.StartLevel();
        UI_Manager.Instance.ShowGameScreen();
    }
    public void LevelComplete() 
    {
        OnGameEnd();
        UI_Manager.Instance.ShowLevelComplete(LevelStart);
        levelManager.ClearLevel();
    }
    public void LevelExited()
    {
        OnLevelExited();
        UI_Manager.Instance.ShowMainScreen();
        levelManager.ClearLevel();
        levelManager.ResetLevel();
    }
    public void LevelPaused()
    {
        Time.timeScale = 0f;
        UI_Manager.Instance.ShowPause(LevelUnPaused);
    }
    public void LevelUnPaused()
    {
        Time.timeScale = 1f;
    }
    private void SelectQuestion()
    {
        Debug.Log(" QUESTION NUMBER: " + questionNumber);
        questionNumber = UnityEngine.Random.Range(0, 3);
    }
    public int GetQuestion()
    {
        return questionNumber;
    }

    public void SetThemeIndex(int index)
    {
        themeIndex = index;
    }
    public int GetThemeIndex()
    {
        return themeIndex;
    }

    public void InitializeHelpMode(Transform position)
    {
        GetComponent<HelpMode>().Initialize(position);
    }
    public void StopHelpMode()
    {
        GetComponent<HelpMode>().StopHelpMode();
    }
}
