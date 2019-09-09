using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Action<bool> OnPlayerPick = (playerPick) => { };

    public List<GameObject> parentPosition;
    
    private List<FallingObjects> fallenOrder;

    private FallingsFactory factory;
     
    private int selection;
    private int level = 0;
    private int maxLevel = 5;


    private void Awake()
    {
        factory = GetComponent<FallingsFactory>();
        fallenOrder = new List<FallingObjects>();
    }
    public void StartLevel() 
    {
        SetLevel();
        factory.InitializeFactory(parentPosition, level, GameManager.Instance.GetThemeIndex());
    }
    public void ResetLevel()
    {
        level = 0;
    }
    public void ClearLevel() 
    {
        if (parentPosition[0].transform.childCount > 0)
        {
            foreach (GameObject p in parentPosition)
            {
                Destroy(p.transform.GetChild(0).gameObject);
            }
            fallenOrder.Clear();
        }
    }

    
    private void SetLevel()
    {
        if (level == maxLevel)
        {
            level = 1;
        }
        else level++;
    }
    
    public void ClickedFallingObject(FallingObjects fallingObject)
    {
        Debug.Log(GameManager.Instance.GetQuestion() != fallenOrder.IndexOf(fallingObject));

        if (GameManager.Instance.GetQuestion() != fallenOrder.IndexOf(fallingObject) )
        {
            OnPlayerPick(false);
            AudioManager.Instance.PlaySFX(false);
            fallingObject.Animate();
        }
        else
        {
            GameManager.Instance.StopHelpMode();
            OnPlayerPick(true);
            AudioManager.Instance.PlaySFX(true);
            fallingObject.ShowParticles();
            StartCoroutine(DelayCall(GameManager.Instance.LevelComplete, 5f));
            
        }

    }

    // Adds falling object in Order List
    // On Collision with ground
    public void AddToOrder(FallingObjects f)
    {
        if(fallenOrder.Count < 3)
        {
            fallenOrder.Add(f);

            if (fallenOrder.Count == 3)
            {
                ActivateInteraction();
                ActivateHelpMode();
            }
        }
    }
    private void ActivateInteraction()
    {
        foreach(FallingObjects f in fallenOrder)
        {
            f.ToggleButtonInteraction();
        }
    }
    private void ActivateHelpMode()
    {
        if (PlayerData.Instance.GetHelpModeState())
        {
            GameManager.Instance.InitializeHelpMode(GetFallenParent(GameManager.Instance.GetQuestion()));
        }
    }

    public Transform GetFallenParent(int selection) 
    {
        return fallenOrder[selection].gameObject.transform;
    }

    IEnumerator DelayCall(Action Callback, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Callback();
    }
    
}
