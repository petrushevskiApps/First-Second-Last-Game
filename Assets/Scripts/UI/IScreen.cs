using UnityEngine;
using System.Collections;

public abstract class IScreen : MonoBehaviour
{
    public abstract void OnBackButtonPressed();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnBackButtonPressed();
        }
    }
}
