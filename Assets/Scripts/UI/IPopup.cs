using UnityEngine;
using System.Collections;
using System;

public abstract class IPopup : MonoBehaviour
{
    public abstract void Disagree();
    public abstract void Agree();
    public abstract void OnBackButtonPressed();

    [SerializeField] protected GameObject fader;
    protected Action Callback;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            OnBackButtonPressed();
        }
    }
    public void Initialize(Action callback)
    {
        this.Callback = callback;
    }
    public void ClosePopup()
    {
        gameObject.SetActive(false);
        fader.SetActive(false);
    }
}
