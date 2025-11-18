using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwitcher : MonoBehaviour
{
    public PlayerOneStats stats;
    public PlayerTwoStats stats2;
    void Start()
    {
        //PLAYER ONE:
        // Character 1: All-Rounder Venester
        if (stats.id == 1)
        {
            stats.lightDmg = 4;
            stats.heavyDmg = 8;
            stats.health = 30;
            stats.maxHealth = 30;
            stats.speed = 4f;
            stats.jump = 9f;
            stats.blockScore = 0.5f;
            stats.attackSpeed = 0.7f;
            stats.heavySpeed = 1.5f;
            stats.canHitAmount = 5f;
        }
        // Character 2: Glass-Cannon Sasha
        if (stats.id == 2)
        {
            stats.lightDmg = 6;
            stats.heavyDmg = 10;
            stats.health = 20;
            stats.maxHealth = 20;
            stats.speed = 7f;
            stats.jump = 11f;
            stats.blockScore = 0.4f;
            stats.attackSpeed = 0.6f;
            stats.heavySpeed = 1.7f;
            stats.canHitAmount = 4f;
        }
        // Character 3: Rushdown Pedro
        if (stats.id == 3)
        {
            stats.lightDmg = 2;
            stats.heavyDmg = 6;
            stats.health = 23;
            stats.maxHealth = 23;
            stats.speed = 11f;
            stats.jump = 11f;
            stats.blockScore = 0.6f;
            stats.attackSpeed = 0.7f;
            stats.heavySpeed = 1f;
            stats.canHitAmount = 7f;
        }
        // Character 4: 
        if (stats.id == 4)
        {
            stats.lightDmg = 7;
            stats.heavyDmg = 7;
            stats.health = 7;
            stats.maxHealth = 7;
            stats.speed = 7f;
            stats.jump = 7f;
            stats.blockScore = 0.7f;
            stats.attackSpeed = 0.7f;
            stats.heavySpeed = 0.7f;
            stats.canHitAmount = 7f;
        }
        // Character 5: 
        if (stats.id == 5)
        {
            stats.lightDmg = 4.5f;
            stats.heavyDmg = 6.25f;
            stats.health = 9.5f;
            stats.maxHealth = 9.5f;
            stats.speed = 7.5f;
            stats.jump = 9.6f;
            stats.blockScore = 0.5f;
            stats.attackSpeed = 0.7f;
            stats.heavySpeed = 1.7f;
            stats.canHitAmount = 7.1f;
        }
        //PLAYER TWO:
        // Character 1: 
        if (stats2.id == 1)
        {
            stats2.lightDmg = 4;
            stats2.heavyDmg = 8;
            stats2.health = 30;
            stats2.maxHealth = 30;
            stats2.speed = 4f;
            stats2.jump = 9f;
            stats2.blockScore = 0.5f;
            stats2.attackSpeed = 0.7f;
            stats2.heavySpeed = 1.5f;
            stats2.canHitAmount = 5f;
        }
        // Character 2: 
        if (stats2.id == 2)
        {
            stats2.lightDmg = 5;
            stats2.heavyDmg = 8;
            stats2.health = 9;
            stats2.maxHealth = 9;
            stats2.speed = 7f;
            stats2.jump = 11f;
            stats2.blockScore = 0.4f;
            stats2.attackSpeed = 0.9f;
            stats2.heavySpeed = 1.7f;
            stats2.canHitAmount = 4f;
        }
        // Character 3: 
        if (stats2.id == 3)
        {
            stats2.lightDmg = 4;
            stats2.heavyDmg = 6;
            stats2.health = 14;
            stats2.maxHealth = 14;
            stats2.speed = 6f;
            stats2.jump = 9f;
            stats2.blockScore = 0.6f;
            stats2.attackSpeed = 0.4f;
            stats2.heavySpeed = 1f;
            stats2.canHitAmount = 7f;
        }
        // Character 4:
        if (stats2.id == 4)
        {
            stats2.lightDmg = 7;
            stats2.heavyDmg = 7;
            stats2.health = 7;
            stats2.maxHealth = 7;
            stats2.speed = 7f;
            stats2.jump = 7f;
            stats2.blockScore = 0.7f;
            stats.attackSpeed = 0.7f;
            stats.heavySpeed = 0.7f;
            stats.canHitAmount = 7f;
        }
        // Character 5: 
        if (stats2.id == 5)
        {
            stats2.lightDmg = 4.5f;
            stats2.heavyDmg = 6.25f;
            stats2.health = 9.5f;
            stats2.maxHealth = 9.5f;
            stats2.speed = 7f;
            stats2.jump = 7f;
            stats2.blockScore = 0.5f;
            stats2.attackSpeed = 0.7f;
            stats2.heavySpeed = 1.7f;
            stats2.canHitAmount = 7.1f;
        }
    }
}
