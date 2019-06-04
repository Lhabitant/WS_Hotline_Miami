using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New player data", menuName ="Data/player")]

public class PlayerData : ScriptableObject
{
    [Tooltip("Speed of the character")]
    public float speed = 10f;

    [Tooltip("knockback when the player shoot")]
    public float knockBack = 1f;

    [Tooltip("Reduce the time speed")]
    public float slowTimer = 0.1f;

    [Tooltip("where the bullet appear")]
    public float canonOut;

}
