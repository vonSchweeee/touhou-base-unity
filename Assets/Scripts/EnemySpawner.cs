using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool loop = false;

    IEnumerator Start()
    {
        do
            yield return StartCoroutine(SpawnAllWaves());
        while(loop);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {
            yield return StartCoroutine(SpawnWaveEnemies(waveConfigs[i]));
        }
    }

    private IEnumerator SpawnWaveEnemies(WaveConfig config)
    {
        for (int i = 0; i < config.EnemyCount; i++) 
        {
            var newEnemy = Instantiate(config.EnemyPrefab, config.Waypoints[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyMovement>().SetWaveConfig(config);
            yield return new WaitForSeconds(config.SpawnInterval);
        }
    }
}
