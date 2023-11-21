using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public SpawnManager spawnManager;
    public int minSpawnTime = 1;
    public int maxSpawnTime = 5;
    public float maxDistance = 5;
    public Vector3 ballSize = Vector3.one;
    // https://forum.unity.com/threads/invokerepeating-random-interval.105107/
    private void SpawnObject()
    {
        GameObject obj = spawnManager.GetPooledObject();
        // Randomize the position.
        obj.transform.position = transform.position + new Vector3(Random.Range(-maxDistance, maxDistance), 1, Random.Range(-maxDistance, maxDistance));
        obj.transform.rotation = transform.rotation;
        obj.transform.localScale = ballSize;
        obj.SetActive(true);
        // Spawn the next object within a random amt of time.
        float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnObject", randomTime);
    }
    private void Start()
    {
        Invoke("SpawnObject", 0.1f);
    }
}
