using UnityEngine;

public class Collectable : MonoBehaviour
{
    private PostNoteSpawn spawner;
    private Transform spawnPoint;

    private AIController enemy;

    public void Init(PostNoteSpawn spawner, Transform spawnPoint)
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
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }
            if (enemy != null)
            {
                enemy.IncreaseSpeed(0.5f);
            }
            if (spawner != null && spawnPoint != null)
            {
                spawner.DecrementSpawnCount(spawnPoint);
            }
            Destroy(gameObject);
        }
    }
}