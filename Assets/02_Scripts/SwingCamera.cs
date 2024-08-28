using UnityEngine;
using System.Collections;

public class SwingCamera : MonoBehaviour
{
    public float amplitude = 0.5f;  // 스윙의 진폭
    public float frequency = 1.0f;  // 스윙의 주기
    public Vector3 swingDirection = Vector3.forward; // 스윙 방향
    public AudioSource swingSound; // 재생할 음향 효과
    public float swingDuration = 15.0f;  // 스윙이 지속되는 시간 (초 단위)
    public float fadeDuration = 2f; // 페이드아웃 지속 시간

    private bool isSwinging = false; // 스윙 활성화 여부
    private Coroutine swingCoroutine;
    private Vector3 cameraStartPosition;  // 카메라의 초기 위치

    void Start()
    {
        cameraStartPosition = transform.localPosition;
    }

    void Update()
    {
        if (isSwinging)
        {
            // 스윙 효과 적용
            float offset = Mathf.Sin(Time.time * frequency) * amplitude;
            transform.localPosition = cameraStartPosition + swingDirection * offset;
        }
    }

    public void StartSwinging()
    {
        // 스윙 시작
        if (swingCoroutine != null)
        {
            StopCoroutine(swingCoroutine);
        }

        isSwinging = true;
        swingSound.Play(); // 음향 효과 재생
        swingCoroutine = StartCoroutine(SwingForDuration(swingDuration));
    }

    public void StartFadeOut()
    {
        // 페이드아웃 시작 (UI Manager를 통한 씬 로드 호출)
        GameManager.Instance.LoadSceneCall();
    }

    private IEnumerator SwingForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        // 여기서 페이드아웃을 시작할 때 오브젝트를 파괴하고 페이드아웃을 시작함
        DestroyOnFadeOut destroyScript = GetComponent<DestroyOnFadeOut>();
        if (destroyScript != null)
        {
            destroyScript.StartFadeOutAndDestroy(); 
        }
    }

}



