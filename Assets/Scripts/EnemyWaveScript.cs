using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyWaveScript : MonoBehaviour
{
    [SerializeField] GameObject basicEnemy;
    [SerializeField] GameObject fastEnemy;
    [SerializeField] GameObject heavyEnemy;

    float randomChance1 = 0f;
    float randomChance2 = 101f;
    float randomChance3 = 101f;
    float randomChance4 = 101f;

    float timeUntilNewWave = 60f;

    bool startNewWave = true;
    bool waveEnd = false;
    bool gotSpawnLocation = false;

    int maxNumberOfEnemysOnWave = 5;
    int currentNumberOfEnemysOnWave;

    public Vector2 minClamp = new Vector2(-50, -49f);
    public Vector2 maxClamp = new Vector2(50, 49f);
    Vector2 spawnLocation = Vector2.zero;


    private void Update()
    {
        if (startNewWave)
        {
            StartCoroutine(TimUntilNewWaveRoutine());

            currentNumberOfEnemysOnWave = maxNumberOfEnemysOnWave;

            while (true)
            {
                float Number = Random.Range(0, 101);
                if (Number >= randomChance1 && Number < randomChance2)
                {
                    GameObject spawnedObject = Instantiate(basicEnemy);

                    SpawnEnemy(spawnedObject);
                }
                if (Number >= randomChance2 && Number < randomChance3)
                {
                    GameObject spawnedObject = Instantiate(fastEnemy);

                    SpawnEnemy(spawnedObject);
                }
                if (Number >= randomChance3 && Number < randomChance4)
                {
                    GameObject spawnedObject = Instantiate(heavyEnemy);

                    SpawnEnemy(spawnedObject);
                }

                currentNumberOfEnemysOnWave--;

                if (currentNumberOfEnemysOnWave <= 0)
                {

                    randomChance2 -= 2f;
                    randomChance3--;
                    maxNumberOfEnemysOnWave++;

                    gotSpawnLocation = false;
                    waveEnd = true;

                    break;
                }
            }

        }
    }

    IEnumerator TimUntilNewWaveRoutine()
    {
        startNewWave = false;

        yield return new WaitForSeconds(timeUntilNewWave);

        startNewWave = true;
    }

    void SpawnEnemy(GameObject spawnObject)
    {
        if(!gotSpawnLocation)
        {
            float Number = Random.Range(0, 4);

            if (Number == 0)
            {
                spawnLocation = new Vector2(Random.Range(maxClamp.x, -maxClamp.x), maxClamp.y);

                spawnObject.gameObject.transform.position = spawnLocation;

                gotSpawnLocation = true;
            }
            if (Number == 1)
            {
                spawnLocation = new Vector2(Random.Range(maxClamp.x, -maxClamp.x), minClamp.y);

                spawnObject.gameObject.transform.position = spawnLocation;

                gotSpawnLocation = true;
            }
            if (Number == 2)
            {
                spawnLocation = new Vector2(maxClamp.x, Random.Range(maxClamp.y, -maxClamp.y));

                spawnObject.gameObject.transform.position = spawnLocation;

                gotSpawnLocation = true;
            }
            if (Number == 3)
            {
                spawnLocation = new Vector2(-maxClamp.x, Random.Range(maxClamp.y, -maxClamp.y));

                spawnObject.gameObject.transform.position = spawnLocation;

                gotSpawnLocation = true;
            }
        }
        else
        {
            spawnObject.gameObject.transform.position = spawnLocation;
        }
    }
}
