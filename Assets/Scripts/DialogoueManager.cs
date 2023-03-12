using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public GameObject questBox;
    public Text questText;
    public Text questGoldtxt;
    public Text questExptxt;
    private QuestManager theQm;
    public bool dialogActive;

    public string[] dialogoueLines;
    public int currentLine;

    private PlayerController thePlayer;
 

    public bool dialogueHasQuest;
    public int  questNumber;
    public int questExp;
    public int questGold;

    public Text questEndGoldtxt;
    public Text questEndExptxt;
    public bool hasToShowquestendstuff;
    public GameObject showEnd;
    public GameObject quickInventory;
    public bool dialogHasShop;
    public GameObject shop;
   
    public int numberOfItems;
    public int[] itemPrices;
    public Sprite[] itemSprites;
    public string[] itemNames;
    public ShopManager theSm;

    public GameObject quickInv;
    public bool wasQuest;
    public int dialogNumber;
    public string whoGaveTheQuest;
    public bool wasLast;
    

    void Start ()
    {
        theSm.GetComponent<ShopManager>();
        theQm = FindObjectOfType<QuestManager>();
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	
	void Update ()
    {

        if (hasToShowquestendstuff)
        {
            dText.text = "";
            if (Input.GetKeyUp(KeyCode.Space))
            {
                quickInv.SetActive(true);
                hasToShowquestendstuff = false;
                showEnd.gameObject.SetActive(false);
                dBox.SetActive(false);
                thePlayer.canMove = true;

            }
        }

        if (questBox.active==true)
        {
            thePlayer.canMove = false;
        }

        if (dialogActive && Input.GetKeyUp(KeyCode.Space) && questBox.activeSelf == false) 
        {
            quickInv.SetActive(false);
            currentLine++;
        }
        
        if(currentLine>=dialogoueLines.Length )
        {

            if (!dialogueHasQuest)
            {

                quickInventory.SetActive(true);
                dialogActive = false;
                thePlayer.canMove = true;
           
            }
            dBox.SetActive(false);

            showEnd.SetActive(false);
            
            currentLine = 0;

           
            if (dialogueHasQuest && theQm.questCompleted[questNumber]==false && theQm.quests[questNumber].isActiveAndEnabled==false)
            {
                quickInventory.SetActive(false);
                questExp = theQm.quests[questNumber].expReward;
                questGold= theQm.quests[questNumber].goldReward;
                questExptxt.text = "Exp: " + questExp;
                questGoldtxt.text = "Gold: " + questGold; 
                questBox.SetActive(true);
                wasQuest = true;
            }
            else
                if(dialogueHasQuest)
            {
               
              
                CancelQuest();
            }
            else
                if(dialogHasShop)
                {
               
                    theSm.numberOfSlots = numberOfItems;
                theSm.Start();
                int i;
                    for(i=0;i<numberOfItems; i++)
                    {
                        theSm.imagesOfSlots[i] = itemSprites[i];
                        theSm.prices[i] = itemPrices[i];
                        theSm.names[i] = itemNames[i];
                         theSm.buton[i].sprite = itemSprites[i];
                         
                 
                    }
                  shop.SetActive(true);
                }
          

        }
        dText.text = dialogoueLines[currentLine];
        
	}

    public void ShowBox(string dialogue)
    {
        quickInventory.SetActive(false);
        if (hasToShowquestendstuff)
            showEnd.gameObject.SetActive(true);
        dText.text = dialogue;        
        dBox.SetActive(true);
    }
    public void ShowDialogoue()
    {
        quickInventory.SetActive(false);
        if (hasToShowquestendstuff)
        {
            showEnd.gameObject.SetActive(true);
        }
        thePlayer.canMove = false;
        dBox.SetActive(true);
    }
 public   void AcceptQuest()
    {
       
        if (!theQm.questCompleted[questNumber])
        {
            theQm.quests[questNumber].GetComponent<QuestObject>().dialogNumber = dialogNumber;
            theQm.quests[questNumber].GetComponent<QuestObject>().whoGaveTheQuest = whoGaveTheQuest;
            if (!theQm.quests[questNumber].gameObject.activeSelf)
            {
                theQm.quests[questNumber].gameObject.SetActive(true);

            }
        }
        questBox.SetActive(false);
        thePlayer.canMove = true;
        quickInventory.SetActive(true);
        dialogueHasQuest = false;
        dialogActive = false;
    }
    public void CancelQuest()
    {
        quickInventory.SetActive(true);
        questBox.SetActive(false);
        thePlayer.canMove = true;
        quickInventory.SetActive(true);
        dialogActive = false;
    }

}
