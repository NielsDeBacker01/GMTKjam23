using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;
    CamController camCont;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        camCont = Camera.main.GetComponent<CamController>();   
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            timer.startTimer = true;
            camCont.minPos += newCamPos;
            camCont.maxPos += newCamPos;

            collision.GetComponent<HeroBehaviour>().spawnPoint.position = newPlayerPos;
            collision.GetComponent<HeroBehaviour>().Spawn(0);
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(newPlayerPos.x + 2, newPlayerPos.y, newPlayerPos.z);
        }
    }
}
