using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float interval = 3f;
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform moveTarget;

    private float lastSpawnTime = -1f;

    private void Update()
    {
        if (Time.time > lastSpawnTime + interval)
        {
            SpawnMonster();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnMonster()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject newMonster = Instantiate(monsterPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

        Monster monsterBehavior = newMonster.GetComponent<Monster>();
        if (monsterBehavior != null)
        {
            monsterBehavior.SetTarget(moveTarget);
        }
    }
}
