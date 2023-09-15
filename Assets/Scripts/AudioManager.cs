using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    [HideInInspector] List<float> soundVolumes = new List<float>();

    public static AudioManager Instance;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds) {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.name = s.name;
            s.audioSource.volume = s.volume;
            s.audioSource.clip = s.audioClip;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.isLoop;

            if(s.audioSource.name == "click") {
                s.audioSource.time = 0.5f;
            }
            if(s.audioSource.name == "boing") {
                s.audioSource.time = 0.015f;
            } 
            soundVolumes.Add(s.audioSource.volume);
        }
    }

    private void Update() {
        if(SceneManager.GetActiveScene().buildIndex < 1) {
            Sound song = FindSong("menu");
            if(!song.audioSource.isPlaying) {
                StopPlayAll();
                Play("menu");
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex < 6) {
            Sound song = FindSong("snow");
            if(!song.audioSource.isPlaying) {
                StopPlayAll();
                Play("snow");
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex < 11) {
            Sound song = FindSong("zort");
            if(!song.audioSource.isPlaying) {
                StopPlayAll();
                Play("zort");
            }
        }       
    }
    public void Play(string name) {
        Sound sound = Array.Find(sounds,sound => sound.name == name);
        sound.audioSource.Play();
    }

    public void StopPlay(string name) {
        Sound sound = Array.Find(sounds,sound => sound.name == name);
        sound.audioSource.Stop();
    }
    public void StopPlayAll() {
        foreach(Sound s in sounds) {
            s.audioSource.Stop();
        }
    }

    public void MuteAll() {
        foreach(Sound s in sounds) {
            s.audioSource.volume = 0f;
        }
    } 

    public void UnMuteAll() {
        for(int i= 0; i < sounds.Length;i++ ) {
            sounds[i].audioSource.volume = soundVolumes[i];
        }
    }

    public Sound FindSong(string name) {
        Sound sound = Array.Find(sounds,sound => sound.name == name);
        return sound;
    }
}
