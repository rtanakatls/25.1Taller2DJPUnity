using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
