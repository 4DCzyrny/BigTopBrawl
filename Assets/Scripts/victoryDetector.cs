using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryDetector : MonoBehaviour
{
    public GameObject p1Victory;
    public GameObject p2Victory;
    public GameObject timerEnded;
    public PlayerOneStats stats;
    public PlayerTwoStats stats2;
    public PlayerOneManager manager;
    public PlayerTwoManager manager2;
    public float timer = 99f;
    public bool gameRunning = true;

    void Start()
    {
        p1Victory.SetActive(false);
        p2Victory.SetActive(false);
        timerEnded.SetActive(false);
        timer = 99f;
    }
    void Update()
    {
        if (stats2.health <= 0)
        {
            p1Victory.SetActive(true);
            manager.P1CanAttack = false;
            manager.canMove = false;
            manager2.P2CanAttack = false;
            manager2.canMove = false;
            gameRunning = false;
        }
        if (stats.health <= 0)
        {
            p2Victory.SetActive(true);
            manager.P1CanAttack = false;
            manager.canMove = false;
            manager2.P2CanAttack = false;
            manager2.canMove = false;
            gameRunning = false;
        }
        if (timer > 0 && gameRunning)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timerEnded.SetActive(true);
            manager.P1CanAttack = false;
            manager.canMove = false;
            manager2.P2CanAttack = false;
            manager2.canMove = false;
        }
    }
}
