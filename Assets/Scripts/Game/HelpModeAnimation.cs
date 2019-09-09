using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpModeAnimation : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool endReached = false;
    private bool startReached = false;

    private void OnEnable()
    {
        startPosition = transform.localPosition;
        endPosition = startPosition;
        endPosition.y -= 40;
    }

    // Update is called once per frame
    void Update ()
    {
		if(!endReached)
        {
            //float y = Mathf.Lerp(transform.localPosition.y, endPosition.y, Time.deltaTime);
            float y = transform.localPosition.y - 30 * Time.deltaTime;
            Move(y);

            if ((int)transform.localPosition.y <= (int)endPosition.y)
            {
                endReached = true;
            }
        }

        if (endReached)
        {
            //float y = Mathf.Lerp(transform.localPosition.y, startPosition.y, Time.deltaTime);
            float y = transform.localPosition.y + 30 * Time.deltaTime;
            Move(y);
            if((int)transform.localPosition.y >= (int)startPosition.y)
            {
                endReached = false;
            }
        }
        
    }
    private void Move(float y)
    {
        Vector3 temp = transform.localPosition;
        temp.y = y;
        transform.localPosition = temp;
    }
}
