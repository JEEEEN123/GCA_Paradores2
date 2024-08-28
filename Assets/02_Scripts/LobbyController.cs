using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    // �˾��� �� �ؽ�Ʈ�� 
    public string[] popupTexts;
    private int popupIndex = 0;

    void Start()
    {
        UIManager.instance.ClosePopup();


        // ���� �ؽ�Ʈ ����
        popupTexts = new string[] {
            "Senor(Senora), \n\n ȣ�� �Ķ󵵸��� ���� ���� �������� ȯ���մϴ�. \n\n �̰��� �ϻ󿡼� ���, \n ����� �ð��� ���� �� �ִ� ���Դϴ�.",
            "������ ����� ���� Ư���� ���� ��Ű���� �غ��߽��ϴ�. \n\n �ڿ� �ӿ��� ������ ã��, �������� �� �ִ� �ð��� ��������.",
            "������ ���� ���ð�, \n������ �غ� �ǽø� \n �ٴ��� ��¦�̴� ǥ�÷� �̵����ּ���."
        };
         
        ShowFirstPopup();
    }
    

    // �˾��� ���� ���� �޼���
    public void ShowFirstPopup()
    {
        if (popupIndex < popupTexts.Length)
        {
            
            // ��: UIManager�� ���� �ؽ�Ʈ�� �˾��� ǥ��
            UIManager.instance.ShowPopup(popupTexts[popupIndex]);
            Debug.Log(popupIndex);
            popupIndex++;
        }
        else
        {
            // ������ ��� �����־��ٸ� ������
            UIManager.instance.ClosePopup();

        }
    }

}
