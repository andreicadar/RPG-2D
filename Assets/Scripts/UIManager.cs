using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePs;
    public Text levelText;
    private static bool UIExists;
    public Slider xpBar;
    public Text xpText;
    public Text moneyText;
    public GameObject ds;



    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePs = GetComponent<PlayerStats>();
        xpBar.minValue = 0;

    }


    void Update()
    {
        moneyText.text = "Gold: " + thePs.money;
        xpBar.maxValue = thePs.ToLevelUp[thePs.currentLevel];
        xpBar.value = thePs.currentExp;
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        xpText.text = "" + thePs.currentExp + "/" + thePs.ToLevelUp[thePs.currentLevel];
        levelText.text = "Lvl: " + thePs.currentLevel;
    }

    public void Quit()
    {
        Application.LoadLevel("MainMenu");
        ds.SetActive(false);
        
    }
}
   

