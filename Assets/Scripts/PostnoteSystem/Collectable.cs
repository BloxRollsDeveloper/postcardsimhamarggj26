using UnityEngine;

public class Collectable : MonoBehaviour
{
    private PostNoteSpawn spawner;
    private Transform spawnPoint;

    public void Init(PostNoteSpawn spawner, Transform spawnPoint)
    {
        this.spawner = spawner;
        this.spawnPoint = spawnPoint;
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
            if (spawner != null && spawnPoint != null)
            {
                spawner.DecrementSpawnCount(spawnPoint);
            }
            Destroy(gameObject);
        }
    }
}