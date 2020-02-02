﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public static AudioController Instance { get => instance;}

    public AudioClip[] Tracks;

    void Awake() 
    {
        instance = this;
        changeTrack(0);
    }

    // Update is called once per frame
    public void changeTrack(int TrackNum)
    {
        gameObject.GetComponent<AudioSource>().clip = Tracks[TrackNum];

        if(TrackNum == 0 || TrackNum == 2)
            gameObject.GetComponent<AudioSource>().loop = true;
        else
        gameObject.GetComponent<AudioSource>().loop = false;

        gameObject.GetComponent<AudioSource>().Play();


    }
}
