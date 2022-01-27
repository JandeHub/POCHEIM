using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public SoundsSystemData[] sounds;

    void Awake()
    {
        foreach (SoundsSystemData s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    public void Play(string name)
    {
        SoundsSystemData s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
