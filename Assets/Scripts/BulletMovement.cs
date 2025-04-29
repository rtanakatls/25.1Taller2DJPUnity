using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        rb2d.linearVelocity = direction.normalized * speed;
    }

}
