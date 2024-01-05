using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : DatMonoBehaviour
{
    [SerializeField] protected float speed = 0.03f;



    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetSpeed();
    }

    protected virtual void Moving()
    {
        Vector2 newpos =  Vector2.MoveTowards(transform.parent.position , PlayerController.Instance.GetPlayer().position, speed);
        transform.parent.position = newpos;
    }

    public virtual void AddSpeed(float speed)
    {
        this.speed += speed;
    }

    public virtual void ResetSpeed()
    {
        this.speed = 0.03f;
    }


    
    


}
