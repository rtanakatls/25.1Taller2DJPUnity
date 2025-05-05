using System.Collections.Generic;
using UnityEngine;

public class BaseShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float timer;
    [SerializeField] private float shootDelay;
    private Transform target;

    [SerializeField] private float range;

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
            if (distance>enemyDistance && enemyDistance<=range)
            {
                distance = enemyDistance;
                target = enemy.transform;
            }
        }
    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            transform.up = direction;
            if (timer >= shootDelay)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().Setup(direction, target.position);
                timer = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
