using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class BaseCore : MonoBehaviour
{
    
    [Header("Base Stats")]  //Reference to Characrer stats scriptable objects
    public CharacterStat BaseStats;
    
    [Header("Base Health")] //reference to player health slider UI
    public Slider BaseHealthBar;

    public GameObject LoseScreen;
    
    // Start is called before the first frame update
    void Awake()
    {
        SetBaseHealth();
    }

    // Update is called once per frame
    void Update()
    {
        BaseDeathCondition();
    }
    
    private void SetBaseHealth()
    {
        BaseHealthBar.value = BaseStats.characterHealth; //Player health bar/slider = Current character health
    }
    
    private void BaseDeathCondition() // If player health reaches 0 then die
    {
        if (BaseHealthBar.value <= 0)
        {
            LoseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
