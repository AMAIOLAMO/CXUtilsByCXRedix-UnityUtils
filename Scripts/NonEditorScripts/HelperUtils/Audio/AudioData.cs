using System;
using UnityEngine;

using Random = UnityEngine.Random;

namespace CXUtils.HelperComponents
{
    [Serializable]
    [CreateAssetMenu( fileName = "audioData", menuName = "CXUtils/Audio/AudioData" )]
    public class AudioData : ScriptableObject
    {
        [Header("Audio Clips")]
        [SerializeField] private AudioClip[] audioClips;

        public AudioClip[] AudioClips => audioClips;

        /// <summary>
        /// Does this audio data have no audio clips
        /// </summary>
        public bool HasAudioClip => audioClips.Length > 0;

        /// <summary>
        /// Gets a audio clip from the audio clips
        /// </summary>
        public AudioClip GetAudioClip( int index = 0 ) =>
            audioClips[index];

        /// <summary>
        /// Get's a random audio clip from the audio clips
        /// </summary>
        public AudioClip GetRandomAudioClip()
        {
            if ( !HasAudioClip )
                return null;

            return audioClips[Random.Range( 0, audioClips.Length )];
        }
    }
}
