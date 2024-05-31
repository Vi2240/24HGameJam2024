using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackingValues", menuName = "EnemyAttackingValues")]

public class EnemyAttackingValues : ScriptableObject
{
    public AudioClip attackSoundEffect;
    public GameObject hitEffect;

    public int damage;
    public float range;
    public float damageRate;
}
