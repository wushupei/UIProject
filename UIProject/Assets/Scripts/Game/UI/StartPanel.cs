using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject loadPanel;
    public InputField inputName;
    public Text errorMsg;
    public Text userName;
    public void SetUserName() //输入结束事件,设置名字
    {
        userName.text = inputName.text;
    }
    public void OpenLoadPanel() //按钮事件,进入加载面板
    {
        if (inputName.text.Length > 0)
        {
            gameObject.SetActive(false);
            loadPanel.SetActive(true);
        }
        else
            errorMsg.gameObject.SetActive(true);
    }
}
