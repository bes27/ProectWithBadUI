using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    const int minCountBigCoins = 40;
    const int minCountSmallCoins = 40;
    
    [SerializeField] private GameObject bigCoin;
    [SerializeField] private Transform bigCoinTransform;
    [SerializeField] private GameObject smallCoin;
    [SerializeField] private Transform smallCoinTransform;

    [SerializeField] private GameObject barriers;
    [SerializeField] private Transform barriersTransform;

    [SerializeField][Range(80, 150)] private int maxCountAllCoins;
    [SerializeField][Range(100, 300)] private int distance;
    [SerializeField][Range(4.0f, 6.0f)] private float distanceBetweenCoins;
    [SerializeField][Range(1.5f, 3.5f)] private float distanceToBarriers;

    [SerializeField][Range(150, 1000)] private int maxCountAllBarriers;
    [SerializeField][Range(1.5f, 3.5f)] private float distanceToCoin;
    [SerializeField][Range(1f, 3f)] private float distanceBetweenBarriers;

    private int maxCountBigCoins;
    private Vector3 spawnPoint;
    private int counterSpawnedCoins = 0;

    private void Awake()
    {
        SpawnBarriers();
    }

    void Start()
    {
        CounterMaxCoins();

        SpawnCoins();
    }
    //считаем кол-во кристалов
    private void CounterMaxCoins()
    {
        int condition = Random.Range(0, maxCountAllCoins - (minCountBigCoins + minCountSmallCoins));

        maxCountBigCoins = maxCountAllCoins - (minCountBigCoins +(maxCountAllCoins > 80 ? condition: 0));
    }
    //спавним через цикл
    private void SpawnCoins()
    {
        for (int countCoins = 1; countCoins <= maxCountAllCoins; countCoins++)
        {
            SpawnOneCoin();
        }
    }

    private void SpawnOneCoin()
    {
        if (counterSpawnedCoins <= maxCountBigCoins)
        {
            Instantiate(
                bigCoin, 
                ApproveDistance(distanceBetweenCoins, distanceToBarriers), 
                Quaternion.identity, 
                bigCoinTransform);
            
            counterSpawnedCoins += 1;
        }
        else if (counterSpawnedCoins <= maxCountAllCoins)
        {
            Instantiate(
                smallCoin, 
                ApproveDistance(distanceBetweenCoins, distanceToBarriers), 
                Quaternion.identity, 
                smallCoinTransform);
            
            counterSpawnedCoins += 1;
        }
    }
    // дополняем вектор для уверенности
    private Vector3 ApproveDistance(float distanceCoins, float distanceBarriers)
    {
        spawnPoint = Random.insideUnitCircle * distance;

        for (int i = 0; i < 5; i++)
        {
            if (Physics2D.OverlapCircle(spawnPoint, distanceCoins) != null 
                || Physics2D.OverlapCircle(spawnPoint, distanceBarriers) != null)
            {
                spawnPoint = Random.insideUnitCircle * distance;
                i = 0;
            }
        }

        return spawnPoint;
    }

    private void SpawnBarriers()
    {
        for (int countBarriers = 1; countBarriers <= maxCountAllBarriers; countBarriers++)
        {
            SpawnOneBarriers();
        }
    }

    private void SpawnOneBarriers()
    {
        Instantiate(
                     barriers,
                     ApproveDistance(distanceBetweenBarriers),
                     Quaternion.identity,
                     barriersTransform);
    }

    private Vector3 ApproveDistance(float distanceBarriers)
    {
        spawnPoint = Random.insideUnitCircle * distance;

        for (int i = 0; i < 5; i++)
        {
            if (Physics2D.OverlapCircle(spawnPoint, distanceBarriers) != null)
            {
                spawnPoint = Random.insideUnitCircle * distance;
                i = 0;
            }
        }

        return spawnPoint;
    }
}
