using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCtrl : DatMonoBehaviour
{
    [SerializeField] public Spawner spawner;
    [SerializeField] public EnemySpawnPoint spawnPoints;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<Spawner>();
        Debug.Log(transform.name + " :LoadSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<EnemySpawnPoint>();
        Debug.Log(transform.name + ":LoadSpawnPoint ", gameObject);
    }


}
