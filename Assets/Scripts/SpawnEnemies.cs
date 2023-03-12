using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject enemy;
    public Collider2D areaToSpawn;
    public int maxEnemyNumber;
    public int  currentEnemyNumber;
    public float timeBetweenSpawns;
    private float currentTimeBetweenSpawns;
    private GameObject a;

    void Start ()
    {
        currentEnemyNumber = 0;
	}
	
	
	void Update ()
    {
        currentTimeBetweenSpawns -= Time.deltaTime;
        if(currentTimeBetweenSpawns<=0&&currentEnemyNumber<maxEnemyNumber)
        {
            Spawn();
            currentTimeBetweenSpawns = timeBetweenSpawns;
            currentEnemyNumber++;
        }
	}
    void Spawn()
    {

        Vector2 min = areaToSpawn.bounds.min;
        Vector2 max = areaToSpawn.bounds.max;
        Vector3 pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), -1);
        if (gameObject.name == "SpawnerUp")
        {
            a = Instantiate(enemy, pos, gameObject.transform.rotation);
            a.name = "Bat(Clone)1";
        }else
        if (gameObject.name == "SpawnerDown")
        {
            a = Instantiate(enemy, pos, gameObject.transform.rotation);
            a.name = "Bat(Clone)2";
        }else
        if (gameObject.name == "SpawnerAreaLeft1")
        {
            a = Instantiate(enemy, pos, gameObject.transform.rotation);
            a.name = "Bat(Clone)3";
        }else
        if (gameObject.name == "SpawnerAreaLeft2")
        {
            a = Instantiate(enemy, pos, gameObject.transform.rotation);
            a.name = "Bat(Clone)4";
        }

        else
        {
            Instantiate(enemy, pos, gameObject.transform.rotation);
        }

    }
    
}
