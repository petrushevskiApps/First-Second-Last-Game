using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : FallingObjects
{
    
    bool animate = false;


    public override void Animate()
    {
        animate = !animate;
        animator.SetBool("start", animate);
    }

    public override void Clicked()
    {
        GameManager.Instance.levelManager.ClickedFallingObject(this);
    }
    
    public override GameObject getFalling()
    {
        Debug.Log(gameObject);
        return gameObject;
    }

}
