using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Vector2 targetPosition;
    private BulletType type;
    [SerializeField] private float areaRange;
    [SerializeField] private LayerMask layerMask;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 direction,Vector2 targetPosition, BulletType type)
    {
        this.direction = direction;
        this.targetPosition = targetPosition;
        this.type = type;
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
            if (type == BulletType.Explosive)
            {
                Collider2D[] enemyColliders=Physics2D.OverlapCircleAll(transform.position, areaRange, layerMask);
                
            
            }
            Destroy(gameObject);
        }
    }


}
