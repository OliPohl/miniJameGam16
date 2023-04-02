using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private AudioClips _audioClips => SoundManager.AudioClips;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            MenuManager.Instance.endTriggerd = true;
            SoundManager.Instance.PlayAudio(_audioClips.fall);
        }
    }
}
