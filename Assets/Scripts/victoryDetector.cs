using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryDetector : MonoBehaviour
{
    public Sprite p1vic;
    public Sprite p2vic;
    public Sprite bgnormal;
    public GameObject p1Victory;
    public GameObject p2Victory;
    public GameObject timerEnded;
    public GameObject timerSprite;
    public Image background;
    public PlayerOneStats stats;
    public PlayerTwoStats stats2;
    public PlayerOneManager manager;
    public PlayerTwoManager manager2;
    public float timer = 150f;
    public bool gameRunning = true;

    void Start()
    {
        p1Victory.SetActive(false);
        p2Victory.SetActive(false);
        timerEnded.SetActive(false);
        timerSprite.SetActive(true);
        timer = 150f;
        background.sprite = bgnormal;
    }
    void Update()
    {
        if (stats2.health <= 0)
        {
            p1Victory.SetActive(true);
            timerSprite.SetActive(false);
            background.sprite = p1vic;
            manager.P1CanAttack = false;
            manager.canMove = false;
            manager2.P2CanAttack = false;
            manager2.canMove = false;
            gameRunning = false;
        }
        if (stats.health <= 0)
        {
            p2Victory.SetActive(true);
            timerSprite.SetActive(false);
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
