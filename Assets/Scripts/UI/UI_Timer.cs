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
        timer = 2;
        TimerTick();
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
            timerImage.sprite = ticks[timer];
            timer--;
            Invoke("TimerTick", 1f);
        }
        else
        {
            TimerDone();
        }
    }

    public override void Agree()
    {
        throw new System.NotImplementedException();
    }
    public override void Disagree()
    {
        throw new System.NotImplementedException();
    }
}
