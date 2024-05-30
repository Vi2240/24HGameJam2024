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

    SpriteRenderer spriteRenderer;

    float angleToTurnBoxBy = 0;
    
    Coroutine currentCoroutine = null;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            var enemyCollider = Physics2D.OverlapBox(transform.position + detectionBoxOffset, detectionBoxSize, angleToTurnBoxBy);

            if (enemyCollider != null && enemyCollider.transform.gameObject == closestEnemy && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(ShootRoutine(closestEnemy));
            }
            else if (enemyCollider != null && currentCoroutine == null)
            {
                closestEnemy = FindClosestEnemy();
                currentCoroutine = StartCoroutine(ShootRoutine(closestEnemy));
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
        RotateTurret(enemy);
        
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

    void RotateTurret(GameObject enemy)
    {
        Vector2 direction = enemy.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingTowerObj.range);

        if (hit.collider.gameObject.layer == 1)
        {

        }


        //float hypotenuseDistanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
        //float xDistanceToEnemy = enemy.transform.position.x - transform.position.x;

        //var degree = Mathf.Acos(xDistanceToEnemy/hypotenuseDistanceToEnemy);
        //var degreeInGrades = degree * 90;

        //Debug.Log(degreeInGrades.ToString());

        //if ((degreeInGrades >= 315 && degreeInGrades <= 45) || (degreeInGrades >= 0 && degreeInGrades <= 45))
        //{
        //    //sprite = right
        //    spriteRenderer.sprite = shootingTowerObj.spriteRight;
        //    angleToTurnBoxBy = 0;
        //    Debug.Log("Right");
        //}
        //if (degreeInGrades > 45 && degreeInGrades < 135)
        //{
        //    //sprite = up
        //    spriteRenderer.sprite = shootingTowerObj.spriteUp;
        //    angleToTurnBoxBy = 90;
        //    Debug.Log("Up");
        //}
        //if (degreeInGrades >= 135 && degreeInGrades <= 225)
        //{
        //    //sprite = left
        //    spriteRenderer.sprite = shootingTowerObj.spriteLeft;
        //    angleToTurnBoxBy = 180;
        //    Debug.Log("Left");
        //}
        //if (degreeInGrades > 225 && degreeInGrades < 315)
        //{
        //    //sprite = down
        //    spriteRenderer.sprite = shootingTowerObj.spriteDown;
        //    angleToTurnBoxBy = 270;
        //    Debug.Log("Down");
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + detectionBoxOffset, detectionBoxSize);
        Gizmos.DrawWireCube(transform.position + detectionBoxOffset, detectionBoxSize);
    }
}
