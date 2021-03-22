using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> meteorPrefabs;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int numberOfMeteor = 3;
    [SerializeField] float timeOfSpawn = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 3f;

    public List<GameObject> GetMeteorPrefabs() => meteorPrefabs;
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefab.transform)
        {
            waypoints.Add(waypoint);
        }
        return waypoints;
    }
    public int GetNumberOfMeteor() => numberOfMeteor;
    public float GetTimeOfSpawn() => timeOfSpawn;
    public float GetMoveSpeed() => moveSpeed;
}
