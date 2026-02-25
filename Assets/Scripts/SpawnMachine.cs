using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMachine : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn = 2f;

    [SerializeField] private bool _isPresetSpawnUsege = false;

    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private int _spawnPointsCount;
    [SerializeField] private float _radiusAroundThisGameObject;

    [SerializeField] private Transform[] _manualSpawnPoints;

    private List<Transform> _spawnPoints = new();

    private void Start()
    {
        if (_isPresetSpawnUsege)
        {
            SpawnSpawnPoints();
        }
        else
        {
            if (_manualSpawnPoints != null)
            {
                for (int i = 0; i < _manualSpawnPoints.Length; i++)
                {
                    _spawnPoints.Add(_manualSpawnPoints[i]);
                }
            }            
        }

        StartCoroutine(StartSpawn());
    }


    private void SpawnSpawnPoints()
    {
        float angleStep = 360 / _spawnPointsCount; 

        for (int i = 0; i < _spawnPointsCount; i++)
        {
            float x = _radiusAroundThisGameObject * Mathf.Cos(angleStep * i * Mathf.Deg2Rad);
            float y = _radiusAroundThisGameObject * Mathf.Sin(angleStep * i * Mathf.Deg2Rad);

            GameObject newObject = Instantiate(
                _spawnPoint,
                new Vector3(x, y, 0),
                Quaternion.identity,
                transform);

            newObject.name = $"SpawnPoint_{i}";

            _spawnPoints.Add(newObject.transform);            
        } 
    }

    private IEnumerator StartSpawn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }

    public void SpawnEnemy()
    {
        if (_spawnPoints.Count == 0 || _enemyPrefab == null)
        {
            Debug.LogWarning("Нет точек спавна или префаба врага!");
            return;
        }

        int randomIndex = Random.Range(0, _spawnPoints.Count);

        Transform spawnPoint = _spawnPoints[randomIndex];

        Instantiate(
            _enemyPrefab,
            spawnPoint.position,
            spawnPoint.rotation,
            transform);
    }
}
