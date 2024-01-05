using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawnRandom : DatMonoBehaviour
{
    [SerializeField] protected EnemySpawnCtrl enemySpawnCtrl;
    [SerializeField] protected double timeDelay = 1f;
    [SerializeField] protected double randTimer = 1f;
    
    protected virtual void FixedUpdate()
    {
        this.EnemySpawn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnCtrl();
    }


    protected virtual void LoadEnemySpawnCtrl()
    {
        if (this.enemySpawnCtrl != null) return;
        this.enemySpawnCtrl = GetComponent<EnemySpawnCtrl>();
        Debug.Log(transform.name + ": LoadEnemySpawnCtrl", gameObject);

    }

    protected virtual void EnemySpawn()
    {
        this.randTimer += Time.fixedDeltaTime;
        if (this.randTimer < this.timeDelay) return;
        this.randTimer %= timeDelay;

        Transform rand = enemySpawnCtrl.spawnPoints.GetRandom();

        Vector3 pos = rand.position;

        pos.x += Random.Range(-2, 2);
        pos.y += Random.Range(-2, 2);

        Quaternion ros = transform.rotation;
        Transform ran = EnemySpawner.Instance.GetRandom();
        Transform obj = this.enemySpawnCtrl.spawner.Spawn(ran.name, pos, ros);
        obj.gameObject.SetActive(true);


    }

}
