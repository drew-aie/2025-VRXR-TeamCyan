using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;

    public float Health
    { 
        get { return _health; } 
        set { _health = value; } 
    }
}
