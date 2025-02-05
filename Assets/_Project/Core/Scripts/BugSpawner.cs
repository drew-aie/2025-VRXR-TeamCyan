using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private float _timeBeforeSpawn = 3;

    private void Start()
    {
        _currentBug = _randomizer.GetRandom();
    }

    private void Update()
    {
        TimedSpawn();
    }

    IEnumerator TimedSpawn()
    {
        yield return new WaitForSeconds(_timeBeforeSpawn);
        SpawnObjects();
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
        SetCurrentBug();

        Instantiate(_currentBug, transform.position, transform.rotation);
    }

    public void DespawnBugs(GameObject bug)
    {
        bug.SetActive(false);
    }
}
