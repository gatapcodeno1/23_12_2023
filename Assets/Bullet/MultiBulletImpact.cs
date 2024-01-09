using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBulletImpact : BulletImpact
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Bullet_2") return;
        BulletSpawner.Instance.Despawner(this.transform.parent);

        //GameObject.Destroy(transform.parent.gameObject);
        Spawner spawner = other.transform.parent.parent.parent.GetComponent<Spawner>();
        spawner.Despawner(other.transform.parent);
    }
}
