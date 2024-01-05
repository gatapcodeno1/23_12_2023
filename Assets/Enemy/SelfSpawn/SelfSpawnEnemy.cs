using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpawnEnemy : DatMonoBehaviour
{
    [SerializeField] protected int timeSpawn = 5;
    
    [SerializeField] protected float timeWait = 2f;
    [SerializeField] protected float timeCur = 2f;

    protected virtual void FixedUpdate()
    {
        this.timeCur += Time.fixedDeltaTime;
        if (this.timeCur < this.timeWait) return;
        timeCur = 0f;
        Vector3 pos = transform.parent.position;

        pos.x += Random.Range(-2, 2);
        pos.y += Random.Range(-2, 2);

        Quaternion ros = transform.rotation;
        Transform ran = EnemySpawner.Instance.Spawn("Enemy_1", pos, ros);
        ran.gameObject.SetActive(true);
    }


   
}
