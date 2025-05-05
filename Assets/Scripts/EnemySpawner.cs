using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    private float timer;
    [SerializeField] private float spawnDelay;

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            GameObject obj = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
            obj.transform.position = transform.position;
            timer = 0;
        }
    }

}
