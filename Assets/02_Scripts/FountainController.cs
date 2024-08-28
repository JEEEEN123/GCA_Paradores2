using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour
{
    private AudioSource sfx_coin;

    private void Start()
    {
        sfx_coin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ Coin �̶�� 
        if(other.CompareTag("COIN"))
        {
            Debug.Log("coin~");

            sfx_coin.Play();

            // ������ ������ ����
            Destroy(other.gameObject);
        }

        
    }
}
