using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "MJG16/AudioClips", order = 0)]
public class AudioClips : ScriptableObject
{
    [field: SerializeField] public AudioClip[] Footsteps { get; private set; }
    [field: SerializeField] public AudioClip book { get; private set; }
    [field: SerializeField] public AudioClip breaking { get; private set; }
    [field: SerializeField] public AudioClip ducttape { get; private set; }
    [field: SerializeField] public AudioClip fall { get; private set; }
    [field: SerializeField] public AudioClip fire { get; private set; }
    [field: SerializeField] public AudioClip achievement { get; private set; }
    [field: SerializeField] public AudioClip wind { get; private set; }
    [field: SerializeField] public AudioClip ambient { get; private set; }
}