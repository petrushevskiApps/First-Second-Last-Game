using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Notification : IPopup
{
    public static NotificationsData data;

    [SerializeField] private Button close;
    [SerializeField] private Text text;
    [SerializeField] private Image image;

    [SerializeField] private BackgroundScaler scaler;

    private void OnEnable()
    {
        fader.SetActive(true);
        SetupData();
    }
    private void SetupData()
    {
        if (data.notificationImage != null)
        {
            image.sprite = data.notificationImage;
            image.preserveAspect = true;
            image.gameObject.SetActive(true);
        }
        else image.gameObject.SetActive(false);

        if (data.notificationText.Length > 0)
        {
            text.text = data.notificationText.Replace("#n", "\n");
            text.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("No notification message to show!");
            ClosePopup();
        }
        scaler.Setup(this.GetComponent<RectTransform>());
    }
    private void OnDisable()
    {
        data = null;
        text.text = "";
        text.gameObject.SetActive(false);
        image.sprite = null;
        image.gameObject.SetActive(false);

    }
    public override void Agree()
    {
        throw new System.NotImplementedException();
    }

    public override void Disagree()
    {
        AudioManager.Instance.PlayUIInteraction();
        ClosePopup();
    }

    private void Awake()
    {
        close.onClick.AddListener(Disagree);
    }

    public override void OnBackButtonPressed()
    {
        Disagree();
    }
}
