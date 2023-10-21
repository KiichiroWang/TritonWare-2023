using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    public Sound[] clips;

    // Creates singleton
    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
        Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        CreateAudioSources();
    }

    // Creates all audio source players
    private void CreateAudioSources()
    {
        foreach (Sound s in clips)
        {
            // Sets sounds source to clip and adds it as an audiosource
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound sd = Array.Find(clips, sound => sound.name == name);
        sd.source.Play();
    }

}
