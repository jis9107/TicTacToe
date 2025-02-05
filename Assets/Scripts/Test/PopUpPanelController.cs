using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting; // DOT Ween 사용 시 선언

[RequireComponent(typeof(CanvasGroup))]
public class PopUpPanelController : Singleton<PopUpPanelController>
{
    [SerializeField] private Text contentText;
    [SerializeField] private Text confirmButtonText;
    [SerializeField] private Button confitmButton;
    
    // DOT Ween 사용
    [SerializeField] private RectTransform panelRectTransform;

    private CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
        Hide(false);
    }


    public void Show(string content, string confirmButtonText, bool animation, Action confirmAction)
    {
        gameObject.SetActive(true);
        
        // 애니메이션을 위한 초기화
        canvasGroup.alpha = 0;
        panelRectTransform.localScale = Vector3.zero;

        if (animation)
        {
            panelRectTransform.DOScale(Vector3.one, 0.2f);
            canvasGroup.DOFade(1, 0.2f).SetEase(Ease.OutBack);
            
        }
        else
        {
            panelRectTransform.localScale = Vector3.one;
            canvasGroup.alpha = 1;
        }
        
        contentText.text = content;
        this.confirmButtonText.text = confirmButtonText;
        confitmButton.onClick.AddListener(() =>
        {
            confirmAction();
            Hide(true);
        });
    }

    public void Hide(bool animation)
    {
        if (animation)
        {
            panelRectTransform.DOScale(0f, 1f).OnComplete(() =>
            {
                contentText.text = "";
                confirmButtonText.text = "";    
                confitmButton.onClick.RemoveAllListeners();
        
                gameObject.SetActive(false);
            });
            canvasGroup.DOFade(0, 1f).SetEase(Ease.InBack);
        }
        else
        {
            contentText.text = "";
            confirmButtonText.text = "";    
            confitmButton.onClick.RemoveAllListeners();
        
            gameObject.SetActive(false);
        }

    }
}
