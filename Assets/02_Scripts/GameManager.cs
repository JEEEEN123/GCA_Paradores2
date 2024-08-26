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


    // 씬 로드 요청
    public void LoadSceneCall(string sceneName)
    {
        //화면 암전 시작
        UIManager.instance.ScreenFade(1, sceneName);

    }

    // 암전 콜백 
    public void FadeCallback(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName)); //비동기이므로 코루틴으로 호출 
    }

    // 로드 씬 비동기 실행 
    public IEnumerator LoadScene(string sceneName)
    {
        Debug.Log("게임매니저 - 로드씬 실행 됨  ");

        // 비동기적으로 씬 로딩
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);


        Debug.Log("비동기 씬 로딩 시작 ");

        // 씬 로딩이 완료될 때까지 대기
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("비동기 씬 로딩 됨  ");


        // 로비로 가는 경우
        if (sceneName == "Stage0")
        {
            /*
            if (playerTimer != null)
            {
                playerTimer.enabled = false; // PlayerTimer 비활성화
            }
            */

            // UIManager.instance.OnClickBattleButton();
            // UIManager.instance.pickUpScreen.SetActive(true);
            // UIManager.instance.selectedStageName = preStageName;

            // 브금 틀기 
            // AudioManager.instance.PlayBgm(AudioManager.BGM.BGM_Lobby);
        }
        else
        {
            /*
            // 게임 맵 들어가는 경우 
            if (playerTimer != null)
            {
                playerTimer.enabled = true; // PlayerTimer 활성화
            }
            */

        }

        //화면 암전 끄기 
        UIManager.instance.ScreenFade(0, sceneName);

    }

    //게임 종료
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

}