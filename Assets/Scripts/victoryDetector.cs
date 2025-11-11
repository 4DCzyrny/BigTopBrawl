using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryDetector : MonoBehaviour
{
    public GameObject p1Victory;
    public GameObject p2Victory;
    public PlayerOneStats stats;
    public PlayerTwoStats stats2;
    public PlayerOneManager manager;
    public PlayerTwoManager manager2;

    void Start()
    {
        p1Victory.SetActive(false);
        p2Victory.SetActive(false);
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
        }
        if (stats.health <= 0)
        {
            p2Victory.SetActive(true);
            manager.P1CanAttack = false;
            manager.canMove = false;
            manager2.P2CanAttack = false;
            manager2.canMove = false;
        }
    }
}
