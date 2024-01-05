using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : DatMonoBehaviour
{
    [SerializeField] protected Transform player;


    private static PlayerController instance;

    public static PlayerController Instance => instance;


    protected override void Awake()
    {
        base.Awake();
        PlayerController.instance = this;
    }


    public virtual Transform GetPlayer()
    {
        return this.player;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }


    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }





}
