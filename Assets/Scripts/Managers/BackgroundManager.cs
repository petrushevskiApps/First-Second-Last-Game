using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    private const float FADE_50 = 0.5f;
    private const float FADE_OFF = 1f;

    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject leftTree;
    [SerializeField]
    private GameObject rightTree;
    [SerializeField]
    private GameObject background;

    private Color treeColor;
    private Color backgroundColor;

    private void Awake()
    {
        GameManager.Instance.OnGraphicsDFade += OnFadeDecoration;
        GameManager.Instance.OnGraphicsBFade += OnFadeBackground;

        treeColor = leftTree.GetComponent<Image>().color;
        backgroundColor = background.GetComponent<Image>().color;

        InitBackgroundColor();
        InitDecorationColor();
    }

    
    private void InitBackgroundColor()
    {
        backgroundColor.a = PlayerData.Instance.GetBackgroundFader();
        ApplyBackgroundColor();
    }
    private void InitDecorationColor()   
    {
        treeColor.a = PlayerData.Instance.GetDecorationFader();
        ApplyDecorationColor();
    }
    private void OnFadeBackground(float value)
    {
        backgroundColor.a = value;
        ApplyBackgroundColor();
    }
    private void OnFadeDecoration(float value) 
    {
        treeColor.a = value;
        ApplyDecorationColor(); 
    }
    private void ApplyDecorationColor()
    {
        leftTree.GetComponent<Image>().color = treeColor;
        rightTree.GetComponent<Image>().color = treeColor;
    }
    private void ApplyBackgroundColor()
    {
        background.GetComponent<Image>().color = backgroundColor;
    }
}
