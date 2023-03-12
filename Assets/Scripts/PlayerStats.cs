using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

   public PlayerHealthManager thePlayerHeath;

    public int currentLevel=1;
    public int currentExp;

    public int[] ToLevelUp;

    public int[] HPLevels;
    public int[] atackLevels;
    public int[] defenceLevels;

    public int currentHp;
    public int currentAtack;
    public int currentDefence;

    public float damagePotionTime;
    private int defaultDamage;
    public int damageBuff_DebuffPercent;

    public float arrmorPotionTime;
    private int defaultArrmor;
    public int arrmorBuff_DebuffPercent;

    public float healingPotionTime;
    public int healPerSec;

    public int money;

    private bool ok;

    public PlayerHealthManager ph;
    public HurtEnemy he;
    public GameObject deathScreen;

    public PlayerController pc;
    public GameObject player;
    public string lastPos;

    private bool dejaNumara = false;
    private int count = 0;
    public int bonus;
    public GameObject pla;
    public TextMesh name;
    private int healthBonus;
    private bool playerStats;
    public GameObject playerStatsText;
    public GameObject playerStatsButton;

    public Text MaxHp;
    public Text DefaultAttack;
    public Text DamageperHit;
    public Text Arrmor;
    public Text Crit;
    public Text BurnorFr;
    public Text SlowCh;



   

   void Awake()
    {
      
    }


    void Start ()
    {
        playerStats = false;
        playerStatsText.SetActive(playerStats);
        playerStatsButton.SetActive(!playerStats);
        //  PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("lastpos"))
        {
            lastPos = PlayerPrefs.GetString("lastpos");
        }
        else
        {
            PlayerPrefs.SetString("lastpos","Start");
            {
                lastPos = "FirstStart";
            }
        }
        pc.startPoint = lastPos;
       


        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
            {
                money = 0;
            }
        }
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("PlayerLevel");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerLevel", 1);
            {
                currentLevel = 1;
            }
        }
      
     

        if (PlayerPrefs.HasKey("PlayerAttack"))
        {
            currentAtack = PlayerPrefs.GetInt("PlayerAttack");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerAttack", atackLevels[currentLevel]);
            {
                currentAtack = atackLevels[currentLevel];
               
            }
        }

        if (PlayerPrefs.HasKey("PlayerDefense"))
        {
            currentDefence = PlayerPrefs.GetInt("PlayerDefense");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerDefense", defenceLevels[currentLevel]);
            {
                currentDefence = defenceLevels[currentLevel];
            }
        }

        if (PlayerPrefs.HasKey("HealthBonus"))
            healthBonus = PlayerPrefs.GetInt("HealthBonus");
        else
        {
            PlayerPrefs.SetInt("HealthBonus", 0);
        }

        if (PlayerPrefs.HasKey("CurrentHealth"))
        {
            currentHp = PlayerPrefs.GetInt("CurrentHealth");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentHealth", HPLevels[1]);
        }

        if (PlayerPrefs.HasKey("PlayerMaxHealth"))
        {
            thePlayerHeath.SetMaxHealth(HPLevels[currentLevel]);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerMaxHealth", HPLevels[currentLevel]);
        }


      

        if (PlayerPrefs.HasKey("PlayerExperience"))
        {
            currentExp = PlayerPrefs.GetInt("PlayerExperience");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerExperience", 0);
            
                currentExp = 0;
            
        }
        defaultDamage = currentAtack;
        defaultArrmor = currentDefence;
        string lastlvl;
        if (PlayerPrefs.HasKey("lastlvl"))
        {
            lastlvl = PlayerPrefs.GetString("lastlvl");
        }
        else
        {
            PlayerPrefs.SetString("lastlvl", "Village");
            {
                lastlvl = "Village";

            }
        }


        lastPos = "Start";
        if (name.text == "bani")
            money += 1000;

       // Debug.Log(healthBonus);
    }
	
	
	void Update ()
    {
        UpdateStats();
       

        if (damagePotionTime > 0)
        {
            if(currentAtack==defaultDamage)
            {
                currentAtack += (( he.weaponDamage+defaultDamage) * damageBuff_DebuffPercent) / 100;
            }
            damagePotionTime -= Time.deltaTime;
        }
        else
        {
            damagePotionTime = 0;
            currentAtack = defaultDamage;
        }

        if(arrmorPotionTime >0)
        {
            if(currentDefence == defaultArrmor)
            {
                currentDefence += (defaultArrmor * arrmorBuff_DebuffPercent) / 100;
            }
            arrmorPotionTime -= Time.deltaTime;
        }
        else
        {
            arrmorPotionTime = 0;
            currentDefence = defaultArrmor;
        }

        if (healingPotionTime > 0)
        {
            if (ok == false)

            {
                healPerSec = (healPerSec *  (HPLevels[currentLevel]+healthBonus))/100;
                ok = true;
                //Debug.Log(healPerSec);
            }


            int i;
            float sec = 1;
            
            for (i = 1; i <= healingPotionTime; i++)
            {
                if(dejaNumara==false)
                StartCoroutine(stai());
            }
            Debug.Log(count);
            Debug.Log(healingPotionTime);
        }
        if(count==healingPotionTime)
        
        {
            healingPotionTime = 0;
            ok = false;
            count = 0;
        }

        if (currentExp>=ToLevelUp[currentLevel]&&currentLevel<19)
        {
            LevelUp();          
        }
        if(ph.playerCurrentHealth<1)
        {
            deathScreen.SetActive(true);
            pc.StopPlayer();
        }
      //  bonus = PlayerPrefs.GetInt("HealthBonus");
       // Debug.Log(bonus);
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
        PlayerPrefs.SetInt("PlayerExperience", currentExp);
    }

    public void LevelUp()
    {
        currentExp = 0;
        currentLevel++;
        PlayerPrefs.SetInt("PlayerLevel", currentLevel);
        PlayerPrefs.SetInt("PlayerExperience", currentExp);

        currentHp = HPLevels[currentLevel];
        currentAtack = atackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
        thePlayerHeath.SetMaxHealth(HPLevels[currentLevel]);

        PlayerPrefs.SetInt("CurrentHealth", currentHp);

        PlayerPrefs.SetInt("PlayerMaxHealth", HPLevels[currentLevel]);

        PlayerPrefs.SetInt("PlayerDefense", defenceLevels[currentLevel]);

        PlayerPrefs.SetInt("PlayerAttack", atackLevels[currentLevel]);
        
      bonus = PlayerPrefs.GetInt("HealthBonus");
        


        ph.playerMaxHealth = HPLevels[currentLevel] + bonus;

    }
    public void Respawn()
    {
        Application.LoadLevel(pc.lastlvl);
        lastPos = pc.startPoint;
        PlayerPrefs.SetString("lastpos", lastPos);
        player.transform.position = GameObject.Find(lastPos).transform.position;
       // Debug.Log(lastPos);
        currentHp = HPLevels[currentLevel] + healthBonus;
        ph.playerCurrentHealth = currentHp;
        deathScreen.SetActive(false);
        PlayerPrefs.SetInt("CurrentHealth", currentHp-healthBonus);
        money -= money / 2;
        PlayerPrefs.SetInt("Money", money);
    }

    public void QMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    private IEnumerator stai()
    {

        dejaNumara = true;
        // process pre-yield
        yield return new WaitForSeconds(1.0f);
        count++;
        if (thePlayerHeath.playerCurrentHealth + healPerSec > (HPLevels[currentLevel]+thePlayerHeath.bonus))
            thePlayerHeath.playerCurrentHealth = (HPLevels[currentLevel]+ph.bonus);
        else
            thePlayerHeath.playerCurrentHealth += healPerSec;
        PlayerPrefs.SetInt("CurrentHealth", thePlayerHeath.playerCurrentHealth);
        dejaNumara = false;

    }
    public void SwitchStats()
    {
        playerStats = (!playerStats);
            playerStatsText.SetActive(playerStats);
        UpdateStats();

       // playerStatsButton.SetActive(!playerStats);
    }
   public  void UpdateStats()
    {
        MaxHp.text = "MaxHP: " + thePlayerHeath.playerMaxHealth;
        DefaultAttack.text = "DefaultAttack: " + currentAtack;
       // Debug.Log(he.weaponDamage);
        DamageperHit.text = "Damage per Hit: " + (currentAtack + he.weaponDamage);
        Arrmor.text = "Arrmor: " + currentDefence;
        Crit.text = "Crit Chance: "+he.chanceOfCrit;
        SlowCh.text = "Slow Chance: "+he.chanceOfSlow;
        BurnorFr.text = "Burn or Frostbite Chance:" + he.weaponBurnOrFrostchance;
    }

}
