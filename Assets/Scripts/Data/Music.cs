using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Music", order = 3)]
    public class Music : ScriptableObject 
    {
        [Header ("UI Interaction Audio")]
        public AudioClip uiInteractionAudio;
        public AudioClip timerTick;

        [Header ("Backgroudn songs")]
        public List<AudioClip> backgroundSongs;

        [Header("Player Choice Sound Effects")]
        public AudioClip wrongChoiceSFX;
        public AudioClip rightChoiceSFX;

        [Header("Narrator Audio Files")]
        public AudioClip wrongChoiceAudio;
        public AudioClip rightChoiceAudio;

        public List<AudioClip> questionsAudio;
        
    }
}
