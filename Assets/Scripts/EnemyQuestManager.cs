using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyQuestManager : MonoBehaviour {

    public float howMuchToShow;
    private float currentTimer;
    public Text howManyKilledtxt;
    public Text howManyhaveToKilltxt;
    private bool managerExists;
    public GameObject dialogue;
	
	void Start ()
    {
        currentTimer = howMuchToShow;
        if (!managerExists)
        {
            managerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	
	void Update ()
    {
		
	}
    public void ShowText(int howManyKilled,int howManyHaveToKill,string nameOfEnemy)
    {  
        howManyKilledtxt.text = "" +howManyKilled;
        howManyhaveToKilltxt.text = "out of " + howManyHaveToKill+" " + nameOfEnemy;
        dialogue.SetActive(true);  

    }
    public void StopShowingText()
    {
        dialogue.SetActive(false);

    }
}
