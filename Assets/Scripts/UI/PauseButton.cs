using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Button pause;

    private void Awake()
    {
        pause.onClick.AddListener(OnPauseClicked);
    }
    private void OnPauseClicked()
    {
        AudioManager.Instance.PlayUIInteraction();
        GameManager.Instance.LevelPaused();
    }
}
