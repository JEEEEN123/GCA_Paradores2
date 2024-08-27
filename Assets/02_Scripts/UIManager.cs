using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
//using UnityEngine.SceneManagement; // �� �Ŵ�����Ʈ 

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

    [Header("Fade")]

    [SerializeField]
    private float fadeDuration; // ���� �ð� 
    private Image fadeImg; // ���� ȭ�� 

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

    // ȭ�� ����
    public void ScreenFade(int set)
    {
        // ��Ʈ�� ����ϴ� fade 
        var sequence = DOTween.Sequence();

        if (set == 1)
        {
            // ���� 
            sequence.Append(fadeImg.DOFade(1, fadeDuration));

            sequence.AppendCallback(() => {
                //Insert your logic here.
                GameManager.Instance.FadeCallback();
            });
        }
        else
        {
            // ���� ���� 
            sequence.Append(fadeImg.DOFade(0, fadeDuration));
        }

        sequence.Play();

    }

    // popup â ����
    public void ShowPopup(string newTitleText, string newContextText)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            Debug.Log("�˾� ����");

            titleText.text = newTitleText;
            contentText.text = newContextText;
        }
        else
        {
            Debug.Log("�˾� �г��� ã�� �� ���� ");

        }
    }

    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
            Debug.Log("�˾� ����");


        }
        else
        {
            Debug.Log("�˾� �г��� ã�� �� ���� ");

        }
    }
}