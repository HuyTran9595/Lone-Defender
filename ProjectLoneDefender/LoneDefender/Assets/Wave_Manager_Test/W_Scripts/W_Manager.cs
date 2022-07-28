using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class W_Manager : MonoBehaviour
{

    public GameObject WavePanel;
    public GameObject CountdownPanel;

    public Text WaveText;
    public Text EnemyText;
    
    public Transform [] theEnemy;
    public Transform[] SpawnPoints;

    public bool Trigger;
    private int randomSpawnPoint;
    private int RandomEnemy;

    public int EnemyAmount;

    public int WaveCount;
    
    public float timeLeft = 3.0f;
    public Text startText;
    public bool Countdown;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            KillEnemy();
        }
        NextWave();
        Mywaves();
    }

    void EnemySpawn(int enemies, Transform EnemyForWave)
    {
        Trigger = false;
        for (var i = 0; i < enemies; i++)
        {
            randomSpawnPoint = Random.Range(0, SpawnPoints.Length);
            Instantiate(EnemyForWave, SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
            EnemyAmount += 1;
        }
        
    }

    void NextWave()
    {
        if (Countdown)
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
        }
        
        if (timeLeft <= 0 && EnemyAmount <= 0)
        {
                WavePanel.SetActive(true);
                CountdownPanel.SetActive(false);
                WaveCount += 1;
                Countdown = false;
                Trigger = true;
                timeLeft = 5;
        } else if (EnemyAmount <= 0)
        {
                WavePanel.SetActive(false);
                CountdownPanel.SetActive(true);
                Countdown = true;
        }

    }

    public void KillEnemy()
    {
        EnemyAmount -= 1;
    }

    void Mywaves()
    {
        WaveText.text = WaveCount.ToString();
        EnemyText.text = EnemyAmount.ToString();
        RandomEnemy = Random.Range(0, theEnemy.Length);  
        
        if(Trigger == true && Countdown == false) //The bool we just made
        {
            
            if(WaveCount == 1)
            {
                EnemySpawn(5, theEnemy[RandomEnemy]);
            }
        }
        
        if(Trigger == true) //The bool we just made
        {
            if(WaveCount == 2)
            {
                EnemySpawn(5, theEnemy[RandomEnemy]);
            }
        }
        
        if(Trigger == true) //The bool we just made
        {
            if(WaveCount == 3)
            {
                EnemySpawn(5, theEnemy[RandomEnemy]);
            }
        }
        
        if(Trigger == true) //The bool we just made
        {
            if(WaveCount == 4)
            {
                EnemySpawn(5, theEnemy[RandomEnemy]);
            }
        }
        
        if(Trigger == true) //The bool we just made
        {
            if(WaveCount == 5)
            {
                EnemySpawn(5, theEnemy[RandomEnemy]);
            }
        }
    }
    
    
}
