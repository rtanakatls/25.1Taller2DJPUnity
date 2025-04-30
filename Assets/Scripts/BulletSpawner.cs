using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnDelay;
    private float timer;
    private int currentFibonacci;

    private void Start()
    {
        currentFibonacci = 0;
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            int spawnNumber = GetFibonacci();
            for (int i = 1; i <= spawnNumber; i++)
            {
                Spawn();
            }
            timer = 0;
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.position = transform.position + (Vector3.one * Random.value);

    }

    int GetFibonacci()
    {
        currentFibonacci++;
        int a=0;
        int b=1;
        int c;
        for(int i = 1; i < currentFibonacci; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return a;
    }
}
