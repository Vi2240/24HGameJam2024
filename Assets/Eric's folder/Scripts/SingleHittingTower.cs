using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SingleHittingTower : MonoBehaviour
{
    [SerializeField] ShootingTowerValues shootingTowerObj;
    
    List<GameObject> enemies;
    Coroutine currentCoroutine = null;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        //var objects = GameObject.FindObjectsByType<ScriptThatsJustThere>(FindObjectsSortMode.None);
        //foreach (var obj in objects)
        //{
        //    enemies.Add(obj.gameObject);
        //}

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= shootingTowerObj.range && currentCoroutine == null)
            {   
                currentCoroutine = StartCoroutine(ShootRoutine(enemy));
            }
        }
    }

    IEnumerator ShootRoutine(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(shootingTowerObj.damage);
        }

        yield return new WaitForSeconds(shootingTowerObj.fireRate);
        
        currentCoroutine = null;
    }
}
