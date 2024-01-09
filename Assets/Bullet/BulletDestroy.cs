using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : ObjectDestroy
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(Vector3.Distance(this.transform.parent.position,PlayerController.Instance.GetPlayer().position) > 20f)
        {
            BulletSpawner.Instance.Despawner(transform.parent);
        }
    }
    
    
}
