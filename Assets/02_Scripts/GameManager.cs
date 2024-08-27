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

    public string[] scenesToLoad;  // 로드할 씬들의 이름 목록
    private int currentSceneIndex = 0;  // 현재 로드 중인 씬의 인덱스

    private void Start()
    {
        // 씬 목록 초기화
        scenesToLoad = new string[] { "Scene_Title", "Scene_Lobby" };
    }

    // 다음 씬 로드 요청
    public void LoadSceneCall()
    {
        //화면 암전 시작 (페이드 아웃)
        UIManager.instance.ScreenFade(1);
    }

    // 암전 완료 후 호출되는 콜백 함수
    public void FadeCallback()
    {
        // 다음 씬 로드 코루틴 시작
        StartCoroutine(LoadNextScene());
    }

    // 로드 씬 비동기 실행
    private IEnumerator LoadNextScene()
    {
        if (currentSceneIndex < scenesToLoad.Length)
        {
            currentSceneIndex++;  // 다음 씬 인덱스로 증가
            string sceneName = scenesToLoad[currentSceneIndex]; // 현재 씬 이름 가져오기
            

            Debug.Log("게임매니저 - 로드씬 실행 됨: " + sceneName);

            // 비동기적으로 씬 로딩
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            Debug.Log("비동기 씬 로딩 시작: " + sceneName);

            // 씬 로딩이 완료될 때까지 대기
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            Debug.Log("비동기 씬 로딩 완료: " + sceneName);

            // 씬 로딩 후, 추가적인 설정 예시
            if (sceneName == "Scene_Lobby")
            {
                // 로비로 가는 경우의 처리
                // AudioManager.instance.PlayBgm(AudioManager.BGM.BGM_Lobby);
            }
            else
            {
                // 다른 씬에 들어가는 경우의 처리
                // 예: 타이머 활성화, UI 설정 등
            }

            // 화면 암전 해제 (페이드 아웃)
            UIManager.instance.ScreenFade(0);
        }
        else
        {
            Debug.LogWarning("현재가 마지막 씬입니다.");
        }
    }

    // 게임 종료
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

}