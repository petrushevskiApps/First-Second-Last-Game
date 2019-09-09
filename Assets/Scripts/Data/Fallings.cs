using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FallingsData", order = 1)]
public class Fallings : ScriptableObject
{
    public GameObject prefab;
    public List<Sprite> sprites; 
}