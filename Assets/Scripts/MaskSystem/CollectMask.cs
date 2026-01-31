using UnityEngine;

public class CollectMask : MonoBehaviour
{
    private MaskSpawn spawner;
    private Transform spawnPoint;

    private AIController enemy;

    public void Init(MaskSpawn spawner, Transform spawnPoint)
    {
        this.spawner = spawner;
        this.spawnPoint = spawnPoint;
    }

    private void Start()
    {
        enemy = FindObjectOfType<AIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemy != null)
            {
                enemy.StopMovement();
            }
            if (spawner != null && spawnPoint != null)
            {
                spawner.DecrementSpawnCount(spawnPoint);
            }
            Destroy(gameObject);
        }
    }
}