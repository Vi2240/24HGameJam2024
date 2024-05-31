using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiHittingTower : BuildingHealthScript
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    List<GameObject> enemies;

    [SerializeField] int lockOnLimit = 3;
    [SerializeField] float hitEffectDuration = 0.01f;
    
    int amountOfEnemiesInList;

    bool lookingUp = false;
    bool lookingDown = false;
    bool lookingRight = false;
    bool lookingLeft = false;

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

    void CheckEnemyDirection(GameObject enemy)
    {
        Vector2 direction = enemy.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingTowerObj.range);

        if (hit.collider.gameObject.layer == 8)
        {
            lookingUp = true;
            lookingDown = false;
            lookingRight = false;
            lookingLeft = false;
        }
        if (hit.collider.gameObject.layer == 9)
        {
            lookingUp = false;
            lookingDown = true;
            lookingRight = false;
            lookingLeft = false;
        }
        if (hit.collider.gameObject.layer == 10)
        {
            lookingUp = false;
            lookingDown = false;
            lookingRight = true;
            lookingLeft = false;
        }
        if (hit.collider.gameObject.layer == 11)
        {
            lookingUp = false;
            lookingDown = false;
            lookingRight = false;
            lookingLeft = true;
        }
    }

    IEnumerator ShootRoutine(GameObject enemy, List<GameObject> enemiesToRemove)
    {
        if (enemy != null)
        {
            CheckEnemyDirection(enemy);

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
                if (shootingTowerObj.hitEffectForMortar1 != null)
                {
                    Instantiate(shootingTowerObj.hitEffectForMortar1, enemyHealth.transform.position, shootingTowerObj.hitEffectForMortar1.transform.rotation);
                }

                StartCoroutine(HitEffectDomino(enemy));
            }
        }

        IEnumerator HitEffectDomino(GameObject enemy)
        {
            if (lookingUp)
            {
                var hitEffectToDelete1 = Instantiate(shootingTowerObj.hitEffectDown1, enemy.transform.position, shootingTowerObj.hitEffectDown1.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete1);

                var hitEffectToDelete2 = Instantiate(shootingTowerObj.hitEffectDown2, enemy.transform.position, shootingTowerObj.hitEffectDown2.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete2);

                var hitEffectToDelete3 = Instantiate(shootingTowerObj.hitEffectDown3, enemy.transform.position, shootingTowerObj.hitEffectDown3.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete3);

                var hitEffectToDelete4 = Instantiate(shootingTowerObj.hitEffectDown4, enemy.transform.position, shootingTowerObj.hitEffectDown4.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete4);

                var hitEffectToDelete5 = Instantiate(shootingTowerObj.hitEffectDown5, enemy.transform.position, shootingTowerObj.hitEffectDown5.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete5);

                var hitEffectToDelete6 = Instantiate(shootingTowerObj.hitEffectDown6, enemy.transform.position, shootingTowerObj.hitEffectDown6.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete6);
            }
            if (lookingDown)
            {
                var hitEffectToDelete1 = Instantiate(shootingTowerObj.hitEffectUp1, enemy.transform.position, shootingTowerObj.hitEffectUp1.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete1);

                var hitEffectToDelete2 = Instantiate(shootingTowerObj.hitEffectUp2, enemy.transform.position, shootingTowerObj.hitEffectUp2.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete2);

                var hitEffectToDelete3 = Instantiate(shootingTowerObj.hitEffectUp3, enemy.transform.position, shootingTowerObj.hitEffectUp3.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete3);

                var hitEffectToDelete4 = Instantiate(shootingTowerObj.hitEffectUp4, enemy.transform.position, shootingTowerObj.hitEffectUp4.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete4);

                var hitEffectToDelete5 = Instantiate(shootingTowerObj.hitEffectUp5, enemy.transform.position, shootingTowerObj.hitEffectUp5.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete5);

                var hitEffectToDelete6 = Instantiate(shootingTowerObj.hitEffectUp6, enemy.transform.position, shootingTowerObj.hitEffectUp6.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete6);
            }
            if (lookingLeft)
            {
                var hitEffectToDelete1 = Instantiate(shootingTowerObj.hitEffectRight1, enemy.transform.position, shootingTowerObj.hitEffectRight1.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete1);

                var hitEffectToDelete2 = Instantiate(shootingTowerObj.hitEffectRight2, enemy.transform.position, shootingTowerObj.hitEffectRight2.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete2);

                var hitEffectToDelete3 = Instantiate(shootingTowerObj.hitEffectRight3, enemy.transform.position, shootingTowerObj.hitEffectRight3.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete3);

                var hitEffectToDelete4 = Instantiate(shootingTowerObj.hitEffectRight4, enemy.transform.position, shootingTowerObj.hitEffectRight4.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete4);

                var hitEffectToDelete5 = Instantiate(shootingTowerObj.hitEffectRight5, enemy.transform.position, shootingTowerObj.hitEffectRight5.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete5);

                var hitEffectToDelete6 = Instantiate(shootingTowerObj.hitEffectRight6, enemy.transform.position, shootingTowerObj.hitEffectRight6.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete6);
            }
            if (lookingRight)
            {
                var hitEffectToDelete1 = Instantiate(shootingTowerObj.hitEffectLeft1, enemy.transform.position, shootingTowerObj.hitEffectLeft1.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete1);

                var hitEffectToDelete2 = Instantiate(shootingTowerObj.hitEffectLeft2, enemy.transform.position, shootingTowerObj.hitEffectLeft2.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete2);

                var hitEffectToDelete3 = Instantiate(shootingTowerObj.hitEffectLeft3, enemy.transform.position, shootingTowerObj.hitEffectLeft3.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete3);

                var hitEffectToDelete4 = Instantiate(shootingTowerObj.hitEffectLeft4, enemy.transform.position, shootingTowerObj.hitEffectLeft4.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete4);

                var hitEffectToDelete5 = Instantiate(shootingTowerObj.hitEffectLeft5, enemy.transform.position, shootingTowerObj.hitEffectLeft5.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete5);

                var hitEffectToDelete6 = Instantiate(shootingTowerObj.hitEffectLeft6, enemy.transform.position, shootingTowerObj.hitEffectLeft6.transform.rotation);
                yield return new WaitForSeconds(hitEffectDuration);
                Destroy(hitEffectToDelete6);
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
