using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioClips _audioClips => SoundManager.AudioClips;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 6)
        {
            Debug.Log("FOOTSTEP IS PLAYING A SOUND");
            SoundManager.Instance.PlayAudio(_audioClips.Footsteps[Random.Range(0,_audioClips.Footsteps.Length-1)]);
        }
    }

}
