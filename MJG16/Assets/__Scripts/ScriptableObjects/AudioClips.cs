using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "MJG16/AudioClips", order = 0)]
public class AudioClips : ScriptableObject
{
    [field: Header("Menu")]
    [field: SerializeField] public AudioClip ButtonPress { get; private set; }
}