using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollower : MonoBehaviour
{
    private Transform playerCamera;  // 카메라의 Transform

    public float distanceFromCamera = 2.0f;  // 카메라로부터의 거리
    public float lerpSpeed = 5.0f;  // 패널이 이동하는 속도

    // Start is called before the first frame update
    void Start()
    {
        // Main Camera 태그로 카메라 찾기
        GameObject cameraObject = GameObject.FindWithTag("MainCamera");

        if (cameraObject != null)
        {
            playerCamera = cameraObject.transform;
        }
        else
        {
            Debug.LogError("MainCamera를 찾을 수 없습니다. VR 카메라가 제대로 설정되어 있는지 확인하세요.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera != null)
        {
            // 목표 위치 계산 (카메라 앞)
            Vector3 targetPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;

            // 현재 위치에서 목표 위치로 부드럽게 이동
            //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
            transform.position = targetPosition;


            // 패널이 항상 카메라를 바라보게 설정
            transform.LookAt(playerCamera);
            transform.Rotate(0, 180, 0);  // 패널이 뒤집히지 않도록 180도 회전
        }
    }
}
