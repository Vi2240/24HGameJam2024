using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [Header("Object reference")]
    [SerializeField] GameObject[] enemies;

    int increasingNumbers = 3;

    void Update()
    {
        if (Time.frameCount > 0)
        {
            //The places they can spawn will be changed later
            int startingIndex = Random.Range(1, 4);
            Vector2 randomSpawnPosition = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));

            Instantiate(enemies[startingIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
