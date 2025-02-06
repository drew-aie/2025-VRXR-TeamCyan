using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class GameTimerManager : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] private float gameTime;
    [SerializeField] private TextMeshProUGUI timeTextBox;
    public bool allowTimer;
    [SerializeField]
    private BugSpawner Spawner;
    private enum GameState
    {
        Waiting,
        Playing,
        Completed,
        End
    }

    private GameState gamestate;
    [Header("Timer Events")]
    public UnityEvent onTimerExpire;

    [Header("NPC Proximity Settings")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask npcLayer;
    [SerializeField] private float npcCheckRadius = 5f;
    [SerializeField] private float timePenalty = 2f; // Time deducted when NPC is nearby

    void Start()
    {
        Spawner.PauseSpawn = true;
        allowTimer = true;
        gamestate = GameState.Playing;
    }

    void Update()
    {
        if (allowTimer)
        {
            UpdateGameTimer();
            CheckNPCProximity(); // Check for NPCs nearby
        }

        if (gamestate == GameState.Playing)
            CheckTime();
        else if (gamestate == GameState.End)
            Spawner.PauseSpawn = true;

    }

    private void UpdateGameTimer()
    {
        gameTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        string gameTimeClockDisplay = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeTextBox.text = gameTimeClockDisplay;
    }

    private void CheckTime()
    {
        if (gameTime <= 0)
        {
            Spawner.PauseSpawn = true;
            allowTimer = false;
            timeTextBox.text = "Game Over!";
            onTimerExpire.Invoke();
            gamestate = GameState.End;
        }
    }

    private void CheckNPCProximity()
    {
        Collider[] npcsInRange = Physics.OverlapSphere(playerTransform.position, npcCheckRadius, npcLayer);

        if (npcsInRange.Length > 0)
        {
            gameTime -= timePenalty * Time.deltaTime; // Deduct time continuously if NPCs are nearby
        }
    }

    // Draws the detection sphere in the scene view for debugging
    private void OnDrawGizmosSelected()
    {
        if (playerTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(playerTransform.position, npcCheckRadius);
        }
    }
}
