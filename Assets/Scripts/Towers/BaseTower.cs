using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    [SerializeField] protected float shootInterval = 0.5f;
    [SerializeField] protected float range = 4f;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform shootPoint;
    protected float lastShotTime = -0.5f;

    protected Monster currentTarget;

    private void Update()
    {
        if (projectilePrefab == null || shootPoint == null)
            return;

        currentTarget = FindTarget();
        if (currentTarget != null)
        {
            AimAtTarget();
            if (lastShotTime + shootInterval <= Time.time)
            {
                Shoot(currentTarget);
                lastShotTime = Time.time;
            }
        }
    }

    protected Monster FindTarget()
    {
        Monster nearestMonster = null;
        float shortestDistance = Mathf.Infinity;
        foreach (var monster in FindObjectsOfType<Monster>())
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                nearestMonster = monster;
            }
        }
        return nearestMonster;
    }

    protected abstract void AimAtTarget();

    protected abstract void Shoot(Monster target);
}
