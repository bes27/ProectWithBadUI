using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    const int _minCountBigCoins = 40;
    const int _minCountSmallCoins = 40;
    
    [SerializeField] private GameObject _bigCoin;
    [SerializeField] private Transform _bigCoinTransform;
    [SerializeField] private GameObject _smallCoin;
    [SerializeField] private Transform _smallCoinTransform;
    
    [SerializeField][Range(80, 150)] private int _maxCountAllCoins;
    [SerializeField][Range(100, 300)] private int distance;
    [SerializeField][Range(4.0f, 6.0f)] private float _distanceBetweenCoins;
    [SerializeField][Range(1.5f, 3.5f)] private float _distanceToBarriers;
    
    private int _maxCountBigCoins;
    private int _maxCountSmallCoins;
    private Vector3 _spawnPoint;
    private int _counterSpawnedCoins = 0;

    void Start()
    {
        CounterMaxCoins();

        SpawnCoins();
    }

    private void CounterMaxCoins()
    {
        _maxCountBigCoins = _maxCountAllCoins - (_minCountBigCoins +
                                                     (_maxCountAllCoins > 80 
                                                     ? Random.Range(0, _maxCountAllCoins - (_minCountBigCoins + _minCountSmallCoins)) 
                                                     : 0
                                                     )
                                                 );
        _maxCountSmallCoins = _maxCountAllCoins - _maxCountBigCoins;
    }

    private void SpawnCoins()
    {
        for (int _countCoins = 1; _countCoins <= _maxCountAllCoins; _countCoins++)
        {
            SpawnOneCoin();
        }
    }

    private void SpawnOneCoin()
    {
        if (_counterSpawnedCoins <= _maxCountBigCoins)
        {
            Instantiate(
                _bigCoin, 
                ApproveDistance(_distanceBetweenCoins, _distanceToBarriers), 
                Quaternion.identity, 
                _bigCoinTransform);
            
            _counterSpawnedCoins += 1;
        }
        else if (_counterSpawnedCoins <= _maxCountAllCoins)
        {
            Instantiate(
                _smallCoin, 
                ApproveDistance(_distanceBetweenCoins, _distanceToBarriers), 
                Quaternion.identity, 
                _smallCoinTransform);
            
            _counterSpawnedCoins += 1;
        }
    }

    private Vector3 ApproveDistance(float distanceCoins, float distanceBarriers)
    {
        _spawnPoint = Random.insideUnitCircle * distance;

        for (int i = 0; i < 5; i++)
        {
            if (Physics2D.OverlapCircle(_spawnPoint, distanceCoins) != null 
                || Physics2D.OverlapCircle(_spawnPoint, distanceBarriers) != null)
            {
                _spawnPoint = Random.insideUnitCircle * distance;
                i = 0;
            }
        }

        return _spawnPoint;
    }
}
