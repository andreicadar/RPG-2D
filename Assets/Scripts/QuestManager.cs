using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogoueManager theDm;

    public string itemCollected;

    public string EnemyKilled;

    public GameObject questEndStuff;

	void Start ()
    {
        int i;
        questCompleted = new bool[quests.Length];
        questEndStuff.SetActive(false);
        for (i= 0;i<quests.Length;i++)
        {
            if (PlayerPrefs.HasKey("Quest"+i))
            {
                if(PlayerPrefs.GetInt("Quest"+i)==1)
                {
                    questCompleted[i] = true;
                }
                else
                {
                    questCompleted[i] = false;
                }
                
            }
            else
            {
                PlayerPrefs.SetInt("Quest" + i, 0);
                {
                    questCompleted[i] = false;
                }
            }
        }
	}
	

	void Update ()
    {
		
	}
    public void ShowQuestText(string QuestText,int goldReward,int expReward)
    {
       
        if(goldReward!=0)
        {
            theDm.questEndGoldtxt.text = "Gold:" + goldReward;

        }
        else
        {
            theDm.questEndGoldtxt.text = "";
        }
        if(expReward!=0)
        {
            theDm.questEndExptxt.text = "Exp:" + expReward;
        }
        else
        {
            theDm.questEndExptxt.text = "";
        }

        theDm.dialogoueLines = new string[1];
        theDm.dialogoueLines[0] = QuestText;

        theDm.currentLine = 0;
        theDm.hasToShowquestendstuff = true;
        theDm.ShowDialogoue();
    }
}
