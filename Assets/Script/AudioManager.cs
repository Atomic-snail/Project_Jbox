using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //array of floats necessary for scenery changes.
    public float[] songTimes;
    public AudioClip[] songFiles;
    public float[] songBPMTimer;
    public int[] timeOfDay;

    public float timeRemaining;

    public AudioSource audioSource;

    public AudioClip randomizedSong;

    public int currentSong;

    public int currentTime;
    skyTimeChanger SkyTimeChanger;

    // Use this for initialization
    void Start()
    {
        SkyTimeChanger = GameObject.FindGameObjectWithTag("sky").GetComponent<skyTimeChanger>();
        currentSong = (Random.Range(0, songFiles.Length));

        randomizedSong = songFiles[currentSong];

        currentTime = timeOfDay[currentSong];

        for (int i = 0; i < songFiles.Length; i++)
        {
            songTimes[i] = songFiles[i].length;
        }

        audioSource.clip = randomizedSong;
        audioSource.PlayOneShot(randomizedSong);
    }

    // Update is called once per frame
    void Update()
    {

        timeRemaining = randomizedSong.length;

        timeRemaining -= Time.time;

        if (timeRemaining <= 0.0f) {
            NewSong();
            timeRemaining = randomizedSong.length;
            SkyTimeChanger.progressStage(timeOfDay[currentSong]);
            SkyTimeChanger.lerpSpeedMidStage = songTimes[currentSong];
        }

    }

    //randomize new song at end of song.
    public void NewSong() {
        currentSong = (Random.Range(0, songFiles.Length));
        randomizedSong = (songFiles[currentSong]);
        currentTime = timeOfDay[currentSong];
    }
}
