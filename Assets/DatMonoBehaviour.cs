using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Awake()
    {
        this.Reset();
        this.LoadComponents();
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void LoadComponents()
    {
        /* this.LoadPrefab();*/
    }

    protected virtual void ResetValue()
    {

    }

}
