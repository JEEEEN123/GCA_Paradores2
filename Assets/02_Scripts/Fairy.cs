using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    [SerializeField]private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // 동전이 골인했을 때 호출되는 메서드
    public void OnCoinGoal()
    {
        // Fairy 캐릭터 활성화
        gameObject.SetActive(true);

        // 애니메이션 재생
        StartCoroutine(FairyAnimation());
    }

    private IEnumerator FairyAnimation()
    {
        // 등장 후 잠시 대기
        yield return new WaitForSeconds(1.0f);

        // 오른쪽으로 비행 애니메이션 실행
        anim.SetBool("Fly Left", true);
        transform.DOLocalMove(new Vector3(73.5f,7.6f,-115f),1f);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("Fly Left", false);

        // 왼쪽으로 비행 애니메이션 실행
        anim.SetBool("Fly Right", true);
        transform.DOLocalMove(new Vector3(73f, 7.6f, -115f), 1f);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("Fly Right", false);

        // Spell Cast 애니메이션 실행
        yield return new WaitForSeconds(1.0f);
        anim.SetTrigger("Spell");

        // Spell Cast 후 잠시 대기
        yield return new WaitForSeconds(3.0f);

        // Fairy 캐릭터 비활성화
        gameObject.SetActive(false);


        // popup 띄우기 
        UIManager.instance.ShowFirstPopup();
    }
}
