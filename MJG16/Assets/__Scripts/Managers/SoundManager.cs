using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [field: SerializeField] private AudioClips _audioClips;
    public static AudioClips AudioClips => Instance._audioClips;
    
    public Settings _settings;

    private AudioSource sfxAudioSource;
    private GameObject audioPlayer;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        sfxAudioSource = Camera.main.gameObject.AddComponent<AudioSource>();
        audioPlayer = new GameObject();
    }


    private void PlayAudio(AudioClip AudioClip)                 // use this to play audio that has no position
    {
        if (sfxAudioSource != null && AudioClip != null)
            sfxAudioSource.volume = _settings.MasterVolume;
            sfxAudioSource.PlayOneShot(AudioClip);
    }


    private void PlayAudioAtPosition(AudioClip AudioClip, Vector3 AudioPosition)    // use this for Audio that comes from a specific location
    {
        if (AudioClip != null  && AudioPosition != null)
            {
                GameObject CurrentAudioPlayer = Instantiate(audioPlayer, AudioPosition, Quaternion.identity);
                CurrentAudioPlayer.AddComponent<DestroyLater>();

                AudioSource CurrentAudioSource = CurrentAudioPlayer.AddComponent<AudioSource>();
                CurrentAudioSource.volume = _settings.MasterVolume;
                CurrentAudioSource.PlayOneShot(AudioClip);
            }
    }


    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}

    // Example of use:

    // At the start of the programm load in AudioClips:
    // -
    // private AudioClips _audioClips => SoundManager.AudioClips;


    // in the line where you want to play a general audio:
    // -
    // SoundManager.Instance.PlayAudio(_audioClips.SOUND);

    // in the line where you want to play audio at a specific location:
    // -
    // SoundManager.Instance.PlayAudioAtPosition(_audioClips.SOUND, VECTOR3_LOCATION);