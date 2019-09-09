using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleCanvas : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Image bubbleImage;

    public List<Sprite> questions; 

    public Sprite right;
    public Sprite wrong;

    private int selection;
    private bool pick;
    private bool stopCoroutine = false;

    public void InitializeQuestion(int selection)
    {
        this.selection = selection;
        stopCoroutine = false;
        Question();
    }

    // Called on Player Click
    public void Animate(bool pick)
    {
        this.pick = pick;
        ShowBubble(PickResult, 1f, !pick);
    }

    public void ShowQuestion()
    {
        ShowBubble(Question, 5f, true);
    }

    private void ShowBubble(Action Callback, float waitTime, bool isStoppable)
    {
        StartCoroutine(ToggleVisiblitiy(true, 0f));
        StartCoroutine(DelayCall(Callback, 1f, isStoppable));
        StartCoroutine(ToggleVisiblitiy(false, 1f));
    }
    /// <summary>
    /// Switch bubble state
    /// </summary>
    /// <param name="hide" value="false">Hide bubble</param>
    /// <param name="hide" value="true">Show bubble</param>
    IEnumerator ToggleVisiblitiy(bool hide, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("Hide", hide);
    }

    private void PickResult()
    {
        if (pick)
        {
            stopCoroutine = true;
            SetSprite(right);
        }
        else
        {
            SetSprite(wrong);
            StartCoroutine(DelayCall(ShowQuestion, 5f, true));
        }
    }

    private void Question()
    {
        SetSprite(questions[selection]);
    }

    IEnumerator DelayCall(Action Callback, float waitTime, bool isStoppable)
    {
        yield return new WaitForSeconds(waitTime);
        if (stopCoroutine && isStoppable) yield break;
        Callback();
    }
    // Change bubble sprite
    private void SetSprite(Sprite sprite) 
    {
        bubbleImage.sprite = sprite;
    }


}
