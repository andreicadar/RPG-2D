using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {
    public string levelToLoad;

    public string exitPoint;

    private PlayerController thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            PlayerPrefs.SetString("lastlvl", levelToLoad);

            Application.LoadLevel(levelToLoad);
            thePlayer.startPoint = exitPoint;
            thePlayer.lastlvl = levelToLoad;
            PlayerPrefs.SetString("lastpos", exitPoint);

        }
    }
}
