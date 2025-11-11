using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2HBDetector : MonoBehaviour
{
    public PlayerTwoStats playerStats;
    public PlayerTwoManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerOneManager enemy = collision.GetComponent<PlayerOneManager>();
        if(enemy != null)
        {
            if (manager.P2AttackType == 1)
            {
                float damage = playerStats.lightDmg;
                enemy.TakeDamage(damage);
            }
            else if(manager.P2AttackType == 2)
            {
                float damage = playerStats.heavyDmg;
                enemy.TakeDamage(damage);
            }
        }
    }
}
