using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // 닿은게 Coin 이라면 
        if(other.CompareTag("COIN"))
        {
            Debug.Log("coin~");
        }

        // 동전이 닿으면 제거
        Destroy(other.gameObject);

    }
}
