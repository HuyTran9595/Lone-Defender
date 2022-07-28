#region Directives
using UnityEngine;
using TMPro;
using System.Collections;
#endregion

public class WaveManager : MonoBehaviour
{
    #region Public Variables
    public static WaveManager instance;
    #endregion

    #region Private Variables
    private int curWaveNumber;
    private string curWaveName;
    private Wave[] allWaves;
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private TextMeshProUGUI waveNumText, EnemyCountText;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        curWaveNumber = 1;
        allWaves = Resources.LoadAll<Wave>("Data/Waves");
    }
    private void Start()
    {
        //GetWaveInfo(allWaves[curWaveNumber - 1]);
        GetWaveInfo(RetrieveWaveData()[0]);
    }

    #endregion

    #region Public Methods
    public Wave[] RetrieveWaveData()
    {
        Wave[] wave = null;
        for (int i = 0; i < allWaves.Length; i++)
        {
            wave = allWaves;            
        }
        return wave;
    }
    public void GetWaveInfo(Wave curWave)
    {
        for (int i = 0; i < allWaves.Length; i++)
        {
            if(allWaves[i].waveNumber == curWave.waveNumber)
            {
                curWaveNumber = curWave.waveNumber;
                curWaveName = curWave.waveName;

                waveNumText.text = curWaveNumber.ToString();
                
                StartCoroutine(SpawnEnemies(curWave.enemies));
            }
        }
    }

    private IEnumerator SpawnEnemies(GameObject[] enemies)
    {
        if (enemyContainer is null)
            enemyContainer = new GameObject("enemyContainer");
        enemyContainer.transform.position = new Vector3(0, 1, 0);
        
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randNum = Random.Range(0, spawnPoints.Length);
            Debug.Log(randNum);
            for (int x = 0; x < enemies.Length; x++)
            {
                GameObject tempEnemy = Instantiate(enemies[x], spawnPoints[randNum].transform.position, Quaternion.identity);
                tempEnemy.transform.SetParent(enemyContainer.transform);
                yield return new WaitForSeconds(1);
            }
        }
        EnemyCountText.text = enemies.Length.ToString();
        //EnemyCountText.text = enemyContainer.transform.childCount.ToString();
    }

    public void EnemyDied()
    {
        Debug.Log("Enemy Died");
        int currentCount = int.Parse(EnemyCountText.text);
        currentCount--;
        EnemyCountText.text = currentCount.ToString();

        // Check the enemy count to see if all enemies are dead
        if (int.Parse(EnemyCountText.text) == 0)
        {
            // Increment the wave
            curWaveNumber++;
            // Spawn the next wave
            GetWaveInfo(allWaves[curWaveNumber - 1]);
        }
    }
    #endregion
}
