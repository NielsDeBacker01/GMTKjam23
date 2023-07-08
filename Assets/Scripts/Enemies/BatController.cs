using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public Transform pivotPoint;
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.position, Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
