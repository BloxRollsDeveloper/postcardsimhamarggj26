using UnityEngine;

public class MaskCollect : MonoBehaviour
{
    private MaskSpawn spawner;
    private Transform spawnPoint;

    public void Init(MaskSpawn spawner, Transform spawnPoint)
    {
        this.spawner = spawner;
        this.spawnPoint = spawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        // mask logic incoming
        
        spawner.FreePoint(spawnPoint);
        Destroy(gameObject);
    }
}
