using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _target;

    private int _spawnInterval;
    private bool _isPlaying = true;
    private int _minIntervalValue = 2;
    private int _maxIntervalValue = 5;
    
    private void Start()
    {
        _spawnInterval = Random.Range(_minIntervalValue, _maxIntervalValue);
        StartCoroutine(SpawnEnemyRoutine(_spawnInterval, _enemyPrefab, _spawnPoint));
    }

    private IEnumerator SpawnEnemyRoutine(float interval, Enemy enemy, Transform spawnPoint)
    {
        var spawnInterval = new WaitForSeconds(interval);

        while (_isPlaying)
        {
            SpawnEnemy(enemy, spawnPoint.position, _target);
            yield return spawnInterval;
        }
    }

    private void SpawnEnemy(Enemy enemy, Vector2 spawnPosition, Transform target)
    {
        Enemy newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        newEnemy.SetTarget(target);
    }
}