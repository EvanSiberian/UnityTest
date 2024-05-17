using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour, IProjectile
{
    protected int damage;
    protected Vector3 targetPosition;

    public abstract float Speed { get; }

    public virtual int Damage
    {
        get => damage;
        set => damage = value;
    }

    public virtual void Initialize(Vector3 targetPosition, int damage)
    {
        this.targetPosition = targetPosition;
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            var monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                OnHit(monster);
            }
            Destroy(gameObject);
        }
    }

    protected abstract void Move();
    protected abstract void OnHit(Monster monster);
}
