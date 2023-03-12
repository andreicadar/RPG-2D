using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public int questNumber;

    private QuestManager theQm;

    public string itemName;

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
            if(!theQm.questCompleted[questNumber] && theQm.quests[questNumber].gameObject.activeSelf)
            {
                theQm.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
