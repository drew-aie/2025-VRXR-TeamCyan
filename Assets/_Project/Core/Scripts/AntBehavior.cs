using HurricaneVR.Framework.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private GameObject _owner;
    [SerializeField]
    private BugSpawner _bugSpawner;

    private GameObject _target;
    private float _killCount;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    public float Health
    { 
        get { return _health; } 
        set { _health = value; } 
    }

    public float Extermination
    {
        get { return _killCount; }
    }

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    private void Update()
    {
        if (_health <= 0) 
        {
            _bugSpawner.DespawnBugs(_owner);
            _killCount++; 
        }
        _agent.destination = _target.transform.position;
    }
}
