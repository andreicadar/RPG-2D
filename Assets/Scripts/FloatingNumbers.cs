using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FloatingNumbers : MonoBehaviour {

    public float moveSpeed;
    public float damageNumber;

    public Text displayNumber;

    public bool ifplayer = false;
    public bool ifburn = false;


	void Start ()
    {
		
	}
	
	

	void Update ()
    {
        displayNumber.text =""+damageNumber;
        if(ifplayer)
        {
            displayNumber.color = new Color(255,0,0);
        }
        if(ifburn)
        {
            displayNumber.color = new Color(255f,128f,0f,255f);
        }

        if(!ifplayer&&!ifburn)
        {
            displayNumber.color = new Color(255,255,255);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime,transform.position.z);
	}
}
