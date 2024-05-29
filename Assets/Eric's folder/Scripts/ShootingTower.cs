using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    [SerializeField] ShootingTowerValues towerObj;
    List<GameObject> enemies;
    //GameObject[] enemies;
    //ScriptThatsJustThere[] ScriptThatsJustThere;

    void Start()
    {

    }

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

            if (distanceToEnemy <= towerObj.range)
            {
                //var currentShootRoutine = StartCoroutine(ShootRoutine());
                Destroy(enemy);
            }
        }
    }

    //IEnumerator ShootRoutine()
    //{

    //}

    void Shoot()
    {

    }
}
