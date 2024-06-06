using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealthScript : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;

    public void BuildingTakeDamage(int damageToTake)
    {
        maxHealth -= damageToTake;
        if (maxHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
