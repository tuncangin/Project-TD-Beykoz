using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    public GameObject projectilePrefab;
    private int poolSize = 20;

    private Queue<GameObject> projectilePool = new Queue<GameObject>();

    private void Awake()
    {
        GameObject go;
        for (int i = 0; i < poolSize; i++)
        {
            go = Instantiate(projectilePrefab,transform);
            go.SetActive(false);
            go.GetComponent<Projectile>().Init(this);
            projectilePool.Enqueue(go);
        }
    }

    public GameObject GetProjectileFromPool()
    {
        if (projectilePool.Count > 0)
        {
            GameObject go = projectilePool.Dequeue();
            go.SetActive(true);
            return go;
        }
        else
        {
            GameObject go = Instantiate(projectilePrefab,transform);
            go.GetComponent<Projectile>().Init(this);
            return go;
        }
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
    
    
}
