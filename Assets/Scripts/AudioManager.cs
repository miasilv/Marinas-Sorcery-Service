using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public AudioSource backgroundMusic;
    public AudioSource cauldron;
    public AudioSource src;
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

    public void PlayCauldronBubble(AudioClip clip) {
        cauldron.Stop();
        cauldron.clip = clip;
        cauldron.Play();
    }

    public void StopCauldronBubble() {
        cauldron.Stop();
    }

    public void PlayUI2(AudioClip clip) {
        src.PlayOneShot(clip);
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
