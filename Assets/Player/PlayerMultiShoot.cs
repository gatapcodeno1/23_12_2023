using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiShoot : DatMonoBehaviour
{
    [SerializeField] protected double attackDelay = 3f;
    [SerializeField] protected double currentDelay = 3f;
    [SerializeField] protected int timeShoot = 3;


    // Start is called before the first frame update


    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        this.Shoot();
    }

    protected virtual void Shoot()
    {
        currentDelay += Time.fixedDeltaTime;
        if (currentDelay < attackDelay) return;
        this.currentDelay = 0f;
        this.Shooting();

    }

    protected virtual void Shooting()
    {

        
        Quaternion ros = transform.rotation;
        Transform rand = BulletSpawner.Instance.GetRandom();
        for (int i = 0; i < timeShoot; i++)
        {
            Vector3 pos = transform.position;
            
            Transform newBullet = BulletSpawner.Instance.Spawn("Bullet_2",pos, ros);
            newBullet.gameObject.SetActive(true);
        }
    }
}
