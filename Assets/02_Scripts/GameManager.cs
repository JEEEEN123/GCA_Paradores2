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


    // �� �ε� ��û
    public void LoadSceneCall(string sceneName)
    {
        //ȭ�� ���� ����
        UIManager.instance.ScreenFade(1, sceneName);

    }

    // ���� �ݹ� 
    public void FadeCallback(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName)); //�񵿱��̹Ƿ� �ڷ�ƾ���� ȣ�� 
    }

    // �ε� �� �񵿱� ���� 
    public IEnumerator LoadScene(string sceneName)
    {
        Debug.Log("���ӸŴ��� - �ε�� ���� ��  ");

        // �񵿱������� �� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);


        Debug.Log("�񵿱� �� �ε� ���� ");

        // �� �ε��� �Ϸ�� ������ ���
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("�񵿱� �� �ε� ��  ");


        // �κ�� ���� ���
        if (sceneName == "Stage0")
        {
            /*
            if (playerTimer != null)
            {
                playerTimer.enabled = false; // PlayerTimer ��Ȱ��ȭ
            }
            */

            // UIManager.instance.OnClickBattleButton();
            // UIManager.instance.pickUpScreen.SetActive(true);
            // UIManager.instance.selectedStageName = preStageName;

            // ��� Ʋ�� 
            // AudioManager.instance.PlayBgm(AudioManager.BGM.BGM_Lobby);
        }
        else
        {
            /*
            // ���� �� ���� ��� 
            if (playerTimer != null)
            {
                playerTimer.enabled = true; // PlayerTimer Ȱ��ȭ
            }
            */

        }

        //ȭ�� ���� ���� 
        UIManager.instance.ScreenFade(0, sceneName);

    }

    //���� ����
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

}