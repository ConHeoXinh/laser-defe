using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName ="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefap;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemyspawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumspawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefap)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefap.GetChild(0);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpwanTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemyspawns - spawnTimeVariance, timeBetweenEnemyspawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minimumspawnTime, float.MaxValue);
    }
}
