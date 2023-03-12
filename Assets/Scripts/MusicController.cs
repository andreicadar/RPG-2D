using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static bool mcExists;

    public AudioSource[] musicTracks;

    public int currentTrack;

    public bool musicCanPlay;

	void Start ()
    {
        for(int i=0;i<musicTracks.Length;i++)
        {
            musicTracks[i].volume = 0.2f;
        }
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        int number = Random.Range(0, musicTracks.Length );
        currentTrack = number;
    }
	
	
	void Update ()
    {
		if(musicCanPlay)
        {
            for (int i = 0; i < musicTracks.Length; i++)
            {
                musicTracks[i].volume = 0.2f;
            }
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }
	}

    public void SwitchTrack(int newTrack)
    {
        for (int i = 0; i < musicTracks.Length; i++)
        {
            musicTracks[i].volume = 0.2f;
        }
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }
}
