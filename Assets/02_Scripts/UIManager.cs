using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
//using UnityEngine.SceneManagement; // 씬 매니지먼트 

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

    [Header("Fade")]

    [SerializeField]
    private float fadeDuration; // 암전 시간 
    private Image fadeImg; // 암전 화면 

    [Header("Pop up")]
    private GameObject popupPanel;
    private Text titleText;
    private Text contentText;



    private void Start()
    {
        InitUI();
    }

    public void InitUI()
    {
        fadeImg = GameObject.FindWithTag("VRUIBackground").transform.GetChild(0).GetComponent<Image>();
        popupPanel = GameObject.FindWithTag("VRUIBackground").transform.GetChild(1).gameObject;
        titleText = popupPanel.transform.GetChild(0).GetComponent<Text>();
        contentText = popupPanel.transform.GetChild(1).GetComponent<Text>();
    }

    // 화면 암전
    public void ScreenFade(int set)
    {
        // 닷트윈 사용하는 fade 
        var sequence = DOTween.Sequence();

        if (set == 1)
        {
            // 암전 
            sequence.Append(fadeImg.DOFade(1, fadeDuration));

            sequence.AppendCallback(() => {
                //Insert your logic here.
                GameManager.Instance.FadeCallback();
            });
        }
        else
        {
            // 암전 해제 
            sequence.Append(fadeImg.DOFade(0, fadeDuration));
        }

        sequence.Play();

    }

    // popup 창 띄우기
    public void ShowPopup(string newTitleText, string newContextText)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            Debug.Log("팝업 띄우기");

            titleText.text = newTitleText;
            contentText.text = newContextText;
        }
        else
        {
            Debug.Log("팝업 패널을 찾을 수 없음 ");

        }
    }

    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
            Debug.Log("팝업 끄기");


        }
        else
        {
            Debug.Log("팝업 패널을 찾을 수 없음 ");

        }
    }
}