using UnityEngine;

public class SimpleTower : BaseTower
{
	protected override void AimAtTarget()
	{
		// SimpleTower не нуждается в повороте для прицеливания
		// Для расширения нужно сделать отдельный интерфейс под метод
	}

	protected override void Shoot(Monster target)
	{
		var projectileObject = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
		var projectile = projectileObject.GetComponent<IProjectile>();
		if (projectile != null)
		{
			projectile.Initialize(target.transform.position, 10);
		}
	}
}
