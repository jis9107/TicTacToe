using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PanelController : MonoBehaviour
{
    public bool isShow { get; private set; }

    public delegate void OnHide();
    private OnHide onHideDelegate;
    
    
    private RectTransform rectTransform;
    private Vector2 hideAnchorPosition;
    
    
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        hideAnchorPosition = rectTransform.anchoredPosition;
        isShow = false;
    }

    /// <summary>
    /// Panel 표시 함수
    /// </summary>
    public void Show(OnHide onHideDelegate)
    {
        this.onHideDelegate = onHideDelegate;
        rectTransform.anchoredPosition = Vector2.zero;
        isShow = true;
    }

    /// <summary>
    /// Panel 숨기기 함수
    /// </summary>
    public void Hide()
    {
        rectTransform.anchoredPosition = hideAnchorPosition;
        isShow = false;
        onHideDelegate?.Invoke();
    }       
}
