using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        int IndexBackgroundMusic = Random.Range(0, backgroundMusic.Length);
        AudioClip phaseMusic = backgroundMusic[IndexBackgroundMusic];
        audioSource.clip = phaseMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
