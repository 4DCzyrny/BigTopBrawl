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
    public Slider p1slider;
    public Slider p2slider;
    public int timerInt;
    public string timerstring;
    void Start()
    {
        timerstring = vdet.timer.ToString();
        p1slider.maxValue = stats.maxHealth;
        p2slider.maxValue = stats2.maxHealth;
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
