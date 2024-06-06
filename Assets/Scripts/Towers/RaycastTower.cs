using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastTower : BuildingHealthScript
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    [SerializeField] GameObject shootingEffect;
    [SerializeField] float hitEffectDuration;
    
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
                var tryEnemy = hit.collider.gameObject.GetComponent<Enemy>();
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
        if (shootingEffect != null)
        {
            StartCoroutine(TurnOnAndOffEffect(shootingEffect));
        }
        if (shootingTowerObj.attackSoundEffect != null)
        {
            AudioSource.PlayClipAtPoint(shootingTowerObj.attackSoundEffect, transform.position);
        }
        if (shootingTowerObj.explosion != null)
        {
            Instantiate(shootingTowerObj.explosion, transform.position, shootingTowerObj.explosion.transform.rotation);
        }

        StartCoroutine(HitEffectDomino(enemy));

        yield return new WaitForSeconds(shootingTowerObj.fireRate);

        currentCoroutine = null;
    }

    IEnumerator TurnOnAndOffEffect(GameObject effect)
    {
        effect.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        effect.gameObject.SetActive(false);
    }

    IEnumerator HitEffectDomino(GameObject enemy)
    {
        var hitEffectToDelete1 = Instantiate(shootingTowerObj.hitEffectForMortar1, enemy.transform.position, shootingTowerObj.hitEffectForMortar1.transform.rotation);
        yield return new WaitForSeconds(hitEffectDuration);
        Destroy(hitEffectToDelete1);

        var hitEffectToDelete2 = Instantiate(shootingTowerObj.hitEffectForMortar2, enemy.transform.position, shootingTowerObj.hitEffectForMortar2.transform.rotation);
        yield return new WaitForSeconds(hitEffectDuration);
        Destroy(hitEffectToDelete2);

        var hitEffectToDelete3 = Instantiate(shootingTowerObj.hitEffectForMortar3, enemy.transform.position, shootingTowerObj.hitEffectForMortar3.transform.rotation);
        yield return new WaitForSeconds(hitEffectDuration);
        Destroy(hitEffectToDelete3);

        var hitEffectToDelete4 = Instantiate(shootingTowerObj.hitEffectForMortar4, enemy.transform.position, shootingTowerObj.hitEffectForMortar4.transform.rotation);
        yield return new WaitForSeconds(hitEffectDuration);
        Destroy(hitEffectToDelete4);

        var hitEffectToDelete5 = Instantiate(shootingTowerObj.hitEffectForMortar5, enemy.transform.position, shootingTowerObj.hitEffectForMortar5.transform.rotation);
        yield return new WaitForSeconds(hitEffectDuration);
        Destroy(hitEffectToDelete5);

        var hitEffectToDelete6 = Instantiate(shootingTowerObj.hitEffectForMortar6, enemy.transform.position, shootingTowerObj.hitEffectForMortar6.transform.rotation);
        yield return new WaitForSeconds(hitEffectDuration);
        Destroy(hitEffectToDelete6);
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
