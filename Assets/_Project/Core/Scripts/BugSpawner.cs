using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent (typeof(Randomizer))]
public class BugSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawner;
    [SerializeField]
    private BoxCollider _collider;
    [SerializeField]
    private Randomizer _randomizer;

    private GameObject _currentBug;
    private bool _isBugSpawned;
    private float _timeBeforeSpawn = 3;

    private void Start()
    {
        _isBugSpawned = false;
        _currentBug = _randomizer.GetRandom();
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

        _currentBug = _randomizer.GetRandom();

        if (previousBug == _currentBug)
            _currentBug = _randomizer.GetRandom();
    }
    private void SpawnObjects()
    {
        if (_isBugSpawned == true)
            return;

        SetCurrentBug();

        Instantiate(_currentBug, transform.position, transform.rotation);
        _isBugSpawned = true;
    }

    private void DespawnBugs()
    {
        _currentBug.SetActive(false);
    }
}
