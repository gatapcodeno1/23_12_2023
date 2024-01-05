using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : DatMonoBehaviour
{
    [SerializeField] protected float bulletSpeed = 0.2f;
    [SerializeField] public Transform currentEnemy;
    [SerializeField] protected Vector3 lastPos;
    protected virtual void FixedUpdate()
    {
        
        this.GotoEnemy();
    }


    protected override void OnEnable()
    {
        this.currentEnemy = null;
        this.GetNearestTarget();

    }

    protected virtual void GetNearestTarget()
    {
        
        float minDistance = 1000000;

        foreach (Transform enemy in EnemySpawner.Instance.holder) 
        {
            if (enemy.gameObject.activeSelf == false) continue ;
            EnemyStatus enemyStas = enemy.GetComponent<EnemyStatus>();
            if (enemyStas.GetShooted() == true) continue;
            float distance = Vector2.Distance(enemy.transform.position, PlayerController.Instance.GetPlayer().transform.position);
            if (minDistance > distance)
            {
                minDistance = distance;
                this.currentEnemy = enemy;
            }
        }


        
        if (this.currentEnemy == null) return;
        lastPos = this.currentEnemy.transform.position;

    }

    protected virtual void GotoEnemy()
    {
        if (this.currentEnemy == null) { BulletSpawner.Instance.Despawner(transform.parent); return; }
        
        EnemyStatus enemySta = this.currentEnemy.GetComponent<EnemyStatus>();
        if (enemySta != null) enemySta.SetShooted(true);
        Vector2 newpos = Vector2.MoveTowards(transform.parent.position, lastPos, bulletSpeed);
        transform.parent.position = newpos;
        if(transform.parent.position == lastPos)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    

}
