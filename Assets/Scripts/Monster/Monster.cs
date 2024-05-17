using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed = 3f; 
    [SerializeField] private int health = 10;
    private Transform target;
    public Vector3 PreviousPosition { get; private set; }

    private void Start()
    {
        PreviousPosition = transform.position;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            PreviousPosition = transform.position;
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * step;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
