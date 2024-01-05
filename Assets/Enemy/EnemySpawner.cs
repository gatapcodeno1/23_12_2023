using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance => instance;


    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }


    public override Transform Spawn(string bulletName, Vector3 spawnpos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(bulletName);
        if (prefab == null)
        {
            Debug.Log("Prefab Not Found");
            return null;
        }
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.transform.rotation = rotation;
        newPrefab.transform.position = spawnpos;
        newPrefab.GetComponent<EnemyStatus>().SetShooted(false);
        Debug.Log(newPrefab.GetComponent<EnemyStatus>().GetShooted());
        newPrefab.SetParent(this.holder);
        return newPrefab;
    }


}
