using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastTower : MonoBehaviour
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    [SerializeField] float maxHealth = 10f;
    
    List<GameObject> enemies;

    Coroutine currentCoroutine;

    void Update()
    {
        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            Vector2 direction = closestEnemy.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingTowerObj.range);

            if (hit.collider != null)
            {
                var tryEnemy = hit.collider.gameObject.GetComponent<EnemyScript>();
                if (tryEnemy != null && currentCoroutine == null)
                {
                    currentCoroutine = StartCoroutine(ShootingRoutine(tryEnemy.transform.gameObject));
                    Debug.Log("Start coroutine");
                }
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("SafeEnemy"));

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    IEnumerator ShootingRoutine(GameObject enemy)
    {
        if (shootingTowerObj.attackSoundEffect != null)
        {
            AudioSource.PlayClipAtPoint(shootingTowerObj.attackSoundEffect, transform.position);
        }
        if (shootingTowerObj.hitEffect != null)
        {
            Instantiate(shootingTowerObj.hitEffect, enemy.transform.position, shootingTowerObj.hitEffect.transform.rotation);
        }

        yield return new WaitForSeconds(shootingTowerObj.fireRate);

        currentCoroutine = null;
    }

    public void MortarTakeDamage(int damageToTake)
    {
        maxHealth -= damageToTake;
        if (maxHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                    Ray detectionRay = new Ray(transform.position, enemy.transform.position - transform.position);
                    Gizmos.DrawRay(detectionRay);
                }
            }
        }  
    }
}
