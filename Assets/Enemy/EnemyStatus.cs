using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : DatMonoBehaviour
{
    [SerializeField] protected bool isShooted = false;

    private static EnemyStatus instance;

    public static EnemyStatus Instance => instance;


    protected override void Awake()
    {
        base.Awake();
        EnemyStatus.instance = this;
    }

    protected override void OnEnable()
    {
        
        this.isShooted = false;
    }

    public virtual bool GetShooted()
    {
        return this.isShooted;
    }

    public virtual void SetShooted(bool isShooted)
    {
        this.isShooted = isShooted;
    }

}
