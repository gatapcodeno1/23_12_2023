using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DatMonoBehaviour
{
    [SerializeField] public BulletFly bulletFly;
    [SerializeField] public BulletSpawner bulletSpawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletFly();
        this.LoadBulletSpawner();
    }

    protected virtual void LoadBulletFly()
    {
        if (this.bulletFly != null) return;
        Debug.Log(transform.name + ": LoadBulletFly", gameObject);
        this.bulletFly = transform.GetComponentInChildren<BulletFly>();
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        Debug.Log(transform.name + ": bulletSpawner", gameObject);
        this.bulletSpawner = transform.parent.parent.GetComponent<BulletSpawner>();
    }

}
