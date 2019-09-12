using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public Sprite netural;
    public Sprite right;
    public Sprite wrong;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void NarratorQuestion() 
    {
        spriteRenderer.sprite = netural;
    }
    public void rightAnswer()
    {
        Invoke("rightSprite", 1f);
    }
    public void wrongAnswer()
    {
        Invoke("wrongSprite",1f);
    }
    private void rightSprite()
    {
        spriteRenderer.sprite = right;
    }
    private void wrongSprite()
    {
        spriteRenderer.sprite = wrong;
    }
}
