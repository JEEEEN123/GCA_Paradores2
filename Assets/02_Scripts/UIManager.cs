using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    #region SingleTon Pattern
    public static UIManager instance;  // Singleton instance
    void Awake() // SingleTon
    {
        // �̹� �ν��Ͻ��� �����ϸ鼭 �̰� �ƴϸ� �ı� ��ȯ
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        // Set the instance to this object and make sure it persists between scene loads
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [Header("TitleScreen")]
    public GameObject titleInfoPanel;

    //[Header("LobbyScreen")]
    //public GameObject LobbyInfoPanel;


    public void UIClickSound()
    {
        //AudioManager.Instance.PlaySfx(AudioManager.SFX.SFX_UI_ClickSound);
    }


    //Ÿ��Ʋ ��ũ��
    #region TitleScreen 
    public void OnClickedTitleAccept() // title accept ������ 
    {
        UIClickSound();
        // �� ��ȯ 
        Debug.Log("����ȯ ");

    }

    #endregion


}