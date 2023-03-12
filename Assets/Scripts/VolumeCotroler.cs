using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeCotroler : MonoBehaviour {

    private AudioSource theAudio;

    private float audioLevel;
    public float defaultAudio;

	void Start ()
    {
        theAudio = GetComponent<AudioSource>();
	}
	
	
	void Update ()
    {
		
	}

    public void  SetAudioLevel(float volume)
    {
        if(theAudio == null)

        {
            theAudio.GetComponent<AudioSource>();
        }
        audioLevel = defaultAudio * volume;
        theAudio.volume = audioLevel;
    }
}
