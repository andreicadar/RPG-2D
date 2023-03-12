using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    
    public GameObject damageParticles;
    public Transform hitPoint;
    public GameObject damageNumber;
    public PlayerController theplayer;
    private int currentDamage;

    
    public int weaponDamage;
    public int weaponBurnOrFrostchance;
    public int weaponBurnOrFrostbites;

    public int chanceOfSlow;
    public int slowPercent;
    public int slowTime;

    public int chanceOfCrit;

   
    

    private PlayerStats thePS;

	void Start ()
    {
        thePS = FindObjectOfType<PlayerStats>();
	}
	
	
	void Update ()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
      
        float number;
        if (other.gameObject.tag == "Enemy"/*&& theplayer.atacking==true*/ )
        {
            currentDamage = weaponDamage + thePS.currentAtack;
            number = Random.Range(1f, 100f+1);
            if (number <= chanceOfCrit)
            {
               
                currentDamage *= 2;
            }


            Instantiate(damageParticles, hitPoint.position, hitPoint.rotation);
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            clone.transform.position = new Vector2(transform.position.x, transform.position.y); 


            number = Random.Range(1f, 100f+1);
            if (number <= chanceOfSlow)
            {
                SlimeController sc = other.gameObject.GetComponent<SlimeController>();
                sc.isSlowed = true;
                sc.slowPercent = slowPercent;
                sc.SlowTime = slowTime;

            }

           
            number = Random.Range(1f, 100f+1);
            if (number <= weaponBurnOrFrostchance)
            {
               
                other.gameObject.GetComponent<EnemyHealthManager>().BurnOrFrostbiteDamage = weaponBurnOrFrostbites;
                other.gameObject.GetComponent<EnemyHealthManager>().NumberOfSeconds = 3;
                other.gameObject.GetComponent<EnemyHealthManager>().second = 1f;
            }
           
        }
    }
}
