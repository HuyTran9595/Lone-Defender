using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Slot isSlot;
    
    void Start()
    {

        isSlot = GetComponentInParent<Slot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isSlot.slot1)
        {
           // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && isSlot.slot2)
        {
            // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3) && isSlot.slot3)
        {
            // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4) && isSlot.slot4)
        {
            // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5) && isSlot.slot5)
        {
            // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6) && isSlot.slot6)
        {
            // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && isSlot.slot7)
        {
            // Button btn = this.GetComponent<Button>();
            //btn.onClick.AddListener(isSlot.DropItem);
            isSlot.DropItem();
        }
        
    }
}
