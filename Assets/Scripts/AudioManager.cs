using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public AudioSource backgroundMusic;
    public AudioSource ui1;
    public AudioSource ui2;
    public AudioSource ui3;
    public AudioSource pickUpItem;
    public AudioSource walking;

    void Awake() {
        backgroundMusic = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ChangeBackgroundMusic(AudioClip music) {
        float pauseTime = backgroundMusic.time;
        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.time = pauseTime;
        backgroundMusic.Play();
    }

    public void PlayUI1(AudioClip clip, bool on = true, bool loop = false) {
        if (on && loop) {
            ui1.clip = clip;
            ui1.Play();
            ui1.loop = true;
        }
        else if (!on && loop) {
            ui1.Stop();
            ui1.loop = false;
        } 
        else if (on && !loop) {
            ui1.PlayOneShot(clip);
        }
        else if (!on && !loop) {
            ui1.Stop();
        }
    }

    public void PlayUI2(AudioClip clip, bool on = true, bool loop = false) {
        
    }

    public void PlayUI3(AudioClip clip, bool on = true, bool loop = false) {
        
    }

    public void PlayPickUpItem(AudioClip clip) {
        pickUpItem.PlayOneShot(clip);
    }

    public void PlayWalking(AudioClip clip) {
        if (!walking.isPlaying) {
            walking.clip = clip;
            walking.Play();
        }
    }

    public void StopWalking() {
        if (walking.isPlaying) {
            walking.Stop();
        }
    }

    public void ChangeFXVolume(int newVolume) {

    }

    public void ChangeMusicVolume(int newVolume) {
        
    }
}
