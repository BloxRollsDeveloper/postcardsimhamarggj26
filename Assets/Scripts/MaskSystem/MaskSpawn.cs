using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaskSpawn : MonoBehaviour
{
    public GameObject MaskPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 30f;

    private List<Transform> freePoints;

    void Start()
    {
        freePoints = new List<Transform>(spawnPoints);
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (freePoints.Count > 0)
            {
                Transform point = freePoints[Random.Range(0, freePoints.Count)];
                
                GameObject mask = Instantiate(MaskPrefab, point.position, Quaternion.identity);
                mask.GetComponent<MaskCollect>().Init(this, point);
                
                freePoints.Remove(point);
            }
        }
        yield return new WaitForSeconds(spawnInterval);
    }

    public void FreePoint(Transform point)
    {
        if (!freePoints.Contains(point))
            freePoints.Add(point);
    }
}