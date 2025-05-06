using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public void TakeDamage()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
