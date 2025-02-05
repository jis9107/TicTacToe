using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject playerAObject;
    [SerializeField] private GameObject playerBObject;
    [SerializeField] private GameObject vsText;
    [SerializeField] private Button gameOverButton;

    private Outline outlineA;
    private Outline outlineB;

    void Awake()
    {
        outlineA = playerAObject.GetComponentInChildren<Outline>();
        outlineB = playerBObject.GetComponentInChildren<Outline>();
    }
    
    public enum GameUIMode
    {
        Init,
        TurnA,
        TurnB,
        GameOver
    }

    public void SetUIMode(GameUIMode mode)
    {
        switch (mode)
        {
            case GameUIMode.Init:
                SetUIInit();
                break;
            
            case GameUIMode.TurnA:
                SetTurnA();
                break;
            
            case GameUIMode.TurnB:
                SetTurnB();
                break;
            
            case GameUIMode.GameOver:
                GameOver();
                break;
        }
    }

    void SetUIInit()
    {
        playerAObject.SetActive(true);
        playerBObject.SetActive(true);
        vsText.SetActive(true);
        gameOverButton.gameObject.SetActive(false);
    }
    
    void SetTurnA()
    {
        outlineA.enabled = true;
        outlineB.enabled = false;
    }

    void SetTurnB()
    {
        outlineA.enabled = false;
        outlineB.enabled = true;
    }

    void GameOver()
    {
        playerAObject.SetActive(false);
        playerBObject.SetActive(false);
        vsText.SetActive(false);
        gameOverButton.gameObject.SetActive(true);
        
    }
    
    
    public void OnClickGameOverButton()
    {
        
    }
}
