using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMode : MonoBehaviour
{
    [SerializeField] private GameObject helpingHand;
    [SerializeField] private float timerSeconds = 0f;

    private Transform handPosition;
    private GameObject hand;

    private void Awake()
    {
        GameManager.Instance.OnGameEnd += ClearHelpMode;
    }
    private void OnDisable()
    {
        
    }
    private void ClearHelpMode()
    {
        if(hand != null)
        {
            Destroy(hand);
        }
    }
    public void Initialize(Transform position)
    {
        InstantiateHelp(position);
        StartCoroutine(StartHelpTimer());
    }
    public void StopHelpMode()
    {
        if(hand != null && !hand.activeSelf)
        {
            ClearHelpMode();
        }
    }
    IEnumerator StartHelpTimer()
    {
        yield return new WaitForSeconds(timerSeconds);
        if(hand != null)
        {
            ToggleHand();
        }
    }

    private void InstantiateHelp(Transform position)
    {
        Transform parent = position.parent.transform;
        hand = Instantiate(helpingHand, parent);
        hand.transform.localPosition = new Vector3(position.localPosition.x, position.localPosition.y + 220, 0);
    }
    private void ToggleHand()
    {
        hand.SetActive(!hand.activeSelf);
    }

}
