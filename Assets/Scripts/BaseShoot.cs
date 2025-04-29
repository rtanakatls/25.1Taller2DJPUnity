using System.Collections.Generic;
using UnityEngine;

public class BaseShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float timer;
    [SerializeField] private float shootDelay;
    private Transform target;

    private void Update()
    {
        CheckTarget();
        Shoot();
    }

    private void CheckTarget()
    {
        List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        float distance = float.MaxValue;
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector2.Distance(enemy.transform.position, transform.position);
            if (distance>enemyDistance)
            {
                distance = enemyDistance;
                target = enemy.transform;
            }
        }
    }

    private void Shoot()
    {
        if (target != null)
        {
            timer += Time.deltaTime;
            if (timer >= shootDelay)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                Vector2 direction = target.position - transform.position;
                obj.GetComponent<BulletMovement>().SetDirection(direction);
                timer = 0;
            }
        }
    }

}
