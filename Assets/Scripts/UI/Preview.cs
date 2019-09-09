using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    private Button preview;
    [SerializeField] private NotificationsData data;

    private void Awake()
    {
        preview = GetComponent<Button>();
        preview.onClick.AddListener(OnPreviewClicked);
    }
    private void OnPreviewClicked()
    {
        AudioManager.Instance.PlayUIInteraction();
        UI_Manager.Instance.ShowNotification(data);
    }
}
