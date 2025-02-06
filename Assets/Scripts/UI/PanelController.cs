using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOT Ween

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    [SerializeField] private RectTransform panelRectTransform;      // 팝업창
    private CanvasGroup backgroundCanvasGroup;                      // 뒤에 배경
    
    public delegate void PanelControllerHideDelegate(); // 창이 닫히고 나면 넘어갈 수 있게 델리게이트를 선언
    
    private void Awake()
    {
        backgroundCanvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Panel 표시 함수
    /// </summary>
    public void Show()
    {
        backgroundCanvasGroup.alpha = 0;
        panelRectTransform.localScale = Vector3.zero;
        
        backgroundCanvasGroup.DOFade(1, 0.2f).SetEase(Ease.Linear);
        panelRectTransform.DOScale(1, 0.2f).SetEase(Ease.InOutBack);
    }

    /// <summary>
    /// Panel 숨기기 함수
    /// </summary>
    public void Hide(PanelControllerHideDelegate hideDelegate = null)
    {
        backgroundCanvasGroup.alpha = 1;
        panelRectTransform.localScale = Vector3.one;
        
        backgroundCanvasGroup.DOFade(0, 0.2f);
        panelRectTransform.DOScale(0, 0.2f).OnComplete(() =>
        {
            hideDelegate?.Invoke();
            Destroy(gameObject);
        });
        
    }
}
