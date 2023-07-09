using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : MonoBehaviour
{
    Timer timer;
    GameObject controls;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        controls = GameObject.FindGameObjectWithTag("Controls");
        timer.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            timer.startTimer = true;
            timer.gameObject.SetActive(true);
            controls.gameObject.SetActive(false);
        }
    }
}
