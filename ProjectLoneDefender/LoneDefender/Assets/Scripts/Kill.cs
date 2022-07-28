using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    [Header("Player Stats")]  //Reference to Characrer stats scriptable objects
    public CharacterStat PlayerStats;

    public int enemyHealth;

    public int enemyRange;

    public int enemyDamage;


    public W_Manager WaveRef;
    // Start is called before the first frame update

    private void Awake()
    {
        WaveRef = GameObject.Find("WaveManager").GetComponent<W_Manager>();
    }

    void Start()
    {
        enemyHealth = PlayerStats.characterHealth;
        enemyRange = PlayerStats.characterRange;
        enemyDamage = PlayerStats.characterDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            WaveRef.KillEnemy();
            Destroy(gameObject);
            WaveManager.instance.EnemyDied();
        }
    }
}
