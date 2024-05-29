using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiHittingTower : MonoBehaviour
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    List<GameObject> enemies;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        List<GameObject> enemiesToRemove = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {   
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy <= shootingTowerObj.range)
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
            enemy.tag = "SafeEnemy";
            enemiesToRemove.Add(enemy);
            Debug.Log("Changed tag to " + enemy.tag);

            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(shootingTowerObj.damage);
                if (shootingTowerObj.attackSoundEffect != null)
                {
                    AudioSource.PlayClipAtPoint(shootingTowerObj.attackSoundEffect, transform.position);
                }
            }
        }

        yield return new WaitForSeconds(shootingTowerObj.fireRate);

        if (enemy != null)
        {
            enemy.tag = "Enemy";
        }
    }
}
