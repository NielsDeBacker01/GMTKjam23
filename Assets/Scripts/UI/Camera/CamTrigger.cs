using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;
    CamController camCont;

    // Start is called before the first frame update
    void Start()
    {
        camCont = Camera.main.GetComponent<CamController>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            camCont.minPos += newCamPos;
            camCont.maxPos += newCamPos;

            collision.transform.position = newPlayerPos;
            GameObject.FindGameObjectWithTag("Player").transform.position = newPlayerPos;
        }
    }
}
