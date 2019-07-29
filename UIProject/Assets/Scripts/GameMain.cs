using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    void Start()
    {
        transform.SetSiblingIndex(0);
        InitEffect();
    }
    private void InitEffect() //初始化特效
    {
        //加载特效资源,初始为红色
        ParticleSystem effect = Resources.Load<ParticleSystem>("Prefabs/Effect/Blood");
        effect.startColor = Color.red;
        effect.playOnAwake = true;
    }
}
