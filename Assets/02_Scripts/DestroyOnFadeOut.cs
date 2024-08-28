using UnityEngine;

public class DestroyOnFadeOut : MonoBehaviour
{
    public GameObject objectToDestroy; // 파괴할 오브젝트
    public SwingCamera swingCamera; // SwingCamera 스크립트 참조

    public void StartFadeOutAndDestroy()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy); // 오브젝트 파괴
        }

        // 스윙 카메라가 페이드아웃을 시작하게 함
        swingCamera.StartFadeOut(); 
    }
}
