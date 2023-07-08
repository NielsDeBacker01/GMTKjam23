using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float counter;
    private float timerValue = 59;

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.fixedDeltaTime;    

        if (counter <= 100000)
        {
            timerValue -= 1;
            counter = 0;
        }

        timerText.text = "00:" + timerValue.ToString();
    }
}
