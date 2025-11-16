using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float height;

    [SerializeField] private Coin coinPrefab;

    private Vector3 spawnPos = Vector3.zero;

    private void Start()
    {
        PoolManager.Instance.CreatePool(coinPrefab, 80);
    }

    public void StartRandomSpawn(int initCount) 
    {
        RandomSpawn(initCount);
    }

    private void RandomSpawn(int initCount) 
    {
        for (int i = 0; i < initCount; i++) 
        {
            Coin coin = PoolManager.Instance.GetFromPool(coinPrefab);

            float posX = Random.Range(-radius, radius);
            float posZ = Random.Range(-radius, radius);
            float posY = Random.Range(0, height);

            spawnPos = new Vector3(posX, posY, posZ);
            
            if (coin != null)
            {
                coin.transform.position = spawnPos;
                coin.gameObject.SetActive(true);
            }
        }
    }
}
