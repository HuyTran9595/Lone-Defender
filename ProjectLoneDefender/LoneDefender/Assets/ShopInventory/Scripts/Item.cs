using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Item : MonoBehaviour
{
    public Inventory inventory;

    public GameObject itemButton;

    public bool health;

    public bool ammo;

    public Slot[] slot;
    
    
    public GameObject ThePlayer;
    
    public int healthCount;
    public int ammoCount;
    // Start is called before the first frame update
    void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
        slot = GameObject.FindObjectsOfType<Slot>().OrderBy(m => m.transform.GetSiblingIndex()).ToArray();
        ThePlayer = GameObject.Find("First Person Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForAmmo();
        CheckForHealth();
    }
    private void OnTriggerEnter(Collider other) //Only Can be used if in game dropbable item
    {
        if (ThePlayer.gameObject.tag == ("Player") && health)
        {
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    AddSlotHealthInt();
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.Slots[i].transform, false);
                    Destroy(gameObject, .2f);
                    break;
                }
            }
        }
        
        if (ThePlayer.gameObject.tag == ("Player") && ammo)
        {
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    AddSlotAmmoInt();
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.Slots[i].transform, false);
                    Destroy(gameObject, .1f);
                    break;
                }
            }
        }
            
    }

    void CheckForHealth()
    {

        if (health && slot[0].healthCount >= 1)
        {
            slot[0].isHealth = true;
        }
        if (health && slot[1].healthCount >= 1)
        {
            slot[1].isHealth = true;
        }
        if (health && slot[2].healthCount >= 1)
        {
            slot[2].isHealth = true;
        }
        if (health && slot[3].healthCount >= 1)
        {
            slot[3].isHealth = true;
        }
        if (health && slot[4].healthCount >= 1)
        {
            slot[4].isHealth = true;
        }
        if (health && slot[5].healthCount >= 1)
        {
            slot[5].isHealth = true;
        }
        if (health && slot[6].healthCount >= 1)
        {
            slot[6].isHealth = true;
        }
        
        
    }

    void CheckForAmmo()
    {
        if (ammo && slot[0].ammoCount >= 1)
        {
            slot[0].isAmmo = true;
        }
        if (ammo && slot[1].ammoCount >= 1)
        {
            slot[1].isAmmo = true;
        }
        if (ammo && slot[2].ammoCount >= 1)
        {
            slot[2].isAmmo = true;
        }
        if (ammo && slot[3].ammoCount >= 1)
        {
            slot[3].isAmmo = true;
        }
        if (ammo && slot[4].ammoCount >= 1)
        {
            slot[4].isAmmo = true;
        }
        if (ammo && slot[5].ammoCount >= 1)
        {
            slot[5].isAmmo = true;
        }
        if (ammo && slot[6].ammoCount >= 1)
        {
            slot[6].isAmmo = true;
        }
    }

    void AddSlotHealthInt()
    {

        for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Slot myslots= slot[i].gameObject.GetComponent<Slot>();
                    myslots.healthCount += 1;
                    inventory.isFull[i] = true;
                    break; 
                }
            }
    }
    
    void AddSlotAmmoInt() 
    {

        for (int i = 0; i < inventory.Slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                Slot myslots= slot[i].gameObject.GetComponent<Slot>();
                myslots.ammoCount += 1;
                inventory.isFull[i] = true;
                break; 
            }
        }
    }
    
}
