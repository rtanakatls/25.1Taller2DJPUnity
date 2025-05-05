using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Vector2 targetPosition;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 direction,Vector2 targetPosition)
    {
        this.direction = direction;
        this.targetPosition = targetPosition;
    }



    void Update()
    {
        Move();
        CheckDestroy();
    }

    private void Move()
    {
        rb2d.linearVelocity = direction.normalized * speed;
    }

    private void CheckDestroy()
    {
        if (Vector2.Distance(targetPosition, transform.position) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }


}
