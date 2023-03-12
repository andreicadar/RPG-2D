using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    private VolumeManager theVM;
    public VolumeCotroler[] vcObjects;
    private static bool theVmExists = false;

    public float currentVolumeLevel;
    public float maxVolumeLevel = 1.0f;

    void Start()
    {
        theVM = FindObjectOfType<VolumeManager>();
        vcObjects = FindObjectsOfType<VolumeCotroler>();

        if (!theVmExists)
        {
            theVmExists= true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (currentVolumeLevel > maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        for(int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].SetAudioLevel(currentVolumeLevel);
        }
    }
	
	
	void Update ()
    { 
		
	}
}
