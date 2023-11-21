using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public List<GameObject> objectPool;
    public List<GameObject> objectsToPool = new List<GameObject>();
    public int amountToPool;
    public static SpawnManager Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
    }
    // https://learn.unity.com/tutorial/introduction-to-object-pooling#5ff8d015edbc2a002063971d
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }
        return null;
    }
    void Start()
    {
        objectPool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Count)]);
            tmp.SetActive(false);
            objectPool.Add(tmp);
            Debug.Log("Adding...");
        }
    }
}
