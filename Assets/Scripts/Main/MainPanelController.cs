using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickMultiPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickSettingsButton()
    {
        
    }
}
