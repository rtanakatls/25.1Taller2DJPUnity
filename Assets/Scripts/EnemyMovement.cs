using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Transform target;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject b = GameObject.FindGameObjectWithTag("Base");
        if (b != null) 
        {
            target = b.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            direction = target.position - transform.position;
            rb2d.linearVelocity = direction.normalized * speed;
        }
        else
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}
