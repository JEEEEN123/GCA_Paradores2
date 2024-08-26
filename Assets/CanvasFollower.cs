using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollower : MonoBehaviour
{
    private Transform playerCamera;  // ī�޶��� Transform

    public float distanceFromCamera = 2.0f;  // ī�޶�κ����� �Ÿ�
    public float lerpSpeed = 5.0f;  // �г��� �̵��ϴ� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        // Main Camera �±׷� ī�޶� ã��
        GameObject cameraObject = GameObject.FindWithTag("MainCamera");

        if (cameraObject != null)
        {
            playerCamera = cameraObject.transform;
        }
        else
        {
            Debug.LogError("MainCamera�� ã�� �� �����ϴ�. VR ī�޶� ����� �����Ǿ� �ִ��� Ȯ���ϼ���.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera != null)
        {
            // ��ǥ ��ġ ��� (ī�޶� ��)
            Vector3 targetPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;

            // ���� ��ġ���� ��ǥ ��ġ�� �ε巴�� �̵�
            //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
            transform.position = targetPosition;


            // �г��� �׻� ī�޶� �ٶ󺸰� ����
            transform.LookAt(playerCamera);
            transform.Rotate(0, 180, 0);  // �г��� �������� �ʵ��� 180�� ȸ��
        }
    }
}
