using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetPanel : MonoBehaviour
{
    Renderer gunRanderer;
    public Dropdown dropColor;
    public Slider sliderHP;
    public Toggle lightStar;
    public Toggle open, riverCrab, close;   
    private void Start()
    {
        //获取主角的渲染组件
        gunRanderer = GameObject.FindWithTag("Player").GetComponentInChildren<Renderer>();
        //下拉菜单添加改颜色事件
        dropColor.onValueChanged.AddListener(SwitchColor);
        //滑动条添加改音量事件
        sliderHP.onValueChanged.AddListener((v) => FindObjectOfType<AudioSource>().volume = v);
        //切换灯光
        lightStar.onValueChanged.AddListener(FindObjectOfType<Light>().gameObject.SetActive);

        //切换特效模式
        open.onValueChanged.AddListener((b) =>
        {
            if (b)
                SwitchBloodEffect((effect) => effect.startColor = Color.red);
        });
        riverCrab.onValueChanged.AddListener((b) =>
        {
            if (b)
                SwitchBloodEffect((effect) => effect.startColor = Color.green);
        });
        close.onValueChanged.AddListener((b) =>
        {
            if (b)
                SwitchBloodEffect((effect) =>
                {
                    effect.Stop();
                    effect.playOnAwake = false;
                });
            else
                SwitchBloodEffect((effect) =>
                {
                    effect.Play();
                    effect.playOnAwake = true;
                });
        });
    }

    private void SwitchColor(int value) //改变颜色 
    {
        switch (value)
        {
            case 0:
                gunRanderer.material.color = Color.red;
                break;
            case 1:
                gunRanderer.material.color = Color.blue;
                break;
            case 2:
                gunRanderer.material.color = Color.green;
                break;
            case 3:
                gunRanderer.material.color = Color.yellow;
                break;
        }
    }
    //设置特效(场景中所有特效和预制体)
    private void SwitchBloodEffect(UnityAction<ParticleSystem> setEffect)
    {
        ParticleSystem[] effects = FindObjectsOfType<ParticleSystem>();
        foreach (var item in effects)
        {
            setEffect(item);
        }
        setEffect(Resources.Load<ParticleSystem>("Prefabs/Effect/Blood"));
    }
}
