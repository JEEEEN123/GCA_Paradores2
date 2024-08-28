using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SingleTon Pattern
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set this as the instance and ensure it persists across scenes
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public string[] scenesToLoad;  // �ε��� ������ �̸� ���
    private int currentSceneIndex = 0;  // ���� �ε� ���� ���� �ε���

    private void Start()
    {
        // �� ��� �ʱ�ȭ
        scenesToLoad = new string[] { "Scene_Swing", "Scene_Lobby" };
        //scenesToLoad = new string[] { "Scene_Title", "Scene_Lobby" };
    }

    // ���� �� �ε� ��û
    public void LoadSceneCall()
    {
        //ȭ�� ���� ���� (���̵� �ƿ�)
        UIManager.instance.ScreenFade(1);
    }

    // ���� �Ϸ� �� ȣ��Ǵ� �ݹ� �Լ�
    public void FadeCallback()
    {
        // ���� �� �ε� �ڷ�ƾ ����
        StartCoroutine(LoadNextScene());
    }

    // �ε� �� �񵿱� ����
    private IEnumerator LoadNextScene()
    {
        if (currentSceneIndex < scenesToLoad.Length)
        {
            currentSceneIndex++;  // ���� �� �ε����� ����
            string sceneName = scenesToLoad[currentSceneIndex]; // ���� �� �̸� ��������
            

            Debug.Log("���ӸŴ��� - �ε�� ���� ��: " + sceneName);

            // �񵿱������� �� �ε�
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            Debug.Log("�񵿱� �� �ε� ����: " + sceneName);

            // �� �ε��� �Ϸ�� ������ ���
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            Debug.Log("�񵿱� �� �ε� �Ϸ�: " + sceneName);

            // �� �ε� ��, �߰����� ���� ����
            if (sceneName == "Scene_Lobby")
            {
                // �κ�� ���� ����� ó��
                // AudioManager.instance.PlayBgm(AudioManager.BGM.BGM_Lobby);
            }
            else
            {
                // �ٸ� ���� ���� ����� ó��
                // ��: Ÿ�̸� Ȱ��ȭ, UI ���� ��
            }

            // ȭ�� ���� ���� (���̵� �ƿ�)
            UIManager.instance.ScreenFade(0);
        }
        else
        {
            Debug.LogWarning("���簡 ������ ���Դϴ�.");
        }
    }

    // ���� ����
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

}