using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Music", order = 3)]
    public class Music : ScriptableObject 
    {
        
        public AudioClip wrongChoiceAudio;
        public AudioClip rightChoiceAudio;
        public AudioClip wrongChoiceSFX;
        public AudioClip rightChoiceSFX;

        public AudioClip uiInteractionAudio;

        public List<AudioClip> backgroundSongs;
        public List<AudioClip> questionsAudio;
        
    }
}
