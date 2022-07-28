using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Reference to Currency")]
    public Currency currencyRef;
    
    [Header("Reference to Inventory")]
    public Inventory inventoryRef;
    
    [Header("Buy Buttons")]
    public GameObject TurretButton;
    public GameObject HealthButton;
    public GameObject AmmoButton;
    public GameObject WallButton;

    public void BuyHealth(GameObject HealthItem)
    {
        if (currencyRef.PlayerCurrency >= 3)
        {
            for (int i = 0; i < inventoryRef.Slots.Length; i++)
            {
                if (inventoryRef.isFull[i] == false)
                {
                    currencyRef.LoseCurrecny(3);
                    inventoryRef.isFull[i] = true;
                    Instantiate(HealthItem, inventoryRef.Slots[i].transform, false);
                    break;
                }
            }
        }

     
    }
    public void BuyAmmo(GameObject AmmoItem)
    {
        //Add to inventory 
        if (currencyRef.PlayerCurrency >= 3)
        {
            for (int i = 0; i < inventoryRef.Slots.Length; i++)
            {
                if (inventoryRef.isFull[i] == false)
                {
                    currencyRef.LoseCurrecny(3);
                    inventoryRef.isFull[i] = true;
                    Instantiate(AmmoItem, inventoryRef.Slots[i].transform, false);
                    break;
                }
            }
        }
    }

    public void BuyTurret(GameObject TurretItem)
    {
        
        //Add to inventory 
        if (currencyRef.PlayerCurrency >= 3)
        {
            for (int i = 0; i < inventoryRef.Slots.Length; i++)
            {
                if (inventoryRef.isFull[i] == false)
                {
                    currencyRef.LoseCurrecny(3);
                    inventoryRef.isFull[i] = true;
                    Instantiate(TurretItem, inventoryRef.Slots[i].transform, false);
                    break;
                }
            }
        }
    }

    public void BuyWall(GameObject WallItem)
    {
        //Add to inventory 
        if (currencyRef.PlayerCurrency >= 3)
        {
            for (int i = 0; i < inventoryRef.Slots.Length; i++)
            {
                if (inventoryRef.isFull[i] == false)
                {
                    currencyRef.LoseCurrecny(3);
                    inventoryRef.isFull[i] = true;
                    Instantiate(WallItem, inventoryRef.Slots[i].transform, false);
                    break;
                }
            }
        }
    }
}
