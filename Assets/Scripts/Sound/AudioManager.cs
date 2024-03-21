using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    //SOUND ARRAY
    public Sound[] sounds;


    //PLAYS BEFORE THE GAME STARTS
    private void Awake()
    {

        //ALLOWS FOR CHANGES TO THE AUDIO CLIP
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }


    //FINDS THE SONG NAME AND PLAYS
    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    //FINDS THE SONG NAME AND STOPS PLAYING
    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
        
    }
}
