using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;


public class TitleControl : MonoBehaviour
{
    // title image 
    private Image pressImage;

    // A 버튼 입력을 참조하는 InputActionReference
    public InputActionReference PressA;

    private void Start()
    {
        // image 
        pressImage = GetComponent<Image>();

        // A 버튼이 눌렸을 때의 콜백 함수 연결
        PressA.action.performed += OnPressA;

        // start blicking 
        StartCoroutine(Blink());
    }


    // A 버튼이 눌렸을 때 실행되는 메서드
    private void OnPressA(InputAction.CallbackContext context)
    {
        Debug.Log("A 버튼이 눌렸습니다!");

        // A 버튼이 눌렸을 때 화면 전환 등의 추가 작업을 여기에 추가

        GameManager.Instance.LoadSceneCall();
    }

    // 어두워지고 밝아지는 함수
    private IEnumerator Blink()
    {
        while (true)
        {
            // 페이드 아웃 (어두워짐)
            pressImage.DOFade(0, 1.0f);
            yield return new WaitForSeconds(1.0f); // 0.5초 동안 대기

            // 페이드 인 (밝아짐)
            pressImage.DOFade(1, 1.0f);
            yield return new WaitForSeconds(1.5f); // 0.5초 동안 대기
        }
    }

    // 객체가 파괴되거나 씬이 변경될 때 호출되는 메서드
    private void OnDestroy()
    {
        // 메모리 누수를 방지하기 위해 콜백 함수 해제
        PressA.action.performed -= OnPressA;
    }
}
