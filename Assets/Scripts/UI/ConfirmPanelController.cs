using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ConfirmPanelController : PanelController
{

    [SerializeField] private TMP_Text messageText;
    
    public delegate void OnConfirmButtonClicked();
    private OnConfirmButtonClicked onConfirmButtonClicked;

    // 오버라이드
    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked)
    {
        messageText.text = message;
        this.onConfirmButtonClicked = onConfirmButtonClicked;
        base.Show(); // base(부모) 
    }

    /// <summary>
    /// Confirm 버튼 클릭시 호출되는 함수
    /// </summary>
    public void OnClickConfirmButton()
    {
        Hide(() =>
        {
            onConfirmButtonClicked?.Invoke();
        });
    }

    
    /// <summary>
    /// X 버틀 클릭시 호출되는 함수
    /// </summary>
    public void OnClickCloseButton()
    {
        Hide();
    }
}
