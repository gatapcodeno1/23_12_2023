using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpact : DatMonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody _rigidbody;
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
        this.LoadRigidBody();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider>();
        Debug.Log(transform.name + ": LoadBoxCollider",gameObject);

    }

    protected virtual void LoadRigidBody()
    {
        if(this._rigidbody != null) return; 
        this._rigidbody = transform.GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigidBody", gameObject);
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);

    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent != bulletCtrl.bulletFly.currentEnemy)  return;

        BulletSpawner.Instance.Despawner(this.transform.parent);

        //GameObject.Destroy(transform.parent.gameObject);
        Spawner spawner = other.transform.parent.parent.parent.GetComponent<Spawner>();
        spawner.Despawner(other.transform.parent);
        
    }

}
