using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    // 팝업에 들어갈 텍스트들 
    public string[] popupTexts;
    private int popupIndex = 0;

    void Start()
    {
        UIManager.instance.ClosePopup();


        // 예시 텍스트 설정
        popupTexts = new string[] {
            "당신은 호텔에 초대되었습니다.",
            "주변을 둘러보세요.",
            "밖으로 나가 배를 타십쇼 ."
        };

        ShowFirstPopup();
    }
    

    // 팝업을 띄우기 위한 메서드
    public void ShowFirstPopup()
    {
        if (popupIndex < popupTexts.Length)
        {
            
            // 예: UIManager를 통해 텍스트를 팝업에 표시
            UIManager.instance.ShowPopup("Welcome!",popupTexts[popupIndex]);
            Debug.Log(popupIndex);
            popupIndex++;
        }
        else
        {
            // 내용을 모두 보여주었다면 꺼진다
            UIManager.instance.ClosePopup();

        }
    }

}
