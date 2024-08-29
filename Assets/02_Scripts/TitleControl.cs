using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;


public class TitleControl : MonoBehaviour
{
    // title image 
    private Image pressImage;

    // A ��ư �Է��� �����ϴ� InputActionReference
    public InputActionReference PressA;

    private void Start()
    {
        // image 
        pressImage = GetComponent<Image>();

        // A ��ư�� ������ ���� �ݹ� �Լ� ����
        PressA.action.performed += OnPressA;

        // start blicking 
        StartCoroutine(Blink());
    }


    // A ��ư�� ������ �� ����Ǵ� �޼���
    private void OnPressA(InputAction.CallbackContext context)
    {
        Debug.Log("A ��ư�� ���Ƚ��ϴ�!");

        // A ��ư�� ������ �� ȭ�� ��ȯ ���� �߰� �۾��� ���⿡ �߰�

        GameManager.Instance.LoadSceneCall();
    }

    // ��ο����� ������� �Լ�
    private IEnumerator Blink()
    {
        while (true)
        {
            // ���̵� �ƿ� (��ο���)
            pressImage.DOFade(0, 1.0f);
            yield return new WaitForSeconds(1.0f); // 0.5�� ���� ���

            // ���̵� �� (�����)
            pressImage.DOFade(1, 1.0f);
            yield return new WaitForSeconds(1.5f); // 0.5�� ���� ���
        }
    }

    // ��ü�� �ı��ǰų� ���� ����� �� ȣ��Ǵ� �޼���
    private void OnDestroy()
    {
        // �޸� ������ �����ϱ� ���� �ݹ� �Լ� ����
        PressA.action.performed -= OnPressA;
    }
}
