using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class charSelect : MonoBehaviour
{
    public PlayerOneStats stats;
    public PlayerTwoStats stats2;
    public TextMeshProUGUI p1text;
    public TextMeshProUGUI p2text;

    void Start()
    {
        stats.id = 0;
        stats2.id = 0;
    }
    public void p1Char1()
    {
        stats.id = 1;
        p1text.text = "Player 1: Venester";
    }
    public void p1Char2()
    {
        stats.id = 2;
        p1text.text = "Player 1: Sasha";
    }
    public void p1Char3()
    {
        stats.id = 3;
        p1text.text = "Player 1: Pedro";
    }
    public void p1Char4()
    {
        stats.id = 4;
        p1text.text = "Player 1: Char4";
    }
    public void p1Char5()
    {
        stats.id = 5;
        p1text.text = "Player 1: Char5";
    }
    public void p2Char1()
    {
        stats2.id = 1;
        p2text.text = "Player 2: Venester";
    }
    public void p2Char2()
    {
        stats2.id = 2;
        p2text.text = "Player 2: Sasha";
    }
    public void p2Char3()
    {
        stats2.id = 3;
        p2text.text = "Player 2: Pedro";
    }
    public void p2Char4()
    {
        stats2.id = 4;
        p2text.text = "Player 2: Char4";

    }
    public void p2Char5()
    {
        stats2.id = 5;
        p2text.text = "Player 2: Char5";
    }
}
