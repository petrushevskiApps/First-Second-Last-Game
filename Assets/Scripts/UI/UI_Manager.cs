using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : Singleton<UI_Manager>
{

    [SerializeField] private List<IScreen> screens;
    [SerializeField] private List<IPopup> popups;

    private void Awake()
    {
        CloseAllScreens();
        CloseAllPopups();
        ShowMainScreen();
    }
    public void ShowSettingsScreen()
    {
        ShowScreen<UI_Settings>();
    }
    public void ShowMainScreen()
    {
        ShowScreen<UI_Menu>();
    }
    public void ShowGameScreen()
    {
        CloseAllScreens();
        CloseAllPopups();
        ShowScreen<GameScreen>();
    }

    private void CloseAllScreens()
    {
        foreach (IScreen c in screens)
        {
            c.gameObject.SetActive(false);
        }
    }
    private void CloseAllPopups()
    {
        foreach (IPopup p in popups)
        {
            p.gameObject.SetActive(false);
        }
    }
    private void ShowScreen<T>()
    {
        foreach (IScreen c in screens)
        {
            if (c.GetComponent<T>() != null)
            {
                c.gameObject.SetActive(true);
            }
            else c.gameObject.SetActive(false);
        }
    }

    private void ShowPopup<T>(Action callback = null) where T : IPopup
    {
        foreach (IPopup p in popups)
        {
            if (p.GetComponent<T>() != null)
            {
                p.gameObject.SetActive(true);

                if (callback != null)
                {
                    p.GetComponent<T>().Initialize(callback);
                }
            }
            else p.gameObject.SetActive(false);
        }
    }
    public void ShowSavePopup(Action callback)
    {
        ShowPopup<UI_Save>(callback);
    }
    public void ShowDiscardPopup(Action callback)
    {
        ShowPopup<UI_Discard>(callback);
    }
    public void ShowExitPopUp(Action callback)
    {
        ShowPopup<UI_Exit>(callback);
    }
    public void ShowTimer(Action callback)
    {
        CloseAllScreens();
        ShowPopup<UI_Timer>(callback);
    }
    public void ShowLevelComplete(Action callback)
    {
        CloseAllScreens();
        ShowPopup<UI_LevelComplete>(callback);
    }
    public void ShowPause(Action callback)
    {
        ShowPopup<UI_Pause>(callback);
    }
    public void ShowNotification(NotificationsData notificationData)
    {
        if(notificationData != null)
        {
            UI_Notification.data = notificationData;
            ShowPopup<UI_Notification>();
        }
    }
    public void ShowThemePicker(Action callback)
    {
        CloseAllScreens();
        ShowPopup<UI_ThemePicker>(callback);
    }
}
