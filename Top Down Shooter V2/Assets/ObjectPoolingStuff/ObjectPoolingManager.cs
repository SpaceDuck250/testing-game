using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;


    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public Dictionary<string, GameObject> prefabDictionary;

    [System.Serializable] // Kinda like base data for the pools (just helps with filling)
    public class Pool
    {
        public string tag;
        public GameObject obj;
        public int amount;
    }

    public List<Pool> poolList = new List<Pool>();

    private void Awake()
    {
        instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        prefabDictionary = new Dictionary<string, GameObject>();

        FillPool();
    }

    public void FillPool()
    {
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for (int i = 0; i < pool.amount; i++)
            {
                GameObject newpoolobj = Instantiate(pool.obj, transform);
                newpoolobj.SetActive(false);
                objPool.Enqueue(newpoolobj);
            }

            poolDictionary.Add(pool.tag, objPool);
            prefabDictionary.Add(pool.tag, pool.obj);
        }
    }

    public GameObject SpawnObject(string tag, Vector3 spawnposition, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject newobj = poolDictionary[tag].Dequeue();

        if (newobj.activeInHierarchy)
        {
            newobj = Instantiate(prefabDictionary[tag], transform);
            Debug.Log("Pool expanded for tag: " + tag);
        }


        newobj.SetActive(true);
        newobj.transform.position = spawnposition;
        newobj.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(newobj);

        return newobj;
    }

    public void DestroyObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    
}
