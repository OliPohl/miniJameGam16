<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [field: SerializeField] private AudioClips _audioClips;
    public static AudioClips AudioClips => Instance._audioClips;
    
    public Settings _settings;

    private AudioSource cameraAudioSource;
    private GameObject audioPlayer;
    private AudioSource musicSource;
    private AudioClip currentMusic;


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
        cameraAudioSource = Camera.main.gameObject.AddComponent<AudioSource>();

        GameObject musicPlayer = new GameObject("MusicPlayer");
        musicPlayer.transform.SetParent(Camera.main.transform);
        musicSource = musicPlayer.AddComponent<AudioSource>();
    }


    private void PlayAudio(AudioClip AudioClip)                 // use this to play audio that has no position
    {
        if (cameraAudioSource != null && AudioClip != null)
            cameraAudioSource.volume = _settings.MasterVolume;
            cameraAudioSource.PlayOneShot(AudioClip);
    }


    private void PlayAudioAtPosition(AudioClip AudioClip, Vector3 AudioPosition)    // use this for Audio that comes from a specific location
    {
        if (AudioClip != null  && AudioPosition != null)
        {
            GameObject CurrentAudioPlayer = Instantiate(new GameObject("AudioPlayer"), AudioPosition, Quaternion.identity);
            CurrentAudioPlayer.AddComponent<DestroyLater>();

            AudioSource CurrentAudioSource = CurrentAudioPlayer.AddComponent<AudioSource>();
            CurrentAudioSource.volume = _settings.MasterVolume;
            CurrentAudioSource.PlayOneShot(AudioClip);
        }
    }


    private void ChangeMusic(AudioClip AudioClip)
    {
        if (musicSource != null && AudioClip != null && AudioClip != currentMusic)
        {
            musicSource.volume = _settings.MasterVolume;

            musicSource.clip = AudioClip;
            musicSource.loop = true;
            musicSource.Play();
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
>>>>>>> fa1039c67a2ad716b9dffa002e563a58f61e9466
