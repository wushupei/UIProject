using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Slider hpSlider;
    Character chara;
    private void Start()
    {
        chara = FindObjectOfType<Character>();
        hpSlider.maxValue = chara.hp;
    }
    private void Update()
    {
        hpSlider.value = chara.hp;
    }
}
