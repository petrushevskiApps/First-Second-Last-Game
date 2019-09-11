using UnityEngine;
using System.Collections;

public abstract class ISettings : MonoBehaviour
{
    public abstract void SaveSettings();
    public abstract void DiscardChanges();
    public abstract bool IsSettingsChanged();
    public abstract void ClearChange();
}
