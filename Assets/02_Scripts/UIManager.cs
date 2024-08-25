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
        // 이미 인스턴스가 존재하면서 이게 아니면 파괴 반환
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


    //타이틀 스크린
    #region TitleScreen 
    public void OnClickedTitleAccept() // title accept 누르면 
    {
        UIClickSound();
        // 씬 전환 
        Debug.Log("씬전환 ");

    }

    #endregion


}