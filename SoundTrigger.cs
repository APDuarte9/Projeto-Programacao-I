using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip triggerSound;
    public float Volume;
    AudioSource audioSource;
    public bool alreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void OnTriggerEnter()
    {
        if(!alreadyPlayed)
        {
            audioSource.PlayOneShot(triggerSound, 7f);
            alreadyPlayed = true;
        }
    }
}
