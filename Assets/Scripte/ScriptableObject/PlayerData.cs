using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New player data", menuName ="Data/player")]

public class PlayerData : ScriptableObject
{
    [Header("Player Controller script")]
    [Tooltip("where the player aim (the visor)")]
    public GameObject target;

    [Tooltip("Speed of the character")]
    public float speed = 20;

    [Tooltip("knockback when the player shoot")]
    public float knockBack = 2000f;

    [Header("Time manager script")]
    [Tooltip("Reduce the time speed")]
    public float slowTimer = 1f;

    [Header("BulletManager script")]
    [Tooltip("bullet")]
    public GameObject bullet;

    [Tooltip("Main camera")]
    public GameObject mainCamera;

    [Tooltip("Punch")]
    public GameObject Punch;

    [Tooltip("Weapon droped")]
    public GameObject weapon;

    [Tooltip("where the bullet appear")]
    public float canonOut;

}
