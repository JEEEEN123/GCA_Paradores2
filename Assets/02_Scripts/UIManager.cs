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
    private Text contentText;

    // �� ������ ���� �ȳ����� �����ϴ� ���� ����Ʈ
    private List<List<string>> scenePopupMessages = new List<List<string>>()
    {
        // Scene 0
        new List<string>() { "Senor(Senora), \n\n ȣ�� �Ķ󵵸��� ���� ���� �������� ȯ���մϴ�. \n\n �̰��� �ϻ󿡼� ���, \n ����� �ð��� ���� �� �ִ� ���Դϴ�.",
            "������ ����� ���� Ư���� ���� ��Ű���� �غ��߽��ϴ�. \n\n �ڿ� �ӿ��� ������ ã��, �������� �� �ִ� �ð��� ��������.",
            "������ ���� ���ð�, \n������ �غ� �ǽø� \n �ٴ��� ��¦�̴� ǥ�÷� �̵����ּ���." },   
        
        // Scene 1
        new List<string>() { "�̰��� �ڿ��� �Բ��� �� �ִ� �߿������Դϴ�. \n�������� �� ���� ü���� �غ�Ǿ� �ֽ��ϴ�.",
            "ȣ�������� �� Ÿ��, ����� �м��� ���� ������, \n�׸��� �׳� Ÿ��. ��� õõ�� ������ ���ø� ���ڽ��ϴ�." },

        // Scene 2
        new List<string>() { "����, ȣ�������� �踦 Ÿ�� �����Ӱ� ��ܺ�����.\n �븦 ������ ȣ���� ������� �������ñ� �ٶ��ϴ�.",
            "���� �¿�� ���� �踦 ������ �� �ֽ��ϴ�.\n �븦 ������ ȣ���� ������� �������ñ� �ٶ��ϴ�.",
            "���� �������� �м��븦 ���� �븦 �������." },  

        // Scene 3
        new List<string>() { "�̰��� �Ķ󵵸��� ����� �м��Դϴ�.\n �м��� �߾��� ���� ������ ����������.",
            "����� ���� �̼� ���� ����,\n Ư���� ���� �Ͼ���� �𸨴ϴ�." },  

        // Scene 4
        new List<string>() { "�������� ü���� ������ �ð��� �� �귯 ���� �Ǿ�����.",
            "���������� ���� ȣ���� �ڶ��� �׳׸� Ÿ��, \n�� ������� ������ ����������. \n�� ������ ����� �޽��� �Ǳ⸦ �ٶ��ϴ�.",
            "��Ʈ�ѷ��� ������ �׳� ��ó�� �ٰ�������." },  

         // Scene 5
        new List<string>() { "��� ü���� ��ġ�� �κ�� ���ƿ��̽��ϴ�. \n���� �������� �κ� �� �ٸ� �Ƹ��ٿ��� �����ϴ±���.",
            "���� �Ϸ� ����� �Բ����ּż� ����帳�ϴ�. \n�� Ư���� �ð��� ��ſ��� ��ȭ�� �Ƚ��� �־��⸦ �ٶ��ϴ�.",
            "�������� �ٽ� �湮���ֽñ� �ٶ�� Buenas noches, ��ȭ�ο� �� �Ǽ���." }, 

         // Scene 6
        new List<string>() { "Scene 6: Thank you for experiencing.", "See you again!" }  
    };

    private int popupIndex = 0;


    private void Start()
    {
        InitUI();
    }

    public void InitUI()
    {
        int sceneIndex = GameManager.Instance.currentSceneIndex;

        fadeImg = GameObject.FindWithTag("VRUIBackground").transform.GetChild(0).GetComponent<Image>();
        popupPanel = GameObject.FindWithTag("VRUIBackground").transform.GetChild(1).gameObject;
        if(popupPanel != null )
        {
            contentText = popupPanel.transform.GetChild(0).GetComponent<Text>();
        }
        else
        {
            Debug.Log("popup �г� ��ã��");
        }

        ShowFirstPopup();

    }

    // �˾��� ���� ���� �޼���
    public void ShowFirstPopup()
    {
        // show popup UI for current scene 
        if (popupIndex < scenePopupMessages[GameManager.Instance.currentSceneIndex].Count)
        {
            // ��: UIManager�� ���� �ؽ�Ʈ�� �˾��� ǥ��
            ShowPopup(scenePopupMessages[GameManager.Instance.currentSceneIndex][popupIndex]);
            Debug.Log(popupIndex);
            popupIndex++;
        }
        else
        {
            // ������ ��� �����־��ٸ� ������
            ClosePopup();

            // init this 
            popupIndex = 0;

        }
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
    public void ShowPopup(string newContextText)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            Debug.Log("�˾� ����");

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