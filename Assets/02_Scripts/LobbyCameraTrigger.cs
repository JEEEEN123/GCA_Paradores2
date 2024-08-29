using UnityEngine;
using System.Collections;

public class LobbyCameraTrigger : MonoBehaviour
{
    public Transform[] waypoints; // 웨이포인트 목록
    public float moveSpeed = 2.0f; // 카메라 이동 속도
    public float rotationSpeed = 2.0f; // 카메라 회전 속도

    private int currentWaypointIndex = 0; // 현재 웨이포인트 인덱스
    private bool isMoving = false; // 카메라가 이동 중인지 여부

    public GameObject playerCamera;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = playerCamera.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1번");
        // 충돌한 오브젝트가 카메라인지 확인
        if (other.CompareTag("MainCamera") && !isMoving)
        {
                  Debug.Log("1번-1");

            other.transform.parent.parent.gameObject.SetActive(false);

            playerCamera.SetActive(true);



            StartCoroutine(MoveAlongWaypoints());
        }
    }

    private IEnumerator MoveAlongWaypoints()
    {
        isMoving = true;
        
        Debug.Log("2번");
        while (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            Debug.Log("2-1번");

            // 이동이 완료될 때까지 루프
            while (Vector3.Distance(cameraTransform.position, targetWaypoint.position) > 0.1f)
            {
                        Debug.Log("2-2번");
                // 위치 이동
                cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

                // 회전
                Quaternion targetRotation = Quaternion.LookRotation(targetWaypoint.forward);
                cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                        Debug.Log("2-3번");
                yield return null; // 다음 프레임까지 대기
            }
            Debug.Log("3번");

            // 다음 웨이포인트로 이동
            currentWaypointIndex++;
        }

        Debug.Log("4번");
        isMoving = false; // 모든 웨이포인트를 따라 이동이 완료됨
    }
}
