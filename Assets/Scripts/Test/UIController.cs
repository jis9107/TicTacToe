using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private Text text;
    [SerializeField] private Button button;
    [SerializeField] private GameObject panel;

    void Start()
    {
        ShowPanel("게임을 종료하시겠습니까?");
    }
    
    public void ShowPanel(string textStr)
    {
        panel.SetActive(true);
        text.text = textStr;
        button.onClick.AddListener(() => { panel.SetActive(false); });
    }
}
