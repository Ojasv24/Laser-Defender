using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    IEnumerator Start()
    {
        do                                              
        {
            yield return StartCoroutine(SpwanAllWaves());
        }
        while (looping);


    }

    private IEnumerator SpwanAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            int random = Random.Range(0, waveConfigs.Count);
            var currentWave = waveConfigs[random];
            yield return StartCoroutine(SpawnAllEnemyInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemyInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetnumberOfEnemy(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
            waveConfig.GetWayPoint()[0].transform.position,
            Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
