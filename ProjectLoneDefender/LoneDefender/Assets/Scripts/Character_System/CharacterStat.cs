using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterStat")]
public class CharacterStat : ScriptableObject
{
    [System.Serializable]
    public enum CharacterType { PlayerCharacter, Enemy, PlayerBase };
    [Tooltip("Select Character type")]
    public CharacterType charTyper;
    [Tooltip("Name of Character")]
    public string characterName;
    [Tooltip("Character Health")]
    public int characterHealth;
    [Tooltip("Character Damage")]
    public int characterDamage;
    [Tooltip("Character Range")]
    public int characterRange;
    [Tooltip("Prefab for the character being created")]
    public GameObject charPrefab;
}