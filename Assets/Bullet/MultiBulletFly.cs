using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBulletFly : BulletFly
{

    [SerializeField] protected Vector3 direct;
    [SerializeField] protected float speed = 15f;

    protected override void FixedUpdate()
    {
        this.transform.parent.Translate(this.direct * Time.fixedDeltaTime * this.speed);
    }

    protected override void OnEnable()
    {
        direct.x = Random.Range(-2f, 2f);
        direct.y = Random.Range(-2f, 2f);
    }
}
