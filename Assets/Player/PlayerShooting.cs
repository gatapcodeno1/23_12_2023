using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : DatMonoBehaviour
{
    [SerializeField] protected double attackDelay = 1f;
    [SerializeField] protected double currentDelay = 1f;



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

       
        Debug.Log("Shooting");
        Vector3 pos = transform.position;
        Quaternion ros = transform.rotation;
        Transform rand = BulletSpawner.Instance.GetRandom();
        Transform newBullet = BulletSpawner.Instance.Spawn(rand.name, pos, ros);
        newBullet.gameObject.SetActive(true);
    }
}
