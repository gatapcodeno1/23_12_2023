using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : ObjectDestroy
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
    }
    protected override void OnEnable()
    {
        // base destroy by times
        Invoke(nameof(DestroyBullet), 5);
    }

    protected virtual void DestroyBullet()
    {
        //BulletSpawner.Instance.Despawner(transform.parent);
    }
}
