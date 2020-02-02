using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public static AudioController Instance { get => instance;}

    public AudioClip[] Tracks;

    AudioSource ctrlAudio;

    void Awake() 
    {
        instance = this;
        ctrlAudio = GetComponent<AudioSource>();
        changeTrack(0);
    }

    // Update is called once per frame
    public void changeTrack(int TrackNum)
    {
        ctrlAudio.clip = Tracks[TrackNum];

        if(TrackNum == 0 /*|| TrackNum == 2*/)
            ctrlAudio.loop = true;
        else
        ctrlAudio.loop = false;

        ctrlAudio.Play();
    }

    private void Update() 
    {
        if(ctrlAudio.clip == Tracks[2])
        {
            if(!ctrlAudio.isPlaying)
            {
                ctrlAudio.clip = Tracks[0];
                ctrlAudio.Play();
            }
        }    
    }
}
