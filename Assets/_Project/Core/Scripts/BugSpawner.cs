using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BugSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawner;
    [SerializeField]
    private GameObject[] Bugs;
    [SerializeField]
    private BoxCollider _collider;

    private GameObject _currentBug;
    private bool _isBugSpawned = false;
    private float _timeBeforeSpawn = 3;

    private void Start()
    {
        SetCurrentBug();
    }

    private void Update()
    {
        OnTriggerEnter(_collider);
        OnTriggerExit(_collider);
    }

    IEnumerator TimedSpawn()
    {
        yield return new WaitForSeconds(_timeBeforeSpawn);
        SpawnObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        _isBugSpawned = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isBugSpawned = false;
        StartCoroutine(TimedSpawn());
    }

    private void SetCurrentBug()
    {
        GameObject previousBug = _currentBug;

        _currentBug = Bugs[Random.Range(0, Bugs.Length)];

        if (previousBug == _currentBug)
            _currentBug = Bugs[Random.Range(0, Bugs.Length)];
    }
    private void SpawnObjects()
    {
        SetCurrentBug();

        Instantiate(_currentBug, transform.position, transform.rotation);
        _isBugSpawned = true;
    }
}
