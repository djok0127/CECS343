using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    //public GameOjbect bulletPrefab;
    Dictionary<int, List<GameObject>> poolDictionary = new Dictionary<int, List<GameObject>>();
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToPool(GameObject prefab, int amount)
    {
        int poolKey = prefab.GetInstanceID();
        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new List<GameObject>());
            for(int i = 0; i < amount; i++)
            {
                GameObject newObject = Instantiate(prefab) as GameObject;
                newObject.SetActive(false);
                poolDictionary[poolKey].Add(newObject);
            }
        }
    }
    public GameObject GetGameObjectByID(GameObject prefab)
    {
        int key = prefab.GetInstanceID();
        if (poolDictionary.ContainsKey(key))
        {
            for(int i = 0; i < poolDictionary[key].Count; i++)
            {
                if (!poolDictionary[key][i].activeInHierarchy)
                {
                    return poolDictionary[key][i];
                }
            }
        }
        return null;
    }
}
