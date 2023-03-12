using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour {

    public GameObject player;
	void Start () {
        string lastlvl;
        if (PlayerPrefs.HasKey("lastlvl"))
        {
            lastlvl = PlayerPrefs.GetString("lastlvl");
        }
        else
        {
            PlayerPrefs.SetString("lastlvl", "Village");
            {
                lastlvl = "Village";

            }
        }
        player = GameObject.Find("Player");
        if (lastlvl == "menu")
            player.transform.position = new Vector3(4.39f, -8f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
