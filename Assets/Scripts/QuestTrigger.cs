using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

    private QuestManager theQm;

    public int questNumber;



	void Start ()
    {
        theQm = FindObjectOfType<QuestManager>();
	}
	
	
	void Update ()
    {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(!theQm.questCompleted[questNumber])
            {
                if( theQm.quests[questNumber].gameObject.activeSelf)
                {
                    theQm.quests[questNumber].EndQuest();
                }
            }
        }
    }
}
