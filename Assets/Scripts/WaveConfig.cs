using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    private GameObject _enemyPrefab;
    public GameObject EnemyPrefab { get => _enemyPrefab; }

    [SerializeField]
    private GameObject _pathPrefab;
    public List<Transform> Waypoints 
    {
        get 
        { 
            List<Transform> waveWaypoints = new List<Transform>();
            foreach (Transform child in _pathPrefab.transform)
            {
                waveWaypoints.Add(child);
            }
            return waveWaypoints;
        } 
    }

    [SerializeField]
    private float _spawnInterval = 0.5f;
    public float SpawnInterval { get => _spawnInterval; }

    [SerializeField]
    private float _randomSpawnRateAmount = 0.2f;

    [SerializeField]
    public float RandomSpawnRateAmount { get => _randomSpawnRateAmount; }

    [SerializeField]
    private int _enemyCount = 5;
    public int EnemyCount { get => _enemyCount; }

    [SerializeField]
    private float _enemyMoveSpeed = 2;
    public float EnemyMoveSpeed { get => _enemyMoveSpeed; }

}
