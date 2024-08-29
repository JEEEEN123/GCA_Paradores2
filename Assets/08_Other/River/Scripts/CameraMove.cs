using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Target;
    public float smooth = 2f;
    Vector3 distance;

    void Start()
    {
        distance = transform.position - Target.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(Target.transform.position + distance, transform.position, smooth);
    }
}