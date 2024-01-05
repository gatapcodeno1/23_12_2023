using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDestroy : DatMonoBehaviour
{


    protected virtual void FixedUpdate()
    {
        this.DespawnEnemy();
    }

    protected virtual void DespawnEnemy()
    {
        if (Vector2.Distance(transform.parent.position, PlayerController.Instance.GetPlayer().transform.position) < 1f)
        {
            EnemySpawner.Instance.Despawner(transform.parent);
        }
    }

}
