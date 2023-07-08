using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bonePrefab;
    private float counter;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter > 3)
        {
            Throw();
            counter = 0;
        }
    }

    void Throw()
    {
        Instantiate(bonePrefab, firePoint.position, firePoint.rotation);
    }
}
