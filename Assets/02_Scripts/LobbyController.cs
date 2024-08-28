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
            "Senor(Senora), \n\n 호텔 파라도르에 오신 것을 진심으로 환영합니다. \n\n 이곳은 일상에서 벗어나, \n 평온한 시간을 보낼 수 있는 곳입니다.",
            "오늘은 당신을 위해 특별한 힐링 패키지를 준비했습니다. \n\n 자연 속에서 여유를 찾고, 재충전할 수 있는 시간을 가지세요.",
            "차분히 숨을 고르시고, \n시작할 준비가 되시면 \n 바닥의 반짝이는 표시로 이동해주세요."
        };
         
        ShowFirstPopup();
    }
    

    // 팝업을 띄우기 위한 메서드
    public void ShowFirstPopup()
    {
        if (popupIndex < popupTexts.Length)
        {
            
            // 예: UIManager를 통해 텍스트를 팝업에 표시
            UIManager.instance.ShowPopup(popupTexts[popupIndex]);
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
