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
    
    void Update()
    {
        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            //bool detected = Physics2D.OverlapBox(transform.position + detectionBoxOffset, detectionBoxSize, 0);

            var enemyCollider = Physics2D.OverlapBox(transform.position + detectionBoxOffset, detectionBoxSize, 0);

            if (enemyCollider != null && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(ShootRoutine(enemyCollider.gameObject));
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("SafeEnemy"));

        GameObject closestEnemy = null;
        float closestDistanceToEnemy = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistanceToEnemy && distanceToEnemy <= shootingTowerObj.range)
            {
                closestDistanceToEnemy = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
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
            if (shootingTowerObj.hitEffect != null)
            {
                Instantiate(shootingTowerObj.hitEffect, enemyHealth.transform.position, shootingTowerObj.hitEffect.transform.rotation);
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
