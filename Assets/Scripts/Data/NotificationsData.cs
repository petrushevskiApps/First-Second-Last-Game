using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NotificationData", menuName = "ScriptableObjects/Notification", order = 4)]
public class NotificationsData : ScriptableObject
{
    public string notificationText;
    public Sprite notificationImage;
}
