using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    public GameObject damageNumber;
    private int currentDamage;
    public BatAttackSystem ba;
    private PlayerStats thePS;

	void Start ()
    {
        thePS = FindObjectOfType<PlayerStats>();
        if ((gameObject.name == "Bat(Clone)1") || (gameObject.name == "Bat(Clone)2") || (gameObject.name == "Bat(Clone)3") || (gameObject.name == "Bat(Clone)4"))
        {
            ba = GetComponent<BatAttackSystem>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.name == "Player")
        {
            if ((gameObject.name == "Bat(Clone)1" )|| (gameObject.name == "Bat(Clone)2")  ||  (gameObject.name == "Bat(Clone)3") || (gameObject.name == "Bat(Clone)4"))
            {
                ba.HitP = true;
            }
                currentDamage = damageToGive - thePS.currentDefence;
            if (currentDamage < 1)
                currentDamage = 1;

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            var clone = (GameObject)Instantiate(damageNumber,other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().ifplayer = true;
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            clone.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
       
    }
}
