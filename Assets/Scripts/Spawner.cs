using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spawnInterval = 2;
    private bool _isPlaying = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine(_spawnInterval, _enemyPrefab, _spawnPoints));
    }

    private IEnumerator SpawnEnemyRoutine(float interval, Enemy enemy, Transform[] spawnPoints)
    {
        var spawnInterval = new WaitForSeconds(interval);

        while (_isPlaying)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                SpawnEnemy(enemy, spawnPoint.position);
                yield return spawnInterval;
            }
        }
    }

    private void SpawnEnemy(Enemy enemy, Vector2 spawnPosition)
    {
        Vector2 randomDirection = GetRandomDirection();
        
        Instantiate(enemy, spawnPosition, Quaternion.identity).SetDirection(randomDirection);
    }

    private Vector2 GetRandomDirection()
    {
        return Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;
    }
}