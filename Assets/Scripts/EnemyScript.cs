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
    [SerializeField] LayerMask targetLayer;
    Vector3 detectionSphereOffset;

    [Header("Attacking")]
    [SerializeField]  EnemyAttackingValues attackingEnemy;

    public List<GameObject> buildingTargets;

    Coroutine currentCoroutine = null;

    Animator enemyAnimator = null;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        buildingTargets = GameObject.FindGameObjectsWithTag("Building").ToList();

        if (buildingTargets.Count > 0)
        {
            EnemyMovement();
        }
        
        GameObject closestTargets = GetClosestTarget(buildingTargets);

        if (closestTargets != null)
        {
            var buildingCollider = Physics2D.OverlapCircle(transform.position + detectionSphereOffset, detectionSphereSize, targetLayer);

            if (buildingCollider != null && currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(AttackingBuildingRoutine(buildingCollider.gameObject));
            }

            if (buildingCollider != null)
            {
                AttackAnimations(buildingCollider.gameObject);
            }
            else
            {
                AttackAnimations(null);
            }
        }
        else
        {
            enemyAnimator.SetBool("IsAttacking", false);
        }
    }
    
    void EnemyMovement()
    {
        if (currentCoroutine == null)
        {
            GameObject closestTarget = GetClosestTarget(buildingTargets);
            if (closestTarget != null)
            {
                Vector2 targetPosition = closestTarget.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);

                if (transform.position.x > closestTarget.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                if (transform.position.x < closestTarget.transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                
                enemyAnimator.SetBool("IsMoving", true);
            }
            else
            {
                enemyAnimator.SetBool("IsMoving", false);
            }
        }
        else
        {
            enemyAnimator.SetBool("IsMoving", false);
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

    void AttackAnimations(GameObject building)
    {
        BuildingHealthScript buildingHealth = null;
        if (building != null)
        {
          buildingHealth = building.GetComponent<BuildingHealthScript>();

        }

        if (buildingHealth != null)
        {
            
            Debug.Log("Attacking");
            enemyAnimator.SetBool("IsAttacking", true);
            Debug.Log(buildingHealth);
        }
        else
        {
            Debug.Log("Not Attacking");
            enemyAnimator.SetBool("IsAttacking", false);
        }
    }

    IEnumerator AttackingBuildingRoutine(GameObject building)
    {
        BuildingHealthScript buildingHealth = building.GetComponent<BuildingHealthScript>();

        if (buildingHealth != null)
        {
            buildingHealth.BuildingTakeDamage(attackingEnemy.damage);
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
//SingleHittingTower turretHealth = building.GetComponent<SingleHittingTower>();

//if (turretHealth != null)
//{
//    turretHealth.TurretTakeDamage(attackingEnemy.damage);
//    enemyAnimator.SetBool("IsAttacking", true);
//}
//else
//{
//    enemyAnimator.SetBool("IsAttacking", false);
//}

//RaycastTower mortarHealth = building.GetComponent<RaycastTower>();

//if (mortarHealth != null)
//{
//    mortarHealth.MortarTakeDamage(attackingEnemy.damage);
//    enemyAnimator.SetBool("IsAttacking", true);
//}
//else
//{
//    enemyAnimator.SetBool("IsAttacking", false);
//}

//MultiHittingTower teslaCoilHelth = building.GetComponent<MultiHittingTower>();

//if (teslaCoilHelth != null)
//{
//    teslaCoilHelth.TeslaCoilTakeDamage(attackingEnemy.damage);
//    enemyAnimator.SetBool("IsAttacking", true);
//}
//else
//{
//    enemyAnimator.SetBool("IsAttacking", false);
//}
