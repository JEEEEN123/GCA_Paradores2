using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour
{
    private AudioSource sfx_coin;
    [SerializeField] private Fairy fairy;

    private void Start()
    {
        sfx_coin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 닿은게 Coin 이라면 
        if(other.CompareTag("COIN"))
        {
            Debug.Log("coin~");

            sfx_coin.Play();

            // 동전이 닿으면 제거
            Destroy(other.gameObject);

            // 동전이 골인했을 때 Fairy 등장
            fairy.OnCoinGoal();
        }

    }

}
