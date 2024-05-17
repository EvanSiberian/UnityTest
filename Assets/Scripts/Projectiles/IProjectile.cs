using UnityEngine;

public interface IProjectile
{
    void Initialize(Vector3 targetPosition, int damage);
    float Speed { get; }
}
