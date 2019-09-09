using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingsFactory : MonoBehaviour
{
    public List<Fallings> selections;

    public List<GravityForce> gravity;

    private List<float> gForces;

    public void InitializeFactory(List<GameObject> positions, int level, int selection)
    {
        InitializeGravity();
        
        for(int i=0; i<positions.Count; i++)
        {
            InstantiateFallingObjects(positions[i], selection, level, i);
        }
    }
    private void InitializeGravity()
    {
        gForces = ShuffleOrder(PlayerData.Instance.GetSpeedMode());
    }

    private void InstantiateFallingObjects(GameObject position, int selection, int level, int positionIndex)
    {
        GameObject prefab = selections[selection].prefab;

        List<Sprite> fallingImages = selections[selection].sprites;

        GameObject falling = Instantiate(prefab, position.transform);

        falling.transform.SetParent(position.transform);

        falling.GetComponent<Image>().sprite = fallingImages[Random.Range(0, fallingImages.Count)];

        falling.GetComponent<FallingObjects>().SetGravity(level * gForces[positionIndex]);

    }

    private List<float> ShuffleOrder(int speedSelection)
    {
        List<float> startOrder = new List<float>();
        List<float> finalOrder = new List<float>();

        gravity[speedSelection].forces.ForEach(element => startOrder.Add(element));

        while (startOrder.Count > 0)
        {
            int forceIndex = Random.Range(0, startOrder.Count);
            finalOrder.Add(startOrder[forceIndex] * Time.deltaTime);
            startOrder.RemoveAt(forceIndex);
        }

        finalOrder.ForEach(element => Debug.Log(element));
        return finalOrder;
    }

}
