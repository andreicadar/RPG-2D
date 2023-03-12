using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    public int dropChance;
    public int minGoldToGive;
    public int maxGoldToGive;

    public GameObject goldPile;
    

    private PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQm;
    private  GoldPile theGp;
    private float number;
    private GameObject da;
    public int NumberOfSeconds = 3;
    public float second = 1f;
    public int BurnOrFrostbiteDamage;
    public FloatingNumbers theFn;
    public GameObject damageNumber;
    public GameObject spawner;


    void Start()
    {
        if (gameObject.name == "slime_green(Clone)")
        {
            spawner = GameObject.Find("GreenSlimeSpawner");     
        }
        else
            if (gameObject.name == "slime_red(Clone)")
            {
                spawner = GameObject.Find("RedSlimeSpawner");
            }
        if (gameObject.name == "slime_purple(Clone)")
        {
            spawner = GameObject.Find("PurpleSlimeSpawner");
        }
        if (gameObject.name == "Bat(Clone)1")
        {
            spawner = GameObject.Find("SpawnerUp");
        }
        if (gameObject.name == "Bat(Clone)2")
        {
            spawner = GameObject.Find("SpawnerDown");
        }
        if (gameObject.name == "Bat(Clone)3")
        {
            spawner = GameObject.Find("SpawnerAreaLeft1");
        }
        if (gameObject.name == "Bat(Clone)4")
        {
            spawner = GameObject.Find("SpawnerAreaLeft2");
        }
        if(gameObject.name == "SandGolem(Clone)")
        {
            spawner = GameObject.Find("SandGolemSpawner");
        }

        theQm = FindObjectOfType<QuestManager>();
       CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();
       
    }


    void Update()
    {
        if (NumberOfSeconds != 0)
        {
            
            if (BurnOrFrostbiteDamage != 0 && second == 1)
            {
               
                BurnOrFrostbite(BurnOrFrostbiteDamage);
                var clone = (GameObject)Instantiate(damageNumber, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().ifburn = true;
                clone.GetComponent<FloatingNumbers>().damageNumber = BurnOrFrostbiteDamage;
                second -= Time.deltaTime;
            }
            else if (BurnOrFrostbiteDamage != 0)
            {
                second -= Time.deltaTime;
            }
            if (second <= 0)
            {
                second = 1f;
                NumberOfSeconds--;
            }
        }

        if (CurrentHealth <= 0)
        {
            spawner.GetComponent<SpawnEnemies>().currentEnemyNumber--;
            number = Random.Range(1.0f, 100.0f);
            if(number<=dropChance)
            {
               

                Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
             da =  Instantiate(goldPile,pos,gameObject.transform.rotation);
              
                theGp = goldPile.GetComponent<GoldPile>();
                theGp.moneyToAdd = Random.Range(minGoldToGive,maxGoldToGive+1);
            }

            theQm.EnemyKilled = enemyQuestName;
             Destroy(gameObject);
            gameObject.SetActive(false);
            thePlayerStats.AddExperience(expToGive);
            PlayerPrefs.SetInt("PlayerExperience", thePlayerStats.currentExp);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
       CurrentHealth = MaxHealth;
    }
    public void BurnOrFrostbite(int damage)
    {
        CurrentHealth -= damage;
    }

}
