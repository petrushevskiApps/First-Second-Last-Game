using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : IScreen
{
    public override void OnBackButtonPressed()
    {
        GameManager.Instance.LevelPaused();
    }
}
