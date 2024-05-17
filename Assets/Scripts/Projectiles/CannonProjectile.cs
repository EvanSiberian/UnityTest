using UnityEngine;

public class CannonProjectile : BaseProjectile
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int projectileDamage = 50;

    public override float Speed => speed;

    public override int Damage
    {
        get => projectileDamage;
        set => projectileDamage = value;
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    protected override void OnHit(Monster monster)
    {
        if (monster != null)
        {
            monster.TakeDamage(projectileDamage);
        }
        Destroy(gameObject);
    }
}
