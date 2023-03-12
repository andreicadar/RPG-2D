using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;
    public QuestManager theQm;
    public string endText;


    public bool isItemQuest;
    public string targetItem;
    public int howMuchToCollect;
    private int currentlyCollected;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;
    public EnemyQuestManager theeqm;

    public float howMuchToShow;
    private float timeRemaining;
    private bool Hastocount;

    private DialogoueManager theDm;

    public int goldReward;
    public int expReward;

    private PlayerStats theStats;
    public GameObject quickInv;
   public int dialogNumber;
    public string whoGaveTheQuest;

    void Start ()
    {
        theeqm = FindObjectOfType<EnemyQuestManager>();
        theDm = FindObjectOfType<DialogoueManager>();
        timeRemaining = howMuchToShow;
        theStats = FindObjectOfType<PlayerStats>();
    }
	
	
	void Update ()
    {
        if(Hastocount)
        {
            timeRemaining -= Time.deltaTime;
        }
        if(timeRemaining<=0)
        {
            theeqm.StopShowingText();
            Hastocount = false;
            timeRemaining = howMuchToShow;
        }
		if(isItemQuest)
        {
            if(theQm.itemCollected == targetItem)
            {

                theQm.itemCollected = null;
                currentlyCollected++;   
            }
            if (currentlyCollected == howMuchToCollect)
                EndQuest();
        }
        if(isEnemyQuest)
        {
          
           
            if(theQm.EnemyKilled == targetEnemy)
            {

                Hastocount = true;
                theeqm.ShowText(enemyKillCount+1, enemiesToKill, targetEnemy);
                timeRemaining = howMuchToShow;
                theQm.EnemyKilled= null;

                enemyKillCount++;
            }

            if(enemyKillCount >= enemiesToKill)
            {
                EndQuest();
            }
        }
	}

    public void StartQuest()
    {
   
    }
    public void EndQuest()
    {   
        theStats.currentExp += expReward;
        theStats.money += goldReward;
        PlayerPrefs.SetInt("PlayerExperience", theStats.currentExp);
        PlayerPrefs.SetInt("Money", theStats.money);
        theDm.questBox.SetActive(false);
        theDm.wasQuest = true;
        timeRemaining = howMuchToShow;
        theQm.ShowQuestText(endText,goldReward,expReward);
        theQm.questCompleted[questNumber] = true;

        if (isEnemyQuest)
            theeqm.StopShowingText();
        PlayerPrefs.SetInt(whoGaveTheQuest,dialogNumber+1);
        PlayerPrefs.SetInt("Quest"+questNumber,1);
        gameObject.SetActive(false);
       
    }
}
