using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public Sprite[] imagini;
    public Image imagine;
    private string lastlvl;

    public GameObject StartButton;
    public GameObject ChangeName;
    public GameObject Credits;
    public GameObject NameSpace;
    public GameObject Bac;
    public GameObject resetBut;
    public Text nume;
    public PlayerController pc;
    public PlayerStats ps;

    void Start ()

    {
        
        imagine.sprite = imagini[Random.Range(0, imagini.Length)];
        //Destroy(GameObject.Find("Player"));
        
	}
	
	// Update is called once per frame
	void Update () {
        //PlayerPrefs.SetString("lastlvl", "MainMenu");
        //pc.ok = false;
    }

    public void StartGame()
    {
        
        Application.LoadLevel("Village");
        pc.lastlvl = "Village";
        ps.lastPos = "Start";
    }
    public void ChangeNam()
    {
        StartButton.SetActive(false);
        ChangeName.SetActive(false);
        Credits.SetActive(false);
        resetBut.SetActive(false);
        NameSpace.SetActive(true);
        Bac.SetActive(true);
    }
    public void Back()
    {
         PlayerPrefs.SetString("name", nume.text);
        Debug.Log(nume.text);
        StartButton.SetActive(true);
        ChangeName.SetActive(true);
        Credits.SetActive(true);
        resetBut.SetActive(true);
        NameSpace.SetActive(false);
        Bac.SetActive(false);
       
    }
    public void CreditsF()
    { Application.LoadLevel("Credits"); }
    public void ResetBut()
    {
        PlayerPrefs.DeleteAll();
    }
    
   
}
