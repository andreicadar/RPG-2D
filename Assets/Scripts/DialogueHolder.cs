using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogoueManager dMan;
    private PlayerController thePlayer;
    public bool dialogueHasQuest;
    public string questDialog;
    public int questNumber;
    public bool dialogHasShop;

    public int numberOfItems;
    public int[] itemPrices;
    public Sprite[] itemSprites;
    public string[]  itemNames;
    public int currentDialog;
    public string whoGaveTheQuest;
    public string[] endText;
    public GameObject chooseQuest;


    private Button buton;

    [System.Serializable]
    public class Texts
    {
        public string[] dialog;
        public string questDialog;
        public int  questNumber;
    }


    public Texts[] dialogueLines;

	void Start ()
    {

    // chooseQuest = GameObject.Find()
        whoGaveTheQuest = transform.parent.name;
      
        thePlayer = FindObjectOfType<PlayerController>();
        dMan = FindObjectOfType<DialogoueManager>();
        if (PlayerPrefs.HasKey(transform.parent.name))
        {
            currentDialog = PlayerPrefs.GetInt(transform.parent.name);
        }
        else
        {
            PlayerPrefs.SetInt(transform.parent.name, 0);
            {
                currentDialog = 0;
            }
        }
        if (currentDialog >= dialogueLines.Length)
            currentDialog=dialogueLines.Length;
        else
       
        updateDialog();
       

    }
  


    void Update()
    {
    }
    public void updateDialog()
    {
        if (currentDialog < dialogueLines.Length)

        {
            //Debug.Log("c"+currentDialog);
            //Debug.Log("l"+dialogueLines.Length);
            questNumber = dialogueLines[currentDialog].questNumber;
            questDialog = dialogueLines[currentDialog].questDialog;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        int i;
       
        
        if (other.gameObject.name == "Player") 
        {
            
                if (Input.GetKeyUp(KeyCode.Space))
                     {
                
                if (PlayerPrefs.HasKey(transform.parent.name))
                {
                    currentDialog = PlayerPrefs.GetInt(transform.parent.name);
                }
                else
                {
                    PlayerPrefs.SetInt(transform.parent.name, 0);
                    {
                        currentDialog = 0;
                    }
                }
                updateDialog();
                

                dMan.wasLast = false;

                    thePlayer.anim.SetBool("PlayerMoving", false);
                    if (!dMan.dialogActive)
                    {
                   
                        if (currentDialog == dialogueLines.Length)

                        {
                    //    Debug.Log(currentDialog);

                        dMan.dialogoueLines = endText;
                       
                        

                        }
                        else

                        {

                           
                            dMan.dialogoueLines = dialogueLines[currentDialog].dialog;
                        dMan.questNumber = dialogueLines[currentDialog].questNumber;

                    }

                    dMan.whoGaveTheQuest = whoGaveTheQuest;
                    dMan.dialogNumber = currentDialog;
                    dMan.dialogActive = true;
                    dMan.dialogueHasQuest = dialogueHasQuest;
                    dMan.currentLine = -1;
                    dMan.dialogHasShop = dialogHasShop;
                    if (dialogHasShop)
                        {
                            dMan.numberOfItems = numberOfItems;
                            for (i = 0; i < numberOfItems; i++)
                            {

                                dMan.itemSprites[i] = itemSprites[i];
                                dMan.itemPrices[i] = itemPrices[i];
                                dMan.itemNames[i] = itemNames[i];
                            }
                        }
                        dMan.questText.text = questDialog;
                        dMan.questNumber = questNumber;
                        dMan.ShowDialogoue();
                    }
                    if (transform.parent.GetComponent<VillagerMovement>() != null)
                    {

                        transform.parent.GetComponent<VillagerMovement>().canMove = false;
                    }
                }
            
        }
    }
}
