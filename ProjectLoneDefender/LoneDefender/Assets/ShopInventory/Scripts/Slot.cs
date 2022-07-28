using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isHealth;
    
    public bool isAmmo;

    public PlayerController player;
    public PlayerWeapons weapon;

    private Inventory MyInventory;

    public int i;
    
    public bool slot1;
    public bool slot2;
    public bool slot3;
    public bool slot4;
    public bool slot5;
    public bool slot6;
    public bool slot7;
    
    public int healthCount;
    public int ammoCount;
   // public bool[] slotchecks;
   // public GameObject[] mySlots;
    private void Awake()
    {
        player = GameObject.Find("First Person Player").GetComponent<PlayerController>();
        weapon = GameObject.Find("PlayerGun").GetComponent<PlayerWeapons>();
        MyInventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            MyInventory.isFull[i] = false;
        }

        if (healthCount == 0)
        {
            isHealth = false;
        }
        
        if (ammoCount == 0)
        {
            isAmmo = false;
        }
    }

    public void DropItem()
    {
        if (isHealth && player.PlayerHealthBar.value <= 90 &&  healthCount >= 1 )
        {
            Debug.Log("Give Health");
            player.PlayerHealthBar.value += 10;
            foreach (Transform child in transform)
            {
                healthCount -= 1;
                GameObject.Destroy(child.gameObject);
            }
        }

        if (isAmmo && weapon.AmmoAmount <= 40 &&  ammoCount >= 1)
        {
            weapon.AmmoAmount += 10;
            foreach (Transform child in transform)
            {
                ammoCount -= 1;
                GameObject.Destroy(child.gameObject);
            }
        }
        
    }
}
