using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using DG.Tweening;
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
    public Image fadeImg; // ���� ȭ�� 



    private void Start()
    {

    }


    // ȭ�� ����
    public void ScreenFade(int set, string sceneName)
    {
        /* ��Ʈ�� ����ϴ� fade 
        var sequence = DOTween.Sequence();

        if (set == 1)
        {
            // ���� 
            sequence.Append(fadeImg.DOFade(1, fadeDuration));

            sequence.AppendCallback(() => {
                //Insert your logic here.
                GameManager.Instance.FadeCallback(sceneName);
            });
        }
        else
        {
            // ���� ���� 
            sequence.Append(fadeImg.DOFade(0, fadeDuration));
        }

        sequence.Play();
        */

    }

}