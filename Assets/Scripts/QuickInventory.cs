using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickInventory : MonoBehaviour {

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public SpriteRenderer currentWeapon;

    private int currentSlot;

    public HurtEnemy hE;
    public PlayerStats Ps;
    public PlayerController Pc;
    public PlayerHealthManager ph;
    
    public Image st;
    public Image nd;
    public Image rd;

    public int numberOfFreeSlots;

    public Sprite[] allSprites;
    private int slot1pos;
    private int slot2pos;
    private int slot3pos;

    public SpriteRenderer weaponSwing;
    public Sprite swingBig;
    public Sprite swingSmall;
    public int healthBonus = 0;

    public AudioSource healPotion;
    public AudioSource dmgPotion;


    void Start ()
    {
        //PlayerPrefs.DeleteAll();

        st = slot1.GetComponent<Image>();
        nd = slot2.GetComponent<Image>();
        rd = slot3.GetComponent<Image>(); 

        if (PlayerPrefs.HasKey("QvFreeSlots"))
        {
            numberOfFreeSlots = PlayerPrefs.GetInt("QvFreeSlots");
        }
         else
        {
            PlayerPrefs.SetInt("QvFreeSlots", 3);
            {
                numberOfFreeSlots = 3;
            }
        }

        if (PlayerPrefs.HasKey("Slot1"))
        {
          slot1pos   = PlayerPrefs.GetInt("Slot1");
        }
        else
        {
            PlayerPrefs.SetInt("Slot1", allSprites.Length-1);
            {
                slot1pos = allSprites.Length - 1;
                st.sprite = allSprites[allSprites.Length - 1];
            }
        }

        if (PlayerPrefs.HasKey("Slot2"))
        {
            slot2pos = PlayerPrefs.GetInt("Slot2");
        }
        else
        {
            PlayerPrefs.SetInt("Slot2", allSprites.Length - 1);
            {
                slot2pos = allSprites.Length - 1;
                nd.sprite = allSprites[allSprites.Length - 1];
            }
        }

        if (PlayerPrefs.HasKey("Slot3"))
        {
            slot3pos = PlayerPrefs.GetInt("Slot3");
        }
        else
        {
            PlayerPrefs.SetInt("Slot3", allSprites.Length - 1);
            {
                slot3pos = allSprites.Length - 1;
                rd.sprite = allSprites[allSprites.Length - 1];
            }
        }

        currentSlot = 1;
        st.sprite = allSprites[slot1pos];
        nd.sprite = allSprites[slot2pos];
        rd.sprite = allSprites[slot3pos];
        currentWeapon.GetComponent<SpriteRenderer>();
        currentWeapon.sprite = st.sprite;
        ChangeSlot(1);
    }
	
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSlot = 1;
            ChangeSlot(currentSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSlot = 2;
            ChangeSlot(currentSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSlot = 3;
            ChangeSlot(currentSlot);
        }
    }
  public  void ChangeSlot(int slot)
    {
        if (slot == 1)
        {
            currentWeapon.sprite = st.sprite;
            currentSlot = 1;
            
        }
        if (slot == 2)
        {
            currentWeapon.sprite = nd.sprite;
            currentSlot = 2;
        }
        if (slot == 3)
        {
            currentWeapon.sprite = rd.sprite;
            currentSlot = 3;
                }
        if(currentWeapon.sprite.name == "UIMask")
        {
            PlayerPrefs.SetInt("Slot" + slot, allSprites.Length - 1);
            Pc.canAtack = true;
            hE.weaponDamage = 0;
            hE.weaponBurnOrFrostchance = 0;
            hE.weaponBurnOrFrostbites = 0;
            hE.chanceOfCrit = 0;
            hE.slowPercent = 0;
            hE.slowTime = 0;
            hE.chanceOfSlow = 0;
            weaponSwing.sprite = swingSmall; 
        }
        if (currentWeapon.sprite.name != "UIMask")
        {

            if (currentWeapon.sprite.name == "dagger_iron")
            {
                PlayerPrefs.SetInt("Slot"+slot, 0);
                Pc.canAtack = true;
                hE.weaponDamage = 3;
                hE.weaponBurnOrFrostchance = 0;
                hE.weaponBurnOrFrostbites = 0;
                hE.chanceOfCrit = 0;
                hE.slowPercent = 0;
                hE.slowTime = 0;
                hE.chanceOfSlow = 0;
                weaponSwing.sprite = swingSmall;
            }
            else
            if (currentWeapon.sprite.name == "dagger_fire")
            {
                PlayerPrefs.SetInt("Slot" + slot, 1);
                Pc.canAtack = true;
                hE.weaponDamage = 10;
                hE.weaponBurnOrFrostchance = 15;
                hE.weaponBurnOrFrostbites = 1;
                hE.chanceOfCrit = 0;
                hE.slowPercent = 0;
                hE.slowTime = 0;
                hE.chanceOfSlow = 0;
                weaponSwing.sprite = swingSmall;
            }
            if (currentWeapon.sprite.name == "dagger_ice")
            {
                PlayerPrefs.SetInt("Slot" + slot, 2);
                Pc.canAtack = true;
                hE.weaponDamage = 10;
                hE.weaponBurnOrFrostchance = 0;
                hE.weaponBurnOrFrostbites = 0;
                hE.chanceOfCrit = 0;
                hE.slowPercent = 50;
                hE.slowTime = 3;
                hE.chanceOfSlow = 30;
                weaponSwing.sprite = swingSmall;
            }
            

            else
           if (currentWeapon.sprite.name == "sword_iron")
            {
                PlayerPrefs.SetInt("Slot" + slot, 3);
                Pc.canAtack = true;
                hE.weaponDamage = 5;
                hE.weaponBurnOrFrostchance = 0;
                hE.weaponBurnOrFrostbites = 0;
                hE.chanceOfCrit = 10;
                hE.slowPercent = 0;
                hE.slowTime = 0;
                hE.chanceOfSlow = 0;
                weaponSwing.sprite = swingBig;
            }
            else
        if (currentWeapon.sprite.name == "sword_fire")
            {
                PlayerPrefs.SetInt("Slot" + slot, 4);
                Pc.canAtack = true;
                hE.weaponDamage = 15;
                hE.weaponBurnOrFrostchance = 30;
                hE.weaponBurnOrFrostbites = 2;
                hE.chanceOfCrit = 10;
                hE.slowPercent = 0;
                hE.slowTime = 0;
                hE.chanceOfSlow = 0;
                weaponSwing.sprite = swingBig;
            }
            else
        if (currentWeapon.sprite.name == "sword_ice")
            {
                PlayerPrefs.SetInt("Slot" + slot, 5);
                Pc.canAtack = true;
                hE.weaponDamage = 15;
                hE.weaponBurnOrFrostchance = 0;
                hE.weaponBurnOrFrostbites = 0;
                hE.chanceOfCrit = 10;
                hE.slowPercent = 50;
                hE.slowTime = 3;
                hE.chanceOfSlow = 30;
                weaponSwing.sprite = swingBig;
            }

            if (currentWeapon.sprite.name == "axe_iron")
            {
                PlayerPrefs.SetInt("Slot" + slot, 6);
                Pc.canAtack = true;
                hE.weaponDamage = 10;
                hE.weaponBurnOrFrostchance = 0;
                hE.weaponBurnOrFrostbites = 0;
                hE.chanceOfCrit = 20;
                hE.slowPercent = 0;
                hE.slowTime = 0;
                hE.chanceOfSlow = 0;
                weaponSwing.sprite = swingBig;
            }
            else
                if (currentWeapon.sprite.name == "axe_fire")
            {
                PlayerPrefs.SetInt("Slot" + slot, 7);
                Pc.canAtack = true;
                hE.weaponDamage = 25;
                hE.weaponBurnOrFrostchance = 40;
                hE.weaponBurnOrFrostbites = 5;
                hE.chanceOfCrit = 25;
                hE.slowPercent = 0;
                hE.slowTime = 0;
                hE.chanceOfSlow = 0;
                weaponSwing.sprite = swingBig;
            }
            else
                if (currentWeapon.sprite.name == "axe_ice")
            {
                PlayerPrefs.SetInt("Slot" + slot, 8);
                Pc.canAtack = true;
                hE.weaponDamage = 25;
                hE.weaponBurnOrFrostchance = 30;
                hE.weaponBurnOrFrostbites = 5;
                hE.chanceOfCrit = 20;
                hE.slowPercent = 50;
                hE.slowTime = 3;
                hE.chanceOfSlow = 20;
                weaponSwing.sprite = swingBig;
            }
            else if(currentWeapon.sprite.name =="Yellow Potion")
            {
                PlayerPrefs.SetInt("Slot" + slot, 9);
                Pc.canAtack = false;
            }
            else if (currentWeapon.sprite.name == "Orange Potion")
            {
                PlayerPrefs.SetInt("Slot" + slot, 10);
                Pc.canAtack = false;
                
            }
            else if (currentWeapon.sprite.name == "Green Potion")
            {
                PlayerPrefs.SetInt("Slot" + slot, 11);
                Pc.canAtack = false;
                
            }
            else if (currentWeapon.sprite.name == "Cereals")
            {
                PlayerPrefs.SetInt("Slot" + slot, 15);
                Pc.canAtack = false;

            }

            Ps.UpdateStats();
        }

    }
    public void SeeBuff()
    {
        if (currentWeapon.sprite.name == "Yellow Potion")
        {
            Pc.percentOfSpeed = 50;
            Pc.slowTime = 20;
            currentWeapon.sprite = allSprites[allSprites.Length-1];
        }
        else
        if(currentWeapon.sprite.name =="Orange Potion")
        {
          //  dmgPotion.Play();
            Ps.damageBuff_DebuffPercent = 20;
            Ps.damagePotionTime = 20;
            currentWeapon.sprite = allSprites[allSprites.Length - 1];
        }
        else
        if (currentWeapon.sprite.name == "Blue Potion")
        {
            Ps.arrmorBuff_DebuffPercent = 100;
            Ps.arrmorPotionTime = 20;
            currentWeapon.sprite = allSprites[allSprites.Length - 1];
        }
        else
        if (currentWeapon.sprite.name == "Green Potion")
        {
          //  healPotion.Play();
            Ps.healPerSec = 5;
            Ps.healingPotionTime = 10;
            currentWeapon.sprite = allSprites[allSprites.Length - 1];
        }
        else
        if (currentWeapon.sprite.name == "Cereals")
        {
            currentWeapon.sprite = allSprites[allSprites.Length - 1];
            if (PlayerPrefs.HasKey("HealthBonus"))
                healthBonus = PlayerPrefs.GetInt("HealthBonus");
            else
            {
                PlayerPrefs.SetInt("HealthBonus", 0);
            }
            healthBonus++;
            PlayerPrefs.SetInt("HealthBonus", healthBonus);
           // Debug.Log("ok!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ph.playerCurrentHealth++;
            ph.playerMaxHealth++;
            ph.bonus++;
           
        }


        numberOfFreeSlots++;
        if (currentSlot == 1)
        {
            st.sprite = allSprites[allSprites.Length - 1];
            PlayerPrefs.SetInt("Slot1", allSprites.Length - 1);
        }
        else if (currentSlot == 2)
        {
            nd.sprite = allSprites[allSprites.Length - 1];
            PlayerPrefs.SetInt("Slot2", allSprites.Length - 1);
        }
        else
        {
            rd.sprite = allSprites[allSprites.Length - 1];
            PlayerPrefs.SetInt("Slot3", allSprites.Length - 1);
        }
        PlayerPrefs.SetInt("QvFreeSlots", numberOfFreeSlots);

    }
}
