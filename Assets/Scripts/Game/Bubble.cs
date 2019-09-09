using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    Animator animator;
    SpriteRenderer spriteRenderer;

    public Sprite first;
    public Sprite second;
    public Sprite last;

    public Sprite right;
    public Sprite wrong;

    bool pick = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void showQuestion(int selection)
    {
        if (selection == 1)
        {
            Invoke("firstQuestionSprite", 0.0f);
        }
        else if (selection == 2)
        {
            Invoke("secondQuestionSprite", 0.0f);
        }
        else
        {
            Invoke("lastQuestionSprite", 0.0f);
        }
        animator.enabled = true;
    }

    // Called by GameRules on Player Click
    public void Animate(bool pick)
    {
        Debug.Log("Animate");
        this.pick = pick;
        hide();
        Invoke("show", 1f);
    }

    private void hide()
    {
        animator.SetBool("Hide", true);
    }
    private void show()
    {
        animator.SetBool("Hide", false);
    }

    // Animation Event
    private void setSprite() 
    {
        if (pick) rightSprite();
        else wrongSprite();
    }

    // Result Sprite Setup
    private void rightSprite()
    {
        spriteRenderer.sprite = right;
    }
    private void wrongSprite()
    {
        spriteRenderer.sprite = wrong;
    }

    // Question Sprites Setup
    private void firstQuestionSprite()
    {
        spriteRenderer.sprite = first;
    }
    private void secondQuestionSprite()
    {
        spriteRenderer.sprite = second;
    }
    private void lastQuestionSprite()
    {
        spriteRenderer.sprite = last;
    }
}
