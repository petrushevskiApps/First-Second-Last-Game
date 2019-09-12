using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarratorCanvas : MonoBehaviour {

    Image spriteRenderer;
    Button narratorButton;
    [SerializeField] private GameObject particles;

    public Sprite neutral;
    public Sprite right;
    public Sprite wrong;

    public float waitTime = 1f;

    private bool stopCoroutine = false;

    private int questionNo = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
        narratorButton = GetComponent<Button>();
        narratorButton.onClick.AddListener(OnNarratorClicked);
    }
    private void OnEnable()
    {
        SetupNarratorButton();
        particles.SetActive(false);
    }

    public void InitializeNarratorAvatar(int questionNo) 
    {
        gameObject.SetActive(true);

        this.questionNo = questionNo;
        stopCoroutine = false;
        Question(0f);
    }
    public void Question(float waitTime)
    {
        StartCoroutine(DelayCall(() => 
        {
            ChangeSprite(neutral);
            AudioManager.Instance.PlayNarratorQuestion(questionNo);
            ActivateParticles();

        }, waitTime, true));
    }
    public void RightAnswer()
    {
        stopCoroutine = true;
        StartCoroutine(DelayCall(() => 
        {
            ChangeSprite(right);
            AudioManager.Instance.PlayNarrator(true);

        }, waitTime, false));
    }
    public void WrongAnswer() 
    {
        StartCoroutine(DelayCall(() => 
        {
            ChangeSprite(wrong);
            AudioManager.Instance.PlayNarrator(false);

        }, waitTime, true));

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

    private void OnNarratorClicked()
    {
        AudioManager.Instance.PlayNarratorQuestion(questionNo);
    }
    private void SetupNarratorButton()
    {
        narratorButton.interactable = PlayerData.Instance.GetAudioQuestionsState();
    }
    private void ActivateParticles()
    {
        if (PlayerData.Instance.GetVFX() && PlayerData.Instance.GetAudioQuestionsState())
        {
            particles.SetActive(true);
        }
    }
    private void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
