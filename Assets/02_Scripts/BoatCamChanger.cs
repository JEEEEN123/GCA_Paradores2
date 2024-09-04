using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCamChanger : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject FPSCam;


    public void ChangeCam()
    {
        MainCam.SetActive(false);
        FPSCam.SetActive(true);
    }

}
