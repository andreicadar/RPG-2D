using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPile : MonoBehaviour {

    public int moneyToAdd;
    private PlayerStats thePs;


	void Start ()
    {
        thePs = FindObjectOfType<PlayerStats>();
	}
	
	
	void Update ()
    {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Player")
        {
      
            thePs.money += moneyToAdd;
            PlayerPrefs.SetInt("Money", thePs.money);
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
