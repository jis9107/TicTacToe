using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{

    public void Open()
    {
        PopUpPanelController.Instance.Show("Hello", "OK",true, () =>
        {
            Debug.Log("OK버튼 클릭!");
        });
    }
}
