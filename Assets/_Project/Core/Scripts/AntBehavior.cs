using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private NavMeshAgent _agent;

    public float Health
    { 
        get { return _health; } 
        set { _health = value; } 
    }

    private void Update()
    {
        _agent.destination = _target.transform.position;
    }
}
