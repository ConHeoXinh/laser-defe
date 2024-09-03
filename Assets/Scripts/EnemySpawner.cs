using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;

    [SerializeField] float timeBetweenWaves = 2f;
    [SerializeField] List<WaveConfigSO> waves;
    [SerializeField] bool isLooping;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemieWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {

    return currentWave; 
    }

     IEnumerator SpawnEnemieWaves()
    {
        do
        {

            foreach (WaveConfigSO wave in waves)
            {
                currentWave = wave;

                // get all object of current wave
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpwanTime());

                }

                yield return new WaitForSeconds(timeBetweenWaves);

            }
        } while (isLooping);
    }
}
