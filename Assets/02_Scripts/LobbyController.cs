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
            "����� ȣ�ڿ� �ʴ�Ǿ����ϴ�.",
            "�ֺ��� �ѷ�������.",
            "������ ���� �踦 Ÿ�ʼ� ."
        };

        ShowFirstPopup();
    }
    

    // �˾��� ���� ���� �޼���
    public void ShowFirstPopup()
    {
        if (popupIndex < popupTexts.Length)
        {
            
            // ��: UIManager�� ���� �ؽ�Ʈ�� �˾��� ǥ��
            UIManager.instance.ShowPopup("Welcome!",popupTexts[popupIndex]);
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
