using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    public Slider loadSlider;
    public GameObject gamePanel;
    void OnEnable()
    {
        loadSlider.value = 0;
    }
    void Update()
    {
        if (loadSlider.value < 1)
            loadSlider.value += Time.deltaTime * 0.5f;
        else
        {
            gamePanel.SetActive(true);
            gameObject.SetActive(false);
            FindObjectOfType<Controller>().enabled = true;
        }
    }
}
