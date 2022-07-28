using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int PlayerCurrency;
    public Text CurrencyText;
    void FixedUpdate()
    {
        CurrencyText.text = PlayerCurrency.ToString();
    }

    public void AddCurrecny(int add)
    {
        PlayerCurrency += add;
    }
    
    public void LoseCurrecny(int minus)
    {
        PlayerCurrency -= minus;
    }
}
