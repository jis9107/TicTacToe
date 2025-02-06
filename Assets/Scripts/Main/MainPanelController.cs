using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayButton()
    {
        GameManager.Instance.ChangeToGameScene(GameManager.GameType.SinglePlay);
    }

    public void OnClickMultiPlayButton()
    {
        GameManager.Instance.ChangeToGameScene(GameManager.GameType.MultiPlay);
    }

    public void OnClickSettingsButton()
    {
        GameManager.Instance.OpenSettingsPanel();
    }
}
