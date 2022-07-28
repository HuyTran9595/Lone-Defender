using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
    [Tooltip("Name of the wave")]
    public string waveName;
    [Tooltip("Wave Number")]
    public int waveNumber;
    [Tooltip("Enemies in the Wave")]
    public GameObject[] enemies;
}
