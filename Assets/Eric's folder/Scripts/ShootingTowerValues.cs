using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootingTowerValues", menuName = "ShootingTowerValues")]

public class ShootingTowerValues : ScriptableObject
{
    [Header("Audio")]
    public AudioClip attackSoundEffect;

    [Header("Turret sprites")]
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    [Header("Hit effects for Turrets")]
    public GameObject hitEffectUp1;
    public GameObject hitEffectUp2;
    public GameObject hitEffectUp3;
    public GameObject hitEffectUp4;
    public GameObject hitEffectUp5;
    public GameObject hitEffectUp6;
    public GameObject hitEffectDown1;
    public GameObject hitEffectDown2;
    public GameObject hitEffectDown3;
    public GameObject hitEffectDown4;
    public GameObject hitEffectDown5;
    public GameObject hitEffectDown6;
    public GameObject hitEffectLeft1;
    public GameObject hitEffectLeft2;
    public GameObject hitEffectLeft3;
    public GameObject hitEffectLeft4;
    public GameObject hitEffectLeft5;
    public GameObject hitEffectLeft6;
    public GameObject hitEffectRight1;
    public GameObject hitEffectRight2;
    public GameObject hitEffectRight3;
    public GameObject hitEffectRight4;
    public GameObject hitEffectRight5;
    public GameObject hitEffectRight6;

    [Header("Hit effects for Mortar")]
    public GameObject hitEffectForMortar1;
    public GameObject hitEffectForMortar2;
    public GameObject hitEffectForMortar3;
    public GameObject hitEffectForMortar4;
    public GameObject hitEffectForMortar5;
    public GameObject hitEffectForMortar6;
    public GameObject explosion;

    [Header("Values")]
    public int damage;
    public float range;
    public float explosionRange;
    public float fireRate;
}
