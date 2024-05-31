using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SingleHittingTower : BuildingHealthScript
{
    [SerializeField] ShootingTowerValues shootingTowerObj;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject shootingEffectUp;
    [SerializeField] GameObject shootingEffectDown;
    [SerializeField] GameObject shootingEffectRight;
    [SerializeField] GameObject shootingEffectLeft;

    [SerializeField] float hitEffectDuration;

    Coroutine currentCoroutine = null;
    bool lookingUp = false;
    bool lookingDown = false;
    bool lookingRight = false;
    bool lookingLeft = false;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    //void Update()
    //{
    //    GameObject closestEnemy = FindClosestEnemy();

    //    if (closestEnemy != null)
    //    {
    //        var enemyCollider = Physics2D.OverlapCircle(transform.position, shootingTowerObj.range);

    //        if (enemyCollider != null && enemyCollider.transform.gameObject == closestEnemy && currentCoroutine == null)
    //        {
    //            currentCoroutine = StartCoroutine(ShootRoutine(closestEnemy));
    //        }
    //        else if (enemyCollider != null && currentCoroutine == null)
    //        {
    //            closestEnemy = FindClosestEnemy();
    //            currentCoroutine = StartCoroutine(ShootRoutine(closestEnemy));
    //        }
    //    }
    //}

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

    //IEnumerator ShootRoutine(GameObject enemy)
    //{
    //    RotateTurret(enemy);
        
    //    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
    //    if (enemyHealth != null)
    //    {
    //        enemyHealth.TakeDamage(shootingTowerObj.damage);

    //        if (shootingEffectUp != null && lookingUp)
    //        {
    //            StartCoroutine(TurnOnAndOffEffect(shootingEffectUp));
    //        }
    //        if (shootingEffectDown != null && lookingDown)
    //        {
    //            StartCoroutine(TurnOnAndOffEffect(shootingEffectDown));
    //        }
    //        if (shootingEffectRight != null && lookingRight)
    //        {
    //            StartCoroutine(TurnOnAndOffEffect(shootingEffectRight));
    //        }
    //        if (shootingEffectLeft != null && lookingLeft)
    //        {
    //            StartCoroutine(TurnOnAndOffEffect(shootingEffectLeft));
    //        }
    //        if (shootingTowerObj.attackSoundEffect != null)
    //        {
    //            AudioSource.PlayClipAtPoint(shootingTowerObj.attackSoundEffect, transform.position);
    //        }

    //        StartCoroutine(HitEffectDomino(enemy));
    //    }

    //    yield return new WaitForSeconds(shootingTowerObj.fireRate);

    //    currentCoroutine = null;
    //}

    IEnumerator TurnOnAndOffEffect(GameObject effect)
    {
        effect.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        effect.gameObject.SetActive(false);
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

    void RotateTurret(GameObject enemy)
    {
        Vector2 direction = enemy.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingTowerObj.range);

        if (hit.collider.gameObject.layer == 8)
        {
            spriteRenderer.sprite = shootingTowerObj.spriteUp;
            
            lookingUp = true;
            lookingDown = false;
            lookingRight = false;
            lookingLeft = false;
        }
        if (hit.collider.gameObject.layer == 9)
        {
            spriteRenderer.sprite = shootingTowerObj.spriteDown;

            lookingUp = false;
            lookingDown = true;
            lookingRight = false;
            lookingLeft = false;
        }
        if (hit.collider.gameObject.layer == 10)
        {
            spriteRenderer.sprite = shootingTowerObj.spriteRight;

            lookingUp = false;
            lookingDown = false;
            lookingRight = true;
            lookingLeft = false;
        }
        if (hit.collider.gameObject.layer == 11)
        {
            spriteRenderer.sprite = shootingTowerObj.spriteLeft;

            lookingUp = false;
            lookingDown = false;
            lookingRight = false;
            lookingLeft = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, shootingTowerObj.range);
    }
}
