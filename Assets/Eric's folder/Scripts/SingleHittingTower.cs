using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SingleHittingTower : MonoBehaviour
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    [SerializeField] Vector3 detectionBoxSize;
    [SerializeField] Vector3 detectionBoxOffset;
    
    List<GameObject> enemies;
    Coroutine currentCoroutine = null;

    //GameObject FindClosestEnemy()
    //{
    //    foreach(GameObject enemy in enemies)
    //    {
    //        if (enemy != null)
    //        {
    //            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

    //            yield return new WaitForSeconds(shootingTowerObj.fireRate);

    //            float distanceToNewEnemy = Vector2.Distance(transform.position, enemy.transform.position);

    //            if (distanceToNewEnemy > distanceToEnemy)
    //            {
    //                var closestEnemy = enemy;
    //            }
    //        }
    //    }
    //}
    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("SafeEnemy"));

        //enemies = GameObject.FindGameObjectsWithTag("SafeEnemy").ToList();

        //foreach (GameObject enemy in enemies)
        //{
        //    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

        //    if (distanceToEnemy <= shootingTowerObj.range && currentCoroutine == null)
        //    {   
        //        currentCoroutine = StartCoroutine(ShootRoutine(enemy));
        //    }
        //}

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                //bool detected = Physics2D.OverlapBox(transform.position + detectionBoxOffset, detectionBoxSize, 0);

                var enemyCollider = Physics2D.OverlapBox(transform.position + detectionBoxOffset, detectionBoxSize, 0);

                //if (detected == true && currentCoroutine == null)
                //{
                //    Debug.Log("Start the routine!");
                //    currentCoroutine = StartCoroutine(ShootRoutine(enemy));
                //}

                if (enemyCollider != null && currentCoroutine == null)
                {
                    currentCoroutine = StartCoroutine(ShootRoutine(enemyCollider.gameObject));
                }
                break;
            }  
        }
    }

    IEnumerator ShootRoutine(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(shootingTowerObj.damage);

            if (shootingTowerObj.attackSoundEffect != null)
            {
                AudioSource.PlayClipAtPoint(shootingTowerObj.attackSoundEffect, transform.position);
            }
        }

        yield return new WaitForSeconds(shootingTowerObj.fireRate);

        currentCoroutine = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + detectionBoxOffset, detectionBoxSize);
    }
}
