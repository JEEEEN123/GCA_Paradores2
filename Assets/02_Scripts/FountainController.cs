using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // ������ Coin �̶�� 
        if(other.CompareTag("COIN"))
        {
            Debug.Log("coin~");
        }

        // ������ ������ ����
        Destroy(other.gameObject);

    }
}
