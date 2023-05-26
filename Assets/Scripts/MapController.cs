using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    
    public List<GameObject> maps = new List<GameObject>();
    public List<Vector2> mapLocations = new List<Vector2>();
    public List<GameObject> mapPrefabs = new List<GameObject>();

    public Vector3 spawnLocation;
    public Transform mapHolder;

    private void Update()
    {
        if (maps[2].transform.position.x <= mapLocations[1].x)
        {
            GameObject newMap = Instantiate(mapPrefabs[0], spawnLocation, Quaternion.identity, mapHolder);
            maps.Add(newMap);
            Destroy(maps[0]);
            maps.Remove(maps[0]);
        }
    }
}
