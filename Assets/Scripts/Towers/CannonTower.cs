using UnityEngine;

public class CannonTower : BaseTower
{
    public float rotationSpeed = 5f;

    protected override void AimAtTarget()
    {
        if (currentTarget == null)
            return;

        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    protected override void Shoot(Monster target)
    {
        Vector3 leadPosition = CalculateLeadPosition(target);
        var projectileObject = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        var projectile = projectileObject.GetComponent<IProjectile>();
        if (projectile != null)
        {
            projectile.Initialize(leadPosition, 10);
        }
    }

    private Vector3 CalculateLeadPosition(Monster target)
    {
        Vector3 targetVelocity = (target.transform.position - target.PreviousPosition) / Time.deltaTime;
        Vector3 directionToTarget = target.transform.position - shootPoint.position;
        float distanceToTarget = directionToTarget.magnitude;

        var projectileComponent = projectilePrefab.GetComponent<IProjectile>();
        float projectileSpeed = projectileComponent != null ? projectileComponent.Speed : 10f;

        float timeToTarget = distanceToTarget / projectileSpeed;
        Vector3 leadPosition = target.transform.position + targetVelocity * timeToTarget;

        return leadPosition;
    }
}
