using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    public void EndingPopup()
    {
        StartCoroutine(WaitForEnding());
    }

    private IEnumerator WaitForEnding()
    {
        yield return new WaitForSeconds(3f);

        UIManager.instance.ShowFirstPopup();

    }
}
