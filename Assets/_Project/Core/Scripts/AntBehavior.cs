using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;
    [SerializeField]
    private bool _isVariant = false;
    [SerializeField]
    private GameObject _target;

    public float Health
    { 
        get { return _health; } 
        set { _health = value; } 
    }

    public bool Variant 
    { 
        get { return _isVariant; } 
    }
}
