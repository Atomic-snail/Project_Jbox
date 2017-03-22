using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //array of floats necessary for scenery changes.
    public float[] songTimes;
    public AudioClip[] songFiles;
    public float[] songBPMTimer;
    public float[] timeOfDay;

    public float timeRemaining;

    public AudioSource audioSource;

    public AudioClip randomizedSong;

    // Use this for initialization
    void Start()
    {

        randomizedSong = (songFiles[Random.Range(0, songFiles.Length)]);

        for (int i = 0; i < songFiles.Length; i++)
        {
            songTimes[i] = songFiles[i].length;
        }
    }

    // Update is called once per frame
    void Update()
    {

        timeRemaining = randomizedSong.length;

        timeRemaining -= Time.time;

        if (timeRemaining <= 0.0f) {
            NewSong();
        }

    }

    //randomize new song at end of song.
    void NewSong() {
        randomizedSong = (songFiles[Random.Range(0, songFiles.Length)]);
    }
}
