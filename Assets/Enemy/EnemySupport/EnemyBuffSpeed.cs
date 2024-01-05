using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffSpeed : DatMonoBehaviour
{
    [SerializeField] protected float TimeUse = 3f;
    [SerializeField] protected float TimeCur = 3f;
    [SerializeField] protected float SpeedBuff = 0.2f;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] SphereCollider sphereCollider;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.sphereCollider.enabled = true;
    }

    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadSphereCollider();
    }

    protected virtual void FixedUpdate()
    {
        TimeCur += Time.fixedDeltaTime;
        if (this.TimeCur < this.TimeUse) return;
        this.BuffSpeedEnemy();

    }


    protected virtual void BuffSpeedEnemy()
    {
        this.TimeCur = 0f;
        this.sphereCollider.enabled = true;
        Invoke(nameof(TurnOffRigidbody),3f);
    }


    protected virtual void TurnOffRigidbody()
    {
        this.sphereCollider.enabled = false;
    }

    protected virtual void LoadRigidbody() { 
        if(this._rigidbody != null) return;
        Debug.Log(transform.name + ": LoadRigidBody", gameObject);
        this._rigidbody = transform.GetComponent<Rigidbody>();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
        this.sphereCollider = transform.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    { 
        EnemyMovement enemyMovement = other.transform.parent.GetComponentInChildren<EnemyMovement>();
        
        if (enemyMovement == null) return;
        Debug.Log(other.transform.parent.name);
        enemyMovement.AddSpeed(SpeedBuff);
    }
}
