using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTrigger : MonoBehaviour
{
    private AudioClips _audioClips => SoundManager.AudioClips;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Mushrooms"))
        {
            SoundManager.Instance.PlayAudio(_audioClips.mushrooms);
        }
    }
}
