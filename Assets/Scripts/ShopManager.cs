using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public int numberOfSlots;
    public Text priceText;
    public Image itemImage;
    public Text itemName;

    public GameObject[] slots;
    public Sprite[] imagesOfSlots;
    public int[] prices;
    public string[] names;
    public Image[] buton;
    public Text itemDescriptionText;

    public PlayerStats thePs;
    private int currentPrice;
    public QuickInventory Qv;
    public Sprite currentSprite;
    public DialogoueManager theDm;


   public void Start ()
    {
        int i;



      for (i = numberOfSlots; i < slots.Length; i++)
        {
            slots[i].SetActive(false);
        }
        for (i = 0; i < numberOfSlots; i++)
        {
            slots[i].SetActive(true);
        }
        priceText.text = "Price: "+prices[0];
        itemImage.sprite = imagesOfSlots[0];
        itemName.text = names[0];
        ItemDescitpion(0);
        currentPrice = prices[0];
        currentSprite = imagesOfSlots[0];
        
    }
	
	
	void Update ()
    {
        
    }
    void ItemDescitpion(int i)
    {
        itemDescriptionText.text = itemName.text;
        if (itemName.text=="Iron Dagger")
        {
            itemDescriptionText.text += "  3 damage, better than bare hands";
        }
        else
        if (itemName.text == "Fire Dagger")
        {
            itemDescriptionText.text += "  10 damage, can inflict burn on enemies";
        }
        else
        if (itemName.text == "Ice Dagger")
        {
            itemDescriptionText.text += "  10 damage, can inflict slow on enemies and sometimes even stun them";
        }
        else
        if (itemName.text == "Iron Sword")
        {
            itemDescriptionText.text += "  5 damage, just a bigger dagger that can critical attack";
        }
        else
        if (itemName.text == "Fire Sword")
        {
            itemDescriptionText.text += "  15 damage, can inflict burn on enemies and sometimes critical attack";
        }
        else
        if (itemName.text == "Ice Sword")
        {
            itemDescriptionText.text += "  15 damage, can inflict slow on enemies and sometimes even stun them or even critical attack";
        }
        else

        if (itemName.text == "Iron Axe")
        {
            itemDescriptionText.text += "  10 damage, no one stays in your way, can stun and critical attack";
        }
        else
        if (itemName.text == "Fire Axe")
        {
            itemDescriptionText.text += "  25 damage,can inflict burn or stun on enemies  and sometimes critical attack ";
        }
        else
        if (itemName.text == "Ice Axe")
        {
            itemDescriptionText.text += "  25 damage,can inflict slow, frostbites or stun on enemies  and sometimes critical attack ";
        }
        else
             if (itemName.text == "Orange Potion")
        {
            itemDescriptionText.text += " increases damage by 20% for 20 seconds";
        }
        else
             if (itemName.text == "Yellow Potion")
        {
            itemDescriptionText.text += " increases movement speed by 50% for 20 seconds";
        }
        else
        if (itemName.text == "Blue Potion")
        {
            itemDescriptionText.text += " doubles arrmor for 5 seconds";
        }
        else
        if (itemName.text == "Green Potion")
        {
            itemDescriptionText.text += " heals 50% of hp in 10 seconds";
        }
        else
        if (itemName.text == "Stew")
        {
            itemDescriptionText.text += " increases movement speed arrmor and damage by 10% for 10 seconds";
        }
        else
        if (itemName.text == "Spinach")
        {
            itemDescriptionText.text += " invulnerable for 5 seconds, you can move";
        }
        else
        if (itemName.text == "Cereals")
        {
            itemDescriptionText.text += " increases max HP by 1";
        }
        else
        if (itemName.text == "Wine")
        {
            itemDescriptionText.text += " can do miracles";
        }


    }
    void UpdateCurrentSlot(int i)
    {
       
        priceText.text = "Price: " + prices[i];
        itemImage.sprite = imagesOfSlots[i];
        itemName.text = names[i];
        ItemDescitpion(i);
        currentPrice = prices[i];
        currentSprite = imagesOfSlots[i];
    }
    public void Slot0()
    {
        UpdateCurrentSlot(0);
    }
    public void Slot1()
    {
        UpdateCurrentSlot(1);
    }
    public void Slot2()
    {
        UpdateCurrentSlot(2);
    }
    public void Slot3()
    {
        UpdateCurrentSlot(3);
    }
    public void Slot4()
    {
        UpdateCurrentSlot(4);
    }
    public void Slot5()
    {
        UpdateCurrentSlot(5);
    }
    public void Slot6()
    {
        UpdateCurrentSlot(6);
    }
    public void Slot7()
    {
        UpdateCurrentSlot(7);
    }
    public void Slot8()
    {
        UpdateCurrentSlot(8);
    }
    public void Slot9()
    {
        UpdateCurrentSlot(9);
    }
    public void Slot10()
    {
        UpdateCurrentSlot(10);
    }
    public void Slot11()
    {
        UpdateCurrentSlot(11);
    }
    public void XButton()
    {
        gameObject.SetActive(false);
        theDm.dialogHasShop = false;
    }
    public void BuyButton()
    {
      
        theDm.dialogHasShop = false;
        if (thePs.money>=currentPrice && Qv.numberOfFreeSlots>0)
        {
           
            thePs.money -= currentPrice;
            PlayerPrefs.SetInt("Money", thePs.money);
            Qv.numberOfFreeSlots-- ;
            PlayerPrefs.SetInt("QvFreeSlots", Qv.numberOfFreeSlots);
            if (Qv.st.sprite.name == "UIMask")
            {
                Qv.st.sprite = currentSprite;
                Qv.ChangeSlot(1);
            }
            else if( Qv.nd.sprite.name == "UIMask")
                {
                    Qv.nd.sprite = currentSprite;
                Qv.ChangeSlot(2);
            }
            else
                if (Qv.rd.sprite.name == "UIMask")
            {
                Qv.rd.sprite = currentSprite;
                Qv.ChangeSlot(3);
            }


        }
    }

}
