using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : DatMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObject;
    [SerializeField] public Transform holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadPrefab();
    }

    protected virtual void LoadPrefab()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefab");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefab();
        Debug.Log(transform.name + ":LoadPrefab", gameObject);
    }

    protected virtual void HidePrefab()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    public virtual void Despawner(Transform obj)
    {
        if (this.poolObject.Contains(obj)) return;
        this.poolObject.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform Spawn(string bulletName, Vector3 spawnpos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(bulletName);
        if(prefab == null)
        {
            Debug.Log("Prefab Not Found");
            return null;
        }
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.transform.rotation = rotation;
        newPrefab.transform.position = spawnpos;
        newPrefab.SetParent(this.holder);
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string bulletName)
    {
        foreach(Transform prefab in prefabs)
        {
            if(prefab.name == bulletName)
            {
                return prefab;
            }
        }
        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObject)
        {
            if(poolObj.name == prefab.name)
            {
                this.poolObject.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual Transform GetRandom()
    {
        Transform cur = prefabs[Random.Range(0, prefabs.Count)];
        return cur;
    }

}
