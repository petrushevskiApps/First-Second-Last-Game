using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : IScreen
{

	public void OnPlayClicked()
    {
        Debug.Log("Play game!");
        AudioManager.Instance.PlayUIInteraction();
        UI_Manager.Instance.ShowThemePicker(GameManager.Instance.StartGame);
    }
    public void OnSettingsClicked()
    {
        AudioManager.Instance.PlayUIInteraction();
        UI_Manager.Instance.ShowSettingsScreen();
    }
    public void OnExitClicked()
    {
        AudioManager.Instance.PlayUIInteraction();
        UI_Manager.Instance.ShowExitPopUp(ExitGame);
    }
    private void ExitGame()
    {
        Debug.Log("Exit game!");
        Application.Quit();
    }
}
