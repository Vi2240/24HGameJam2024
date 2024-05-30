using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootingTowerValues", menuName = "ShootingTowerValues")]

public class ShootingTowerValues : ScriptableObject
{
    public int damage;
    public float range;
    public float fireRate;
}
