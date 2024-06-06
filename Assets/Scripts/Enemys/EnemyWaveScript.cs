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

    float timeUntilNewWave = 1f;

    bool startNewWave = true;

    int maxNumberOfEnemysOnWave = 5;
    int currentNumberOfEnemysOnWave;

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

                    spawnedObject.gameObject.transform.position = Vector3.zero;
                }
                if (Number >= randomChance2 && Number < randomChance3)
                {
                    GameObject spawnedObject = Instantiate(fastEnemy);

                    spawnedObject.gameObject.transform.position = Vector3.zero;
                }
                if (Number >= randomChance3 && Number < randomChance4)
                {
                    GameObject spawnedObject = Instantiate(heavyEnemy);

                    spawnedObject.gameObject.transform.position = Vector3.zero;
                }

                currentNumberOfEnemysOnWave--;

                if (currentNumberOfEnemysOnWave <= 0)
                {
                    if(randomChance2 < 60)
                    {
                        randomChance2 -= 2f;
                    }
                    if(randomChance3 < 70)
                    {
                        randomChance3--;
                    }

                    maxNumberOfEnemysOnWave++;

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

    void SpawnEnemy()
    {

    }
}
