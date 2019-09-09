using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Data 
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GravityForce", order = 2)]
    public class GravityForce : ScriptableObject
    {
        public List<float> forces;
    }
}
