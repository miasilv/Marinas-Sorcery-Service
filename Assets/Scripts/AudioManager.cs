using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public AudioSource backgroundMusic;

    void Awake()
    {
        backgroundMusic = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackgroundMusic(AudioClip music) {
        float pauseTime = backgroundMusic.time;
        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.time = pauseTime;
        backgroundMusic.Play();
    }
}
