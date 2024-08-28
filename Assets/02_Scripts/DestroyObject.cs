using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public Camera mainCamera; // 플레이어의 카메라
    public float destructionDistance = 5.0f; // 파괴될 거리 기준
    public SwingCamera swingCamera; // SwingCamera 스크립트 참조

    void Update()
    {
        // 카메라와 오브젝트 사이의 거리 계산
        float distanceToCamera = Vector3.Distance(mainCamera.transform.position, transform.position);

        // 특정 거리 이내로 카메라가 접근했을 때 오브젝트 파괴
        if (distanceToCamera <= destructionDistance)
        {
            Destroy(gameObject); // 오브젝트 파괴
            swingCamera.StartSwinging(); // 카메라 스윙 시작
        }
    }
}
