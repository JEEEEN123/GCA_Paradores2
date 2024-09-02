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
    [SerializeField]
    private Image fadeImg; // ���� ȭ�� 

    [Header("Pop up")]
    [SerializeField]
    private GameObject popupPanel;
    private Text contentText;
    private bool isStageEnd;

    // 각 씬마다 여러 안내문을 저장하는 이중 리스트
    private List<List<string>> scenePopupMessages = new List<List<string>>()
    {
        // Scene 0 title
        new List<string>() { "Senor(Senora), \n\n 호텔 파라도르에 오신 것을 진심으로 환영합니다. \n\n 이곳은 일상에서 벗어나, \n 평온한 시간을 보낼 수 있는 곳입니다.",
            "오늘은 당신을 위해 특별한 힐링 패키지를 준비했습니다. \n\n 자연 속에서 여유를 찾고, 재충전할 수 있는 시간을 가지세요.",
            "차분히 숨을 고르시고, \n시작할 준비가 되시면 \n 바닥의 반짝이는 표시로 이동해주세요." },   

        // Scene 1 Lobby
        new List<string>() { "Senor(Senora), \n\n 호텔 파라도르에 오신 것을 진심으로 환영합니다. \n\n 이곳은 일상에서 벗어나, \n 평온한 시간을 보낼 수 있는 곳입니다.",
            "오늘은 당신을 위해 특별한 힐링 패키지를 준비했습니다. \n\n 자연 속에서 여유를 찾고, 재충전할 수 있는 시간을 가지세요.",
            "차분히 숨을 고르시고, \n시작할 준비가 되시면 \n 바닥의 반짝이는 표시로 이동해주세요." },   
        
        /*
        // Scene 2 garden
        new List<string>() { "이곳은 자연과 함께할 수 있는 야외정원입니다. \n정원에는 세 가지 체험이 준비되어 있습니다.",
            "호숫가에서 배 타기, 행운의 분수에 동전 던지기, \n그리고 그네 타기. 모두 천천히 경험해 보시면 좋겠습니다." },
        */

        // Scene 2
        new List<string>() { "먼저, 호숫가에서 배를 타고 여유롭게 즐겨보세요.\n 노를 저으며 호수의 고요함을 느껴보시길 바랍니다.",
            "팔을 좌우로 흔들어 배를 조정할 수 있습니다.\n 노를 저으며 호수의 고요함을 느껴보시길 바랍니다.",
            "다음 목적지인 분수대를 향해 노를 저어보세요." },  

        // Scene 3
        new List<string>() { "이곳은 파라도르의 행운의 분수입니다.\n 분수의 중앙을 향해 동전을 던져보세요.",
            "행운의 신이 미소 짓는 순간,\n 특별한 일이 일어날지도 모릅니다." },  

        // Scene 4
        new List<string>() { "여러가지 체험을 즐기느라 시간이 꽤 흘러 밤이 되었군요.",
            "마지막으로 저희 호텔의 자랑인 그네를 타며, \n이 고요함을 마음껏 느껴보세요. \n이 순간이 편안한 휴식이 되기를 바랍니다.",
            "컨트롤러를 조정해 그네 근처로 다가가세요." },  

         // Scene 5
        new List<string>() { "모든 체험을 마치고 로비로 돌아오셨습니다. \n밤이 내려앉은 로비가 또 다른 아름다움을 선사하는군요.",
            "오늘 하루 저희와 함께해주셔서 감사드립니다. \n이 특별한 시간이 당신에게 평화와 안식을 주었기를 바랍니다.",
            "언제든지 다시 방문해주시길 바라며 Buenas noches, 평화로운 밤 되세요." }, 

         // Scene 6
        new List<string>() { "Scene 6: Thank you for experiencing.", "See you again!" }
    };


    private int popupIndex = 0;

    // 각 씬마다 여러 안내문을 저장하는 이중 리스트
    private List<List<string>> sceneEndingPopupMessages = new List<List<string>>()
    {
        // Scene 0 title
        new List<string>() { "" },   

        // Scene 1 Lobby
        new List<string>() { "이곳은 자연과 함께할 수 있는 야외정원입니다. \n정원에는 세 가지 체험이 준비되어 있습니다.",
            "호숫가에서 배 타기, 행운의 분수에 동전 던지기, \n그리고 그네 타기. 모두 천천히 경험해 보시면 좋겠습니다." },   

        // Scene 2
        new List<string>() { "." },  

        // Scene 3
        new List<string>() { "Buena suerte! \n 행운의 요정이 나타나 \n 당신에게 특별한 축복을 내립니다.",
            "은총이 당신의 발걸음을 가볍게 하고, \n 모든 길을 환하게 비출 것입니다"},

        // Scene 4
        new List<string>() { " "},  

         // Scene 5
        new List<string>() { "" }, 

         // Scene 6
        new List<string>() { "" }
    };

    private void Start()
    {
        fadeImg = GameObject.FindWithTag("VRUIBackground").transform.Find("FadeImg").GetComponent<Image>();

        // title 씬을 제외하고는 
        if(GameManager.Instance.currentSceneIndex != 0)
        {
            InitUI();
        }
    }

    public void InitUI()
    {
        isStageEnd = false;
        int sceneIndex = GameManager.Instance.currentSceneIndex;

        fadeImg = GameObject.FindWithTag("VRUIBackground").transform.Find("FadeImg").GetComponent<Image>();

        popupPanel = GameObject.FindWithTag("VRUIBackground").transform.GetChild(1).gameObject;

        if(popupPanel != null )
        {
            contentText = popupPanel.transform.GetChild(0).GetComponent<Text>();
        }
        else
        {
            Debug.Log("no popup here");
        }

        // buttons linking 
        AssignButtonEvents();

        ShowFirstPopup();

    }

    void AssignButtonEvents()
    {
        // PopupPanel의 자식들을 탐색하여 버튼을 찾음
        Transform buttonTransform = popupPanel.transform.GetChild(1).GetChild(0); // 1번 자식(Buttons)의 0번 자식(ButtonNext)을 가져옴

        if (buttonTransform != null)
        {
            Button button = buttonTransform.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.RemoveAllListeners(); // 기존 이벤트 리스너 제거
                button.onClick.AddListener(OnButtonNextClicked); // 새 이벤트 리스너 추가
            }
        }
        else
        {
            Debug.LogError("Button not found!");
        }
    }



    void OnButtonNextClicked()
    {
        Debug.Log("Button Next Clicked!");
        // 여기에 버튼 클릭 시 수행할 작업을 추가하세요.
        ShowFirstPopup();

    }

    // �˾��� ���� ���� �޼���
    public void ShowFirstPopup()
    {
        if (!isStageEnd)
        {
            // show popup UI for current scene 
            if (popupIndex < scenePopupMessages[GameManager.Instance.currentSceneIndex].Count)
            {
                // ��: UIManager�� ���� �ؽ�Ʈ�� �˾��� ǥ��
                ShowPopup(scenePopupMessages[GameManager.Instance.currentSceneIndex][popupIndex]);
                Debug.Log("start message");

                popupIndex++;
            }
            else
            {
                // ������ ��� �����־��ٸ� ������
                ClosePopup();

                // init this 
                popupIndex = 0;
                isStageEnd = true;

            }
        }
        else
        {

            // show popup UI for current scene 
            if (popupIndex < sceneEndingPopupMessages[GameManager.Instance.currentSceneIndex].Count)
            {
                // ��: UIManager�� ���� �ؽ�Ʈ�� �˾��� ǥ��
                ShowPopup(sceneEndingPopupMessages[GameManager.Instance.currentSceneIndex][popupIndex]);
                Debug.Log("ending message");
                popupIndex++;
            }
            else
            {
                // ������ ��� �����־��ٸ� ������
                ClosePopup();

                // init this 
                popupIndex = 0;
                isStageEnd = false;

            }


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
            Debug.Log(" show popup ");

            contentText.text = newContextText;
        }
        else
        {
            Debug.Log("no popup here");

        }
    }

    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
            Debug.Log(" close popup");


        }
        else
        {
            Debug.Log("no popup here ");


        }
    }


}