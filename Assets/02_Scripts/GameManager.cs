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

    public string[] scenesToLoad;
    [SerializeField]
    public int currentSceneIndex = 0;  // 현재 씬 넘버 . 0~6 

    private void Start()
    {
        // 로드할 씬 목록 
        scenesToLoad = new string[] { "Scene_Title", "Scene_Lobby", "Scene_boatMove", "Scene_Fountain", "Scene_Swing", "Scene_Ending Night", "Scene_Title" };
    }

    // 씬 전환 호출
    public void LoadSceneCall()
    {
        //ȭ�� ���� ���� (���̵� �ƿ�)
        UIManager.instance.ScreenFade(1);
    }

    // UI fade out call back
    public void FadeCallback()
    {
        // ���� �� �ε� �ڷ�ƾ ����
        StartCoroutine(LoadNextScene());
    }

    // load scene - async
    private IEnumerator LoadNextScene()
    {
        if (currentSceneIndex < scenesToLoad.Length)
        {
            currentSceneIndex++;  // Scene index increase
            string sceneName = scenesToLoad[currentSceneIndex]; // load scene name
            

            // async load  scene
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            Debug.Log("Now Scene: " + sceneName);

            // wait for done
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            Debug.Log("Now Scene: " + sceneName);


            /*
             * if you want to control each Scene, code in here 
             */

            // init this scene 
            UIManager.instance.InitUI();


            // fade out 
            UIManager.instance.ScreenFade(0);
        }
        else
        {
            Debug.Log("No more scenes to load");
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