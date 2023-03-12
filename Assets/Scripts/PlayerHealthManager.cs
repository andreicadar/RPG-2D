using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;

    private bool flashActive;
    public float flashLenghth;
    private float flashCounter;

    private SpriteRenderer playerSprite;
    private SFXManager sfxMan;
    public int bonus;

  
	
	void Start ()
    {
        playerCurrentHealth = PlayerPrefs.GetInt("CurrentHealth");
        playerSprite = GetComponent<SpriteRenderer>();
        sfxMan = FindObjectOfType<SFXManager>();
        if (PlayerPrefs.HasKey("HealthBonus"))
            bonus = PlayerPrefs.GetInt("HealthBonus");
        else
        {
            PlayerPrefs.SetInt("HealthBonus", 0);
        }
        playerCurrentHealth += bonus;
        playerMaxHealth += bonus;
    }
	
	
	void Update ()
    {
		if(playerCurrentHealth<=0)
        {
           // gameObject.SetActive(false);
            sfxMan.playerDead.Play();
        }
        if(flashActive)
        {

            if(flashCounter>flashLenghth*0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.5f);
            }
            else
            if(flashCounter>flashLenghth*0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter>0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.5f);

            }

            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
        }
        flashCounter -= Time.deltaTime;
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLenghth;

        sfxMan.playerHurt.Play();
        PlayerPrefs.SetInt("CurrentHealth",playerCurrentHealth);

    }
    public void SetMaxHealth(int maxhealth)
    {
        playerMaxHealth = maxhealth;
        PlayerPrefs.SetInt("PlayerMaxHealth", maxhealth);
       
        
    }
}
