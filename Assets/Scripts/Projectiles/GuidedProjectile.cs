using UnityEngine;

public class GuidedProjectile : BaseProjectile
{
    [SerializeField] private float speed = 0.2f;

    public override float Speed => speed;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        var direction = (targetPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            OnHit(null);
        }
    }

    protected override void OnHit(Monster monster)
    {
        if (monster != null)
        {
            monster.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
