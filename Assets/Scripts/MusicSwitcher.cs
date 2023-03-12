using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    private MusicController theMc;

    public int newTrack;

    public bool switchOnStart;

	void Start ()
    {
        theMc = FindObjectOfType<MusicController>();

        if(switchOnStart)
        {
            theMc.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
	}
	

	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name=="Player")
        {
            theMc.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
