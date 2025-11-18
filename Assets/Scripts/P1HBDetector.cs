using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1HBDetector : MonoBehaviour
{
    public PlayerOneStats playerStats;
    public PlayerOneManager manager;
    public int latCtr = 0;
    private Coroutine latReset;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTwoManager enemy = collision.GetComponent<PlayerTwoManager>();
        if(enemy != null)
        {
            if (manager.P1AttackType == 1)
            {
                float damage = playerStats.lightDmg;
                enemy.TakeDamage(damage, latCtr);
                latCtr += 1;
                if (latReset != null)
                {
                    StopCoroutine(latReset);
                }
                latReset = StartCoroutine(LatResets());
            }
            else if(manager.P1AttackType == 2)
            {
                float damage = playerStats.heavyDmg;
                enemy.TakeDamage(damage, latCtr);
                latCtr += 2;
                if (latReset != null)
                {
                    StopCoroutine(latReset);
                }
                latReset = StartCoroutine(LatResets());
            }
        }
    }
    public IEnumerator LatResets()
    {
        yield return new WaitForSeconds(3);
        latCtr = 0;
        yield break;
    }
}
