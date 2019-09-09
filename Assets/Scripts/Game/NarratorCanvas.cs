using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarratorCanvas : MonoBehaviour {

    Animator animator;
    Image spriteRenderer;

    public Sprite neutral;
    public Sprite right;
    public Sprite wrong;

    public float waitTime = 1f;

    private bool stopCoroutine = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<Image>();
    }

    public void InitializeNarratorAvatar() 
    {
        stopCoroutine = false;
        Question(0f);
    }
    public void Question(float waitTime)
    {
        StartCoroutine(DelayCall(() => { ChangeSprite(neutral); }, waitTime, true));
    }
    public void RightAnswer()
    {
        stopCoroutine = true;
        StartCoroutine(DelayCall(() => { ChangeSprite(right); }, waitTime, false));
    }
    public void WrongAnswer() 
    {
        StartCoroutine(DelayCall(() => { ChangeSprite(wrong); }, waitTime, true));
        Question(6f);
    }

    IEnumerator DelayCall(Action Callback, float waitSeconds, bool isStoppable)
    {
        yield return new WaitForSeconds(waitSeconds);
        if (stopCoroutine && isStoppable) 
        {
            yield break;
        }
        Callback();
    }

    private void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
