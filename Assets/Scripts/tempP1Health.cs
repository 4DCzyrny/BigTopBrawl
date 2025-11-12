using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tempP1Health : MonoBehaviour
{
    public PlayerOneStats stats;
    public PlayerOneManager manager;
    public PlayerTwoManager manager2;
    public PlayerTwoStats stats2;
    public TextMeshProUGUI P1stunText;
    public TextMeshProUGUI P2stunText;
    public TextMeshProUGUI p1block;
    public TextMeshProUGUI p2block;
    public float curHP;
    public float curHP2;
    void Update()
    {
        curHP = stats.health;
        curHP2 = stats2.health;
        if (!manager.P1CanAttack && !manager.isBlocking)
        {
            P1stunText.text = "STUNNED!";
        }
        else
        {
            P1stunText.text = "Not";
        }

        if (!manager2.P2CanAttack && !manager2.isBlocking)
        {
            P2stunText.text = "STUNNED!";
        }
        else
        {
            P2stunText.text = "Not";
        }

        if (manager.isBlocking)
        {
            p1block.text = "Blocking";
        }
        else
        {
            p1block.text = "Not";
        }

        if (manager2.isBlocking)
        {
            p2block.text = "Blocking";
        }
        else
        {
            p2block.text = "Not";
        }
    }
}
