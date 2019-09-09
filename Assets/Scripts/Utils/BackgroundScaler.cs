using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private RectTransform background;
    //[SerializeField] private RectTransform popupSize;

    private float backgroundSize = 0;

    private void Awake()
    {
        background = GetComponent<RectTransform>();
    }
    public void Setup(RectTransform popupSize)
    {
        foreach (RectTransform o in transform.GetComponentInChildren<RectTransform>())
        {
            if (o.gameObject.activeSelf)
            {
                backgroundSize += o.rect.height;
            }
        }
        AddPadding();
        background.sizeDelta = new Vector2(background.rect.width, backgroundSize);
        popupSize.sizeDelta = new Vector2(popupSize.rect.width, backgroundSize);
    }
    private void AddPadding()
    {
        backgroundSize += backgroundSize * 0.2f;
    }
    private void OnDisable()
    {
        backgroundSize = 0;
    }
}
