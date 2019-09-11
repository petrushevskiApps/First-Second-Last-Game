using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : IPopup
{
    [SerializeField] private List<Sprite> ticks;
    [SerializeField] private Image timerImage;

    private int timer;

    private void OnEnable()
    {
        timer = 1;
        SetTimerSprite(2);
        Invoke("TimerTick", 1f);
        fader.SetActive(true);

    }
    public void TimerDone()
    {
        Callback();
        ClosePopup();
    }
    
    private void TimerTick()
    {
        if (timer >= 0)
        {
            SetTimerSprite(timer);
            timer--;
            Invoke("TimerTick", 1f);
            
        }
        else
        {
            TimerDone();
        }
        AudioManager.Instance.PlayTimerTick();
    }
    private void SetTimerSprite(int timer)
    {
        timerImage.sprite = ticks[timer];
    }
    public override void Agree()
    {
        throw new System.NotImplementedException();
    }
    public override void Disagree()
    {
        throw new System.NotImplementedException();
    }
    public override void OnBackButtonPressed()
    {
        Disagree();
    }
}
