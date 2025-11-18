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
    public TextMeshProUGUI p2desc;
    public TextMeshProUGUI p1desc;
    public Image p1img;
    public Image p2img;
    public Sprite venester;
    public Sprite sasha;
    public Sprite pedro;
    public Sprite na;


    void Start()
    {
        stats.id = 0;
        stats2.id = 0;
        p1text.text = "Player 1: Choose Your Character";
        p2text.text = "Player 1: Choose Your Character";
        p1img.sprite = na;
        p2img.sprite = na;
        p1desc.text = "n/a";
        p2desc.text = "n/a";
    }
    public void p1Char1()
    {
        stats.id = 1;
        p1text.text = "Player 1: Venester";
        p1img.sprite = venester;
        p1desc.text = "The All Rounder";
    }
    public void p1Char2()
    {
        stats.id = 2;
        p1text.text = "Player 1: Sasha";
        p1img.sprite = sasha;
        p1desc.text = "The Glass Cannon";
    }
    public void p1Char3()
    {
        stats.id = 3;
        p1text.text = "Player 1: Pedro";
        p1img.sprite = pedro;
        p1desc.text = "The Rushdown";
    }
    public void p1Char4()
    {
        stats.id = 4;
        p1text.text = "Player 1: Char4";
        p1img.sprite = na;
        p1desc.text = "n/a";
    }
    public void p1Char5()
    {
        stats.id = 5;
        p1text.text = "Player 1: Char5";
        p1img.sprite = na;
        p1desc.text = "n/a";
    }
    public void p2Char1()
    {
        stats2.id = 1;
        p2text.text = "Player 2: Venester";
        p2img.sprite = venester;
        p2desc.text = "The All Rounder";
    }
    public void p2Char2()
    {
        stats2.id = 2;
        p2text.text = "Player 2: Sasha";
        p2img.sprite = sasha;
        p2desc.text = "The Glass Cannon";
    }
    public void p2Char3()
    {
        stats2.id = 3;
        p2text.text = "Player 2: Pedro";
        p2img.sprite = pedro;
        p2desc.text = "The Rushdown";
    }
    public void p2Char4()
    {
        stats2.id = 4;
        p2text.text = "Player 2: Char4";
        p2img.sprite = na;
        p2desc.text = "n/a";
    }
    public void p2Char5()
    {
        stats2.id = 5;
        p2text.text = "Player 2: Char5";
        p2img.sprite = na;
        p2desc.text = "n/a";
    }
}
