using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaskSpawn : MonoBehaviour
{
    [Header("PostNote Prefab")]
    public GameObject[] MaskPrefabs;
    
    [Header("Spawn Points")]
    public Transform[] spawnPoints;
    
    [Header("Spawn Limit")]
    public int spawnLimit = 3;
    
    [Header("Spawn Interval")]
    public float spawnInterval = 2f;

    private List<Transform> availableSpawnPoints;
    private int currentSpawnCount = 0;

    void Awake()
    {
        availableSpawnPoints = new List<Transform>(spawnPoints);
    }

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (currentSpawnCount < spawnLimit && availableSpawnPoints.Count > 0)
            {
                int pointIndex = Random.Range(0, availableSpawnPoints.Count);
                Transform spawnPoint = availableSpawnPoints[pointIndex];

                int prefabIndex = Random.Range(0, MaskPrefabs.Length);
                GameObject spawnedNote = Instantiate(MaskPrefabs[prefabIndex], spawnPoint.position, Quaternion.identity);
                CollectMask CollectMask = spawnedNote.GetComponent<CollectMask>();
                if (CollectMask != null)
                {
                    CollectMask.Init(this, spawnPoint);
                }
                currentSpawnCount++;
                availableSpawnPoints.RemoveAt(pointIndex);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void DecrementSpawnCount(Transform freedSpawnPoint)
    {
        currentSpawnCount = Mathf.Max(0, currentSpawnCount - 1);
        if (!availableSpawnPoints.Contains(freedSpawnPoint))
        {
            availableSpawnPoints.Add(freedSpawnPoint);
        }
    }
}