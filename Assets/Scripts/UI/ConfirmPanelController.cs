using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmPanelController : PanelController
{

    [SerializeField] private TMP_Text messageText;
    
    public delegate void OnConfirmButtonClicked();
    private OnConfirmButtonClicked onConfirmButtonClicked;

    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked, OnHide onHide)
    {
        messageText.text = message;
        this.onConfirmButtonClicked = onConfirmButtonClicked;
        base.Show(onHide); // base(부모) 
    }

    /// <summary>
    /// Confirm 버튼 클릭시 호출되는 함수
    /// </summary>
    public void OnClickConfirmButton()
    {
        onConfirmButtonClicked?.Invoke();
        Hide();
    }

    
    /// <summary>
    /// X 버틀 클릭시 호출되는 함수
    /// </summary>
    public void OnClickCloseButton()
    {
        Hide();
    }
}
