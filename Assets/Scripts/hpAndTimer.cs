using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class hpAndTimer : MonoBehaviour
{
    public TextMeshProUGUI timerEpic;
    public victoryDetector vdet;
    public PlayerOneStats stats;
    public PlayerTwoStats stats2;
    public Image p1render;
    public Image p2render;
    public Sprite char1P1;
    public Sprite char1P2;
    public Sprite char2P1;
    public Sprite char2P2;
    public Sprite char3P1;
    public Sprite char3P2;
    public Slider p1slider;
    public Slider p2slider;
    public int timerInt;
    public string timerstring;
    void Start()
    {
        timerstring = vdet.timer.ToString();
        p1slider.maxValue = stats.maxHealth;
        p2slider.maxValue = stats2.maxHealth;
        if (stats.id == 1)
        {
            p1render.sprite = char1P1;
        }
        else if (stats.id == 2)
        {
            p1render.sprite = char2P1;
        }
        else if (stats.id == 3)
        {
            p1render.sprite = char3P1;
        }
        if (stats2.id == 1)
        {
            p2render.sprite = char1P2;
        }
        else if (stats2.id == 2)
        {
            p2render.sprite = char2P2;
        }
        else if (stats2.id == 3)
        {
            p2render.sprite = char3P2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerInt = (int)vdet.timer;
        timerstring = timerInt.ToString();
        timerEpic.text = timerstring;
        p1slider.value = stats.health;
        p2slider.value = stats2.health;
    }
}
