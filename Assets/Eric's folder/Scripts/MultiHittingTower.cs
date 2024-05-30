using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiHittingTower : MonoBehaviour
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    List<GameObject> enemies;

    [SerializeField] int lockOnLimit = 3;
    public int amountOfEnemiesInList;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        List<GameObject> enemiesToRemove = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {   
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy <= shootingTowerObj.range && amountOfEnemiesInList < lockOnLimit)
                {
                    StartCoroutine(ShootRoutine(enemy, enemiesToRemove));
                }
            }
        }

        // Remove enemies outside of the foreach loop
        foreach (GameObject enemy in enemiesToRemove)
        {
            enemies.Remove(enemy);
        }
    }

    IEnumerator ShootRoutine(GameObject enemy, List<GameObject> enemiesToRemove)
    {
        if (enemy != null)
        {
            amountOfEnemiesInList++;

            enemy.tag = "SafeEnemy";
            enemiesToRemove.Add(enemy);
            Debug.Log("Changed tag to " + enemy.tag);

            EnemyScript enemyHealth = enemy.GetComponent<EnemyScript>();
            if (enemyHealth != null)
            {
                enemyHealth.EnemyTakeDamage(shootingTowerObj.damage);
                if (shootingTowerObj.attackSoundEffect != null)
                {
                    AudioSource.PlayClipAtPoint(shootingTowerObj.attackSoundEffect, transform.position);
                }
                if (shootingTowerObj.hitEffect != null)
                {
                    Instantiate(shootingTowerObj.hitEffect, enemyHealth.transform.position, shootingTowerObj.hitEffect.transform.rotation);
                }
            }
        }

        yield return new WaitForSeconds(shootingTowerObj.fireRate);

        if (enemy != null)
        {
            enemy.tag = "Enemy";
        }

        amountOfEnemiesInList--;
    }
}
