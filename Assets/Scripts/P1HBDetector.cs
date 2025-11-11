using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1HBDetector : MonoBehaviour
{
    public PlayerOneStats playerStats;
    public PlayerOneManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTwoManager enemy = collision.GetComponent<PlayerTwoManager>();
        if(enemy != null)
        {
            if (manager.P1AttackType == 1)
            {
                float damage = playerStats.lightDmg;
                enemy.TakeDamage((int)damage);
            }
            else if(manager.P1AttackType == 2)
            {
                float damage = playerStats.heavyDmg;
                enemy.TakeDamage(damage);
            }
        }
    }
}
