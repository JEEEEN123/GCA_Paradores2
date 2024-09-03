using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollower : MonoBehaviour
{
    private Transform playerCamera;  // 카메라의 Transform

    public float distanceFromCamera = 2.0f;  // 카메라로부터의 거리
    public float lerpSpeed = 5.0f;  // 패널이 이동하는 속도

    public Transform fadeImgTransform; // FadeImg의 Transform
    public Transform popupPanelTransform; // PopupPanel의 Transform

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

        fadeImgTransform = transform.GetChild(0);
        popupPanelTransform = transform.GetChild(1);    
    }

    void Update()
    {
        if (playerCamera != null)
        {
            // FadeImg와 Canvas_world 즉각 이동
            Vector3 targetPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;
            fadeImgTransform.position = targetPosition;
            transform.position = targetPosition;

            // FadeImg는 즉각적으로 카메라 따라가게 설정
            fadeImgTransform.LookAt(playerCamera);
            fadeImgTransform.Rotate(0, 180, 0);  // 패널이 뒤집히지 않도록 180도 회전

            // PopupPanel의 부드러운 이동
            Vector3 popupTargetPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;
            popupPanelTransform.position = Vector3.Lerp(popupPanelTransform.position, popupTargetPosition, Time.deltaTime * lerpSpeed);
            popupPanelTransform.LookAt(playerCamera);
            popupPanelTransform.Rotate(0, 180, 0);  // 패널이 뒤집히지 않도록 180도 회전
        }
    }
}
