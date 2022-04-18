using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    float spawnTimer = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate (EnemyPrefab, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
