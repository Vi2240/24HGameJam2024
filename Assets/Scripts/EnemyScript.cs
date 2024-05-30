using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float enemySpeed = 1.0f;

    [Header("Health")]
    [SerializeField] float maxHealth = 100f;

    [Header("Detection")]
    [SerializeField] float detectionSphereSize;
    [SerializeField] Vector3 detectionSphereOffset;
    [SerializeField] LayerMask targetLayer;

    [Header("Attacking")]
    [SerializeField]  EnemyAttackingValues attackingEnemy;

    List<GameObject> buildungTargets;

    Coroutine currentCoroutine = null;

    void Update()
    {
        buildungTargets = GameObject.FindGameObjectsWithTag("Building").ToList();
        if (buildungTargets.Count > 0)
        {
            EnemyMovement();
        }
        
        GameObject closestTargets = GetClosestTarget(buildungTargets);
        if (closestTargets != null)
        {
            var buildingCollider = Physics2D.OverlapCircle(transform.position + detectionSphereOffset, detectionSphereSize, targetLayer);

            if (buildingCollider != null && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(AttackingTowerRoutine(buildingCollider.gameObject));
            }
        }
    }
    
    void EnemyMovement()
    {
        GameObject closestTarget = GetClosestTarget(buildungTargets);
        if (closestTarget != null)
        {
            Vector2 targetPosition = closestTarget.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            transform.up = direction;
        }
    }

    GameObject GetClosestTarget(List<GameObject> targets)
    {
        GameObject closestTarget = null;
        float closestDistanceToBuilding = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToBuilding = Vector2.Distance(transform.position, target.transform.position);
            if (distanceToBuilding < closestDistanceToBuilding && distanceToBuilding >= attackingEnemy.range)
            {
                closestDistanceToBuilding = distanceToBuilding;
                closestTarget = target;
            }
        }

        return closestTarget;
    }

    public void EnemyTakeDamage(int damageToTake)
    {
        maxHealth -= damageToTake;
        if (maxHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator AttackingTowerRoutine(GameObject tower)
    {
        SingleHittingTower turretHealth = tower.GetComponent<SingleHittingTower>();
        if (turretHealth != null)
        {
            Debug.Log("I am attacking");
            turretHealth.TurretTakeDamage(attackingEnemy.damage);
        }

        yield return new WaitForSeconds(attackingEnemy.damageRate);

        currentCoroutine = null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + detectionSphereOffset, detectionSphereSize);
    }
}
//Previous tries
//Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
//transform.position = newPosition;
//Collider[] buildingCollider = Physics.OverlapSphere(transform.position + detectionSphereOffset, detectionSphereSize, 0);

//if (buildingCollider != null && currentCoroutine == null)
//{
//    GameObject buildingObject = buildingCollider[];
//    currentCoroutine = StartCoroutine(AttackingTowerRoutine(buildingObject));
//}

//if (distanceToBuilding < closestDistanceToBuilding)
//{
//    closestDistanceToBuilding = distanceToBuilding;
//    closestTarget = target;
//}

//Debug.Log(closestTargets);
//Debug.Log(buildingCollider + "  " + currentCoroutine);
