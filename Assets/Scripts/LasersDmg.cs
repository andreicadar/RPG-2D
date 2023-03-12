using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersDmg : MonoBehaviour
{

    public int damageToGive;
    public GameObject damageNumber;
    private PlayerStats thePS;
    private int currentDamage;

    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.name == "Player")
        {
            
           
            currentDamage = damageToGive - thePS.currentDefence;
            if (currentDamage < 1)
                currentDamage = 1;

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().ifplayer = true;
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            clone.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
