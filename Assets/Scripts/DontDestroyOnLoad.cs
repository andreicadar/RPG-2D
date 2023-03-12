using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

   private bool EventSystem;
	void Start () {
        if (!EventSystem)
        {
            EventSystem = true;
            DontDestroyOnLoad(transform.gameObject);
        }
       else
            Destroy(gameObject);
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
