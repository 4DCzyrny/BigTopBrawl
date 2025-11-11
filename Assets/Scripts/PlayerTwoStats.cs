using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "P2Stats", menuName = "P2Stats")]
public class PlayerTwoStats : ScriptableObject
{
    public int id = 1;
    public float lightDmg = 1;
    public float heavyDmg = 1;
    public float health = 3;
    public float maxHealth = 3;
    public float speed = 5f;
    public float jump = 5f;
    public float blockScore = 0.5f;
}
